using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.ServiceModel;
using System.Text;
using CrmEarlyBound;


namespace ITI.AuditManagment.Plugins
{
    public class TicketAuditPlugin : PluginBase
    {
        public TicketAuditPlugin() : base(typeof(TicketAuditPlugin))
        {
        }

        protected override void ExecuteCdsPlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;
            var serviceFactory = localPluginContext.CurrentUserService;
            var tracingService = localPluginContext.TracingService;

            try
            {
                if (!context.InputParameters.Contains("Target") || !(context.InputParameters["Target"] is Entity))
                    return;

                mhn_Ticket ticketTarget = ((Entity)context.InputParameters["Target"]).ToEntity<mhn_Ticket>();

                var preImage = context.PreEntityImages.Contains("PreImage")
                    ? context.PreEntityImages["PreImage"].ToEntity<mhn_Ticket>()
                    : null;

                string message = context.MessageName;
                var changedBy = new EntityReference("systemuser", context.InitiatingUserId);
                DateTime changedOn = DateTime.UtcNow;

                StringBuilder oldValue = new StringBuilder();
                StringBuilder newValue = new StringBuilder();

                foreach (var attribute in ticketTarget.Attributes)
                {
                    string displayName = GetAttributeDisplayName(serviceFactory, ticketTarget.LogicalName, attribute.Key);
                    object oldAttributeValue = null;

                    if (preImage != null && preImage.Contains(attribute.Key))
                    {
                        oldAttributeValue = preImage[attribute.Key];
                    }
                    oldValue.AppendLine($"{displayName}: {FormatAttributeValue(oldAttributeValue)}");
                    newValue.AppendLine($"{displayName}: {FormatAttributeValue(attribute.Value)}");
                }

                var audit = new mhn_Audit();

                audit.mhn_OldValue = oldValue.ToString();
                audit.mhn_NewValue = newValue.ToString();
                audit.mhn_ChangeBy = changedBy;
                audit.mhn_ChangedOn = changedOn;
                audit.mhn_Message = message;
                audit.mhn_Ticket = ticketTarget.ToEntityReference();
                serviceFactory.Create(audit);

            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                throw new InvalidPluginExecutionException("The following error occurred in MyPlugin.", ex);
            }
            catch (Exception ex)
            {
                tracingService.Trace("MyPlugin: error: {0}", ex.ToString());
                throw;
            }
        }

        private string GetAttributeDisplayName(IOrganizationService service, string entityLogicalName, string attributeLogicalName)
        {
            var request = new RetrieveAttributeRequest
            {
                EntityLogicalName = entityLogicalName,
                LogicalName = attributeLogicalName,
                RetrieveAsIfPublished = true
            };

            var response = (RetrieveAttributeResponse)service.Execute(request);

            var metadata = response.AttributeMetadata;

            return metadata.DisplayName?.UserLocalizedLabel?.Label
                ?? attributeLogicalName;
        }

        private string FormatAttributeValue(object value)
        {
            if (value == null)
                return "No Value";

            switch (value)
            {
                case EntityReference entityReference:
                    return entityReference.Name ?? entityReference.Id.ToString();

                case OptionSetValue optionSet:
                    {
                        if (Enum.IsDefined(typeof(mhn_Ticket_cr53d_Status), optionSet.Value))
                        {
                            return ((mhn_Ticket_cr53d_Status)optionSet.Value).ToString();
                        }

                        return optionSet.Value.ToString();
                    }

                case Money money:
                    return money.Value.ToString();

                case DateTime dateTime:
                    return dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                case bool boolean:
                    return boolean ? "Yes" : "No";

                case Guid guid:
                    return guid.ToString();

                default:
                    return value.ToString();
            }
        }
    }
}
