using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Threading;
using CrmEarlyBound;

namespace ITI.TicketResolutionDate.Workflow
{
    public class CalculateResolutionDate : WorkFlowActivityBase
    {

        #region Input/Output Arguments

        [Input("Start Date")]
        [RequiredArgument]
        public InArgument<DateTime> StartDate { get; set; }

        [Input("Priority")]
        [RequiredArgument]
        [AttributeTarget("mhn_ticket", "cr53d_status")]
        public InArgument<OptionSetValue> Priority { get; set; }

        [Output("Resolution Date")]
        public OutArgument<DateTime> ResolutionDate { get; set; }

        #endregion

        public override void ExecuteCRMWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext crmWorkflowContext)
        {
            base.ExecuteCRMWorkFlowActivity(context, crmWorkflowContext);

            var dynamicsContext = crmWorkflowContext.WorkflowExecutionContext;
            var organizationService = crmWorkflowContext.OrganizationService;
            var tracingService = crmWorkflowContext.TracingService;

            DateTime startDate = StartDate.Get(context);
            OptionSetValue priority = Priority.Get(context);

            int workDays = 0;
            switch (priority.Value)
            {
                case (int)mhn_Ticket_cr53d_Status.Low:
                    workDays = 72;
                    break;

                case (int)mhn_Ticket_cr53d_Status.Medium:
                    workDays = 24;
                    break;

                case (int)mhn_Ticket_cr53d_Status.High:
                    workDays = 4;
                    break;

                case (int)mhn_Ticket_cr53d_Status.Critical:
                    workDays = 2;
                    break;

                default:
                    throw new InvalidPluginExecutionException(
                        $"Unsupported Priority Value: {priority.Value}");
            }

            DateTime resolutionDate = AddWorkingDays(startDate, workDays);
            ResolutionDate.Set(context, resolutionDate);
        }

        private static DateTime AddWorkingDays(DateTime startDate, int workDays)
        {
            DateTime currentDate = startDate;
            int addDays = 0;
            while(addDays < workDays)
            {
                currentDate = currentDate.AddDays(1);
                if(currentDate.DayOfWeek != DayOfWeek.Friday && currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    addDays++;
                }
            }
            return currentDate;
        }
    }
}
