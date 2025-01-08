using Signals.DocView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signals
{
    public partial class GraphicsSignalView : UserControl, IView
    {
        /// <summary>
        /// A view sorszáma
        /// </summary>
        public int ViewNumber { get; set; }

        /// <summary>
        /// A kirajzoláshoz szükséges skálatényezők.
        /// </summary>
        private const double pixelPerSec = 0.00003;
        private const double pixelPerValue = 1;

        private double scaleFactor = 1; 

        /// <summary>
        /// Az első négyszög megjelenéséig igaz.
        /// </summary>
        bool firstRect = true;

        /// <summary>
        /// Deafult konstruktor
        /// </summary>
        public GraphicsSignalView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A dokumentum, melynek adatait a nézet megjeleníti.
        /// </summary>
        private SignalDocument document;

        /// <summary>
        /// Konstruktor, melyben a view megkapja a dokumentumot
        /// </summary>
        public GraphicsSignalView(SignalDocument document) : this()
        {
            this.document = document;
        }

        /// <summary>
        /// A View interfész Update műveletánek implementációja.
        /// </summary>
        public new void Update()
        {
            Invalidate();
        }

        /// <summary>
        /// A View interfész GetDocument műveletánek implementációja.
        /// </summary>
        public Document GetDocument()
        {
            return document;
        }

        /// <summary>
        /// A UserControl.Paint felüldefiniálása, ebben rajzolunk.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Poontozott 2 pixel széles kék toll aminek nyíl van a végén.
            // Ezzel rajzoljuk ki a tengelyeket.
            var pen = new Pen(Color.Blue, 2)
            {
                DashStyle = DashStyle.Dot,
                EndCap = LineCap.ArrowAnchor,
            };

            // Pontok a vonalak kirajzolásához.
            // ClientSize.Height / 2 a control panel közepe.
            // A függőleges tengely 2-vel elvan tolva, hogy tényleg 2 pixel vastag legyen az y tengely.
            Point X_start = new Point(0, ClientSize.Height / 2);
            Point X_end = new Point(ClientSize.Width, ClientSize.Height / 2);
            Point Y_start = new Point(2, ClientSize.Height);
            Point Y_end = new Point(2, 0);

            // Tengelyek kirajzolása.
            e.Graphics.DrawLine(pen, X_start, X_end);
            e.Graphics.DrawLine(pen, Y_start, Y_end);

            // Ha nincs semmilyen értékünk akkor vége.
            if (document.Signals.Count == 0)
                return;

            // Ezzel rajzoljuk ki a grafikont.
            var penGraph = new Pen(Color.Red, 1);

            // Négyszög segítségével lesznek kirajzolva a grafikon pontjai
            RectangleF graphPoint = new RectangleF();
            // A vonalak kirajzolásához szükség van megelőző négyszög koordinátáira
            // Két négyszöget kötünk össze.
            // A kezdőpont az aktuális, a végpont az őt megelőző négyszög.
            RectangleF prevGraphPoint = new RectangleF();

            // Minden grfikon pontot kirajzolunk és közéjük vonalat.
            foreach (SignalValue signal in document.Signals)
            {
                graphPoint = GraphPointScale(signal);

                // Az első négyszög önmagával lesz összekötve.
                if (firstRect)
                {
                    prevGraphPoint = graphPoint;
                    firstRect = false;
                }
                e.Graphics.FillRectangle(Brushes.Red, graphPoint);
                e.Graphics.DrawLine(penGraph, graphPoint.X + 1, graphPoint.Y + 1, prevGraphPoint.X + 1, prevGraphPoint.Y + 1);
                prevGraphPoint = graphPoint;
            }
            firstRect = true;
            base.OnPaint(e);
        }


        /// <summary>
        /// A grafikon pontjait ezzel a skálző függvénnyel lehet megkapni.
        /// </summary>
        private RectangleF GraphPointScale(SignalValue signal)
        {
            // Ez az objektum reprezentálja majd a grafikon pontunkat.
            RectangleF graphPoint = new RectangleF();

            // 3x3 négyszög
            graphPoint.Width = 3;
            graphPoint.Height = 3;

            // Az időtengely 0 pontja az első bejegyzés timestamp értéke.
            // Ettől szmítjuk a többi signal x értékét.
            long startTime = document.Signals[0].TimeStamp.Ticks;

            // Négyszög X és Y koordinátáját itt állítjuk be.
            graphPoint.X = (int)((signal.TimeStamp.Ticks - startTime) * pixelPerSec * scaleFactor);
            graphPoint.Y = (int)(ClientSize.Height / 2 - (signal.Value * pixelPerValue * scaleFactor));

            return graphPoint;
        }

        /// <summary>
        /// Nagyítás
        /// </summary>
        private void zoomIn_Click(object sender, EventArgs e)
        {
            scaleFactor *= 1.2;
            Invalidate();
        }

        /// <summary>
        /// Kicsinyítés
        /// </summary>
        private void zoomOut_Click(object sender, EventArgs e)
        {
            scaleFactor /= 1.2;
            Invalidate();
        }
    }
}
