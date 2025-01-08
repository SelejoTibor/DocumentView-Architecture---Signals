namespace Signals.DocView;

/// <summary>
/// Az egyes dokumentum típusok ősosztálya. Bár esetünkben csak egy dokumentum típus
/// létezik, a későbbi bővíthetőség miatt célszerű külön választani.
/// Tartalmazza a nézetek listáját, melyek a dokumentumot megjelenítik.
/// </summary>
public class Document
{
    /// <summary>
    /// A nézetek listája, melyek a dokumentumot megjelenítik.
    /// </summary>
    private List<IView> views = new List<IView>();

    /// <summary>
    /// A dokumentum neve.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// A dokumentumhoz tartozó nézetek száma.
    /// </summary>
    public int ViewCount => views.Count;


    public Document(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Egy nézetet beregisztrál a dokumentumhoz.
    /// </summary>
    public void AttachView(IView view)
    {
        views.Add(view);
        view.ViewNumber = ViewCount;
        view.Update();
    }

    /// <summary>
    /// Kiregisztrál egy nézetet.
    /// </summary>
    public void DetachView(IView view)
    {
        views.Remove(view);
    }

    /// <summary>
    /// Van-e a dokumentumhoz nézet
    /// </summary>
    public bool HasAnyView => ViewCount > 0;

    /// <summary>
    /// Frissíti az összes, dokumentumhoz tartozó nézetet.
    /// </summary>
    protected void UpdateAllViews()
    {
        foreach (var view in views)
            view.Update();
    }

    /// <summary>
    /// Betölti a dokumentum tartalmát. A leszármazott osztályban felüldefiniálandó (override).
    /// </summary>
    public virtual void LoadDocument(string filePath)
    {
    }

    /// <summary>
    /// Elmenti a dokumentum tartalmát. A leszármazott osztályban felüldefiniálandó (override).
    /// </summary>
    public virtual void SaveDocument(string filePath)
    {
    }
}
