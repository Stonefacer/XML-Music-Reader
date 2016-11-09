using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ext.System.Core;

namespace LibMain {
    public class Tie : ILine {

        public int SummayDuration { get; private set; }
        public int Division { get; private set; }

        public Tie() {

        }

        public void Add(int Duration, int Div) {
            if (Division == 0)
                Division = Div;
            if (Div != this.Division) {
                var lcm = AdvMath.LCM(Division, Div);
                SummayDuration *= Division / lcm;
                Duration *= Div / lcm;
            }
            SummayDuration += Duration;
        }

        public void Print() {
            Parser.WriteString("{0} beat tie", Parser.ConvertBeat(SummayDuration, Note.Division));
        }
    }
}
