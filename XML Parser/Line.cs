using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ext.System.Core;

namespace LibMain {
    public class Line : ILine {

        private string _Data = "";

        public static Line Create(string Format, params object[] Args) {
            return new Line(string.Format(Format, Args));
        }

        public static Line Create(string Data) {
            return new Line(Data);
        }

        private Line(string Str) {
            _Data = Str;
        }

        public void Print() {
            Parser.WriteString(_Data);
        }
    }
}
