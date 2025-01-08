using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals.DocView
{
    public class SignalDocument : Document
    {
        private List<SignalValue> signals = new List<SignalValue>();

        // signals Property, ahhoz hogy a view-ban elérhessük az értékeket.
        // Ez readonly.
        public IReadOnlyList<SignalValue> Signals
        {
            get { return signals; }
        }

        private SignalValue[] testValues = new SignalValue[]
        {
            new SignalValue(45, new DateTime(2024, 11, 21, 17, 42, 31, 120)),
            new SignalValue(54, new DateTime(2024, 11, 21, 17, 42, 31, 596)),
            new SignalValue(83, new DateTime(2024, 11, 21, 17, 42, 32, 005)),
            new SignalValue(45, new DateTime(2024, 11, 21, 17, 42, 32, 199)),
            new SignalValue(-14, new DateTime(2024, 11, 21, 17, 42, 32, 878)),
            new SignalValue(-19, new DateTime(2024, 11, 21, 17, 42, 33, 125)),
        };
        public SignalDocument(string name) : base(name)
        {
            // Kezdetben dolgozzunk úgy, hogy a signals
            // jelérték listát a testValues alapján inicializáljuk.
            signals.AddRange(testValues);
        }
        public override void SaveDocument(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                string ts;
                foreach (SignalValue signalValue in signals)
                {
                    ts = signalValue.TimeStamp.ToUniversalTime().ToString("o");
                    sw.WriteLine(signalValue.Value.ToString() + "\t" + ts);
                }
            }
        }
        public override void LoadDocument(string filePath)
        {
            signals.Clear();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    string[] columns = line.Split("\t");
                    double value = double.Parse(columns[0]);
                    DateTime timeStamp = DateTime.Parse(columns[1]).ToLocalTime();
                    SignalValue svFromLine = new SignalValue(value, timeStamp);
                    signals.Add(svFromLine);
                }
            }
            TraceValues();
            UpdateAllViews();
        }
        private void TraceValues()
        {
            foreach (var signal in signals)
                Trace.WriteLine(signal.ToString());
        }
    }
}
