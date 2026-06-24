import { IInputs, IOutputs } from "./generated/ManifestTypes";

export class ITITicketInvestigationGrid
  implements ComponentFramework.StandardControl<IInputs, IOutputs> {

  private _container: HTMLDivElement;
  private _context: ComponentFramework.Context<IInputs>;

  public init(
    context: ComponentFramework.Context<IInputs>,
    _notifyOutputChanged: () => void,
    _state: ComponentFramework.Dictionary,
    container: HTMLDivElement
  ): void {
    this._container = container;
    this._context = context;
    context.mode.trackContainerResize(true);
  }

  public updateView(context: ComponentFramework.Context<IInputs>): void {
    this._context = context;
    const dataset = context.parameters.investigationDataset;

    this._container.innerHTML = "";

    if (dataset.loading) {
      this._container.innerHTML = `<p>Loading...</p>`;
      return;
    }

    if (dataset.sortedRecordIds.length === 0) {
      this._container.innerHTML = `<p>No records found.</p>`;
      return;
    }

    const columns = dataset.columns
      .filter(c => !c.isHidden)
      .sort((a, b) => a.order - b.order);

    const table = document.createElement("table");
    table.className = "iti-grid";

    // Header
    const thead = document.createElement("thead");
    const headerRow = document.createElement("tr");
    columns.forEach(col => {
      const th = document.createElement("th");
      th.textContent = col.displayName;
      headerRow.appendChild(th);
    });
    thead.appendChild(headerRow);
    table.appendChild(thead);

    // Body
    const tbody = document.createElement("tbody");
    dataset.sortedRecordIds.forEach(id => {
      const record = dataset.records[id];
      const tr = document.createElement("tr");
      tr.style.cursor = "pointer";

      tr.addEventListener("click", () => {
        this._context.navigation.openForm({
          entityName: dataset.getTargetEntityType(),
          entityId: record.getRecordId()
        });
      });

      columns.forEach(col => {
        const td = document.createElement("td");
        td.textContent = record.getFormattedValue(col.name) ?? "";
        tr.appendChild(td);
      });

      tbody.appendChild(tr);
    });
    table.appendChild(tbody);

    this._container.appendChild(table);
  }

  public getOutputs(): IOutputs { return {}; }

  public destroy(): void { this._container.innerHTML = ""; }
}