using Signals.DocView;

namespace Signals;

/// <summary>
/// A karakterek szerkesztőnézete. Egyrészt UserControl, másrészt nézet is.
/// </summary>
public partial class DemoView : UserControl, IView
{
    /// <summary>
    /// A view sorszáma
    /// </summary>
    public int ViewNumber { get; set; }

    public DemoView()
    {
        InitializeComponent();
    }

    /// <summary>
    /// A dokumentum, melynek adatait a nézet megjeleníti.
    /// TODO: a típusa legyen a Document leszármazottunk.
    /// </summary>
    private Document document;

    public DemoView(Document document)
    {
        InitializeComponent();

        this.document = document;
    }

    /// <summary>
    /// A View interfész Update műveletánek implementációja.
    /// Megjegyzés: a "new" kucsszó nélkül warning-ot kapunk a build során:
    /// ennek oka, hogy a UserControl ősben már van egy Update művelet, mely nem virtuális
    /// (így itt nem is override-olható). Ilyen esetben a new kulcsszóval jelezzük,
    /// hogy szándékoltan vezetünk be egy új (new) azonos nevű függvényt az öröklési
    /// láncban (ezt a technikát ritkán alkalmazzuk, egyfajta "véletlen" névütközés
    /// esetén használjuk leginkább).
    /// </summary>
    public new void Update()
    {
        Invalidate();
    }

    public Document GetDocument()
    {
        return document;
    }

    /// <summary>
    /// A UserControl.Paint felüldefiniálása, ebben rajzolunk.
    /// </summary>
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
    }
}
