namespace Signals;

/// <summary>
/// Új dokumentum paramétereinek megadására szolgál.
/// </summary>
public partial class NewDocForm : Form
{
    public NewDocForm()
    {
        InitializeComponent();
    }

    public string DocName => tbDocName.Text;
}
