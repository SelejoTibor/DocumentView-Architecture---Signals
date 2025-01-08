using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals.DocView
{
    public class SignalValue
    {
        public readonly double Value;
        public readonly DateTime TimeStamp;
        public SignalValue(double value, DateTime timeStamp)
        {
            Value = value;
            TimeStamp = timeStamp;
        }
        public override string ToString()
        {
            return $"Value: {Value}, TimeStamp: {TimeStamp}";
        }
    }
}
