import { IInputs, IOutputs } from "./generated/ManifestTypes";

// Sensible defaults — used when form designer leaves properties blank
const DEFAULTS = {
  MAX_STARS: 5,
  SELECTED_COLOR: "#f59e0b",   // Amber
  UNSELECTED_COLOR: "#d1d5db", // Cool gray
  MIN_STARS: 3,
  MAX_STARS_LIMIT: 10,
} as const;

export class ITIStarRatingControl
  implements ComponentFramework.StandardControl<IInputs, IOutputs> {

  private _container: HTMLDivElement;
  private _wrapper: HTMLDivElement;
  private _stars: HTMLSpanElement[] = [];
  private _currentRating = 0;
  private _notifyOutputChanged: () => void;
  private _context: ComponentFramework.Context<IInputs>;

  // Resolved config (from manifest input props or defaults)
  private _maxStars: number = DEFAULTS.MAX_STARS;
  private _selectedColor: string = DEFAULTS.SELECTED_COLOR;
  private _unselectedColor: string = DEFAULTS.UNSELECTED_COLOR;

  // ─────────────────────────────────────────────
  // LIFECYCLE: init — runs ONCE on mount
  // ─────────────────────────────────────────────
  public init(
    context: ComponentFramework.Context<IInputs>,
    notifyOutputChanged: () => void,
    _state: ComponentFramework.Dictionary,
    container: HTMLDivElement
  ): void {
    this._context = context;
    this._notifyOutputChanged = notifyOutputChanged;
    this._container = container;

    // Resolve config on first load
    this._resolveConfig(context);

    // Build DOM once based on config
    this._buildStarUI();
  }

  // ─────────────────────────────────────────────
  // LIFECYCLE: updateView — runs on every change
  // (value change, mode change, property change)
  // ─────────────────────────────────────────────
  public updateView(context: ComponentFramework.Context<IInputs>): void {
    this._context = context;

    const newMaxStars = this._resolveMaxStars(context);
    const newSelectedColor = this._resolveColor(
      context.parameters.selectedColor?.raw,
      DEFAULTS.SELECTED_COLOR
    );
    const newUnselectedColor = this._resolveColor(
      context.parameters.unselectedColor?.raw,
      DEFAULTS.UNSELECTED_COLOR
    );

    // If config changed (form designer updated props), rebuild the DOM
    const configChanged =
      newMaxStars !== this._maxStars ||
      newSelectedColor !== this._selectedColor ||
      newUnselectedColor !== this._unselectedColor;

    if (configChanged) {
      this._maxStars = newMaxStars;
      this._selectedColor = newSelectedColor;
      this._unselectedColor = newUnselectedColor;
      this._rebuildStars();
    }

    // Always sync current rating from Dataverse
    this._currentRating = context.parameters.rating.raw ?? 0;
    // Clamp: if saved rating > new maxStars, cap it visually
    this._currentRating = Math.min(this._currentRating, this._maxStars);

    this._renderStars();
    this._applyReadOnlyMode();
  }

  public getOutputs(): IOutputs {
    return { rating: this._currentRating };
  }

  public destroy(): void {
    this._stars = [];
  }

  // ─────────────────────────────────────────────
  // PRIVATE: Resolve all config at init
  // ─────────────────────────────────────────────
  private _resolveConfig(context: ComponentFramework.Context<IInputs>): void {
    this._maxStars = this._resolveMaxStars(context);
    this._selectedColor = this._resolveColor(
      context.parameters.selectedColor?.raw,
      DEFAULTS.SELECTED_COLOR
    );
    this._unselectedColor = this._resolveColor(
      context.parameters.unselectedColor?.raw,
      DEFAULTS.UNSELECTED_COLOR
    );
  }

  private _resolveMaxStars(context: ComponentFramework.Context<IInputs>): number {
    const raw = context.parameters.maxStars?.raw;
    if (raw == null || isNaN(raw)) return DEFAULTS.MAX_STARS;
    // Clamp between 3 and 10 — enforce business rule in code
    return Math.max(DEFAULTS.MIN_STARS, Math.min(raw, DEFAULTS.MAX_STARS_LIMIT));
  }

  /**
   * Validates a CSS color string using the browser's built-in parser.
   * If invalid, falls back to the default.
   *
   * Why: The form designer might type an invalid hex. We fail gracefully
   * instead of rendering a broken color (e.g., black on black).
   */
  private _resolveColor(raw: string | null | undefined, fallback: string): string {
    if (!raw || raw.trim() === "") return fallback;

    const testEl = document.createElement("div");
    testEl.style.color = raw;
    // Browser sets color to "" if the value is invalid
    return testEl.style.color !== "" ? raw : fallback;
  }

  // ─────────────────────────────────────────────
  // PRIVATE: Build initial DOM
  // ─────────────────────────────────────────────
  private _buildStarUI(): void {
    this._wrapper = document.createElement("div");
    this._wrapper.className = "star-rating-wrapper";
    this._buildStars();
    this._container.appendChild(this._wrapper);
  }

  private _buildStars(): void {
    this._wrapper.innerHTML = "";
    this._stars = [];

    for (let i = 1; i <= this._maxStars; i++) {
      const star = document.createElement("span");
      star.className = "star";
      star.innerHTML = "★";
      star.setAttribute("aria-label", `${i} star${i > 1 ? "s" : ""}`);
      star.setAttribute("role", "button");
      star.dataset["value"] = i.toString();

      star.addEventListener("click", () => this._onStarClick(i));
      star.addEventListener("mouseenter", () => this._onStarHover(i));
      star.addEventListener("mouseleave", () => this._renderStars());

      this._stars.push(star);
      this._wrapper.appendChild(star);
    }
  }

  /** Called when maxStars or colors change after initial render */
  private _rebuildStars(): void {
    this._buildStars();
  }

  // ─────────────────────────────────────────────
  // PRIVATE: Render — apply colors via inline style
  // ─────────────────────────────────────────────
  /**
   * Why inline style instead of CSS classes for colors?
   * Because the colors are DYNAMIC (set by the form designer at runtime).
   * CSS classes are static — you can't write a class for an unknown hex value.
   * Inline styles are the correct tool when values are data-driven.
   */
  private _renderStars(highlightUpTo?: number): void {
    const active = highlightUpTo ?? this._currentRating;

    this._stars.forEach((star, index) => {
      const isFilled = index < active;
      star.style.color = isFilled ? this._selectedColor : this._unselectedColor;
      star.classList.toggle("active", isFilled);
    });
  }

  private _onStarClick(value: number): void {
    if (this._isReadOnly()) return;

    // Toggle off: clicking the same star again resets to 0
    this._currentRating = this._currentRating === value ? 0 : value;
    this._renderStars();
    this._notifyOutputChanged();
  }

  private _onStarHover(value: number): void {
    if (this._isReadOnly()) return;
    this._renderStars(value);
  }

  private _applyReadOnlyMode(): void {
    this._wrapper.classList.toggle("read-only", this._isReadOnly());
  }

  private _isReadOnly(): boolean {
    return this._context.mode.isControlDisabled;
  }
}