using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Ext.System.Core;

namespace LibMain {

    public enum RangeType {
        None = 0,
        Start = 1,
        Stop = 2,
        Between = 3
    }

    public class Note : ILine {

        public static int Division { get; set; }

        private string _Beat = null;
        private string _Step = null;
        private string _Notations = null;
        private string _Alter = null;
        private string _Octave = null;
        private string _Lyric = null;

        public int Duration { get; private set; } = 0;
        public RangeType Tie { get; set; } = RangeType.None;
        public RangeType Triplet { get; private set; } = RangeType.None;
        public RangeType Chord { get; set; } = RangeType.None;
        public bool Rest { get; private set; } = false;
        public string Addition { get; set; } = null;

        public Note(XmlNode CurNode) {
            var Node = CurNode.SelectSingleNode("pitch");
            if (Node != null) {
                XmlNode n = null;
                XmlNodeList Ties = CurNode.SelectNodes("tie");
                foreach (XmlNode nd in Ties) {
                    if (Parser.ShowTie && Ties != null) {
                        switch (nd.Attributes["type"]?.Value ?? "") {
                            case "start":
                                if (this.Tie == RangeType.Stop)
                                    this.Tie = RangeType.Between;
                                else
                                    this.Tie = RangeType.Start;
                                break;
                            case "stop":
                                if (this.Tie == RangeType.Start)
                                    this.Tie = RangeType.Between;
                                else
                                    this.Tie = RangeType.Stop;
                                break;
                        }
                    }
                    if (this.Tie == RangeType.Between)
                        break;
                }
                if (Parser.ShowNotations) {
                    n = CurNode.SelectSingleNode("notations");
                    if (n != null) {
                        _Notations = Parser.GetNotations(n);
                        var Tp = n.SelectSingleNode("tuplet");
                        if (Tp != null) {
                            switch (Tp.Attributes["type"].Value) {
                                case "start":
                                    Triplet = RangeType.Start;
                                    break;
                                case "stop":
                                    Triplet = RangeType.Stop;
                                    break;
                            }
                        }
                    }
                }
                n = CurNode.SelectSingleNode("duration");
                if (n == null)
                    throw new Exception("Duration is not present. Measure number " + Parser.MeasureID);
                Duration = n.InnerText.ToInt();
                _Beat = Parser.ConvertBeat(Duration, Division);
                n = Node.SelectSingleNode("step");
                if (n == null)
                    throw new Exception("Step is not present. Measure number " + Parser.MeasureID);
                _Step = n.InnerText;
                n = Node.SelectSingleNode("alter");
                if (n != null)
                    _Alter = Parser.ConvertAlter(n.InnerText);
                if (Parser.ShowOctave) {
                    _Octave = Node.SelectSingleNode("octave")?.InnerText ?? "";
                }
            } else if (CurNode.SelectSingleNode("rest") != null) {
                Rest = true;
                _Beat = Parser.ConvertBeat(CurNode.SelectSingleNode("duration").InnerText.ToInt(), Division);
            } else
                throw new Exception("Incorrect body for tag 'note'. Measure number " + Parser.MeasureID.ToString());
            Node = CurNode.SelectSingleNode("lyric");
            if (Parser.ShowLyric && Node != null) {
                var n = Node.SelectSingleNode("syllabic");
                if (n == null)
                    throw new Exception("Can't find syllabic for lyric. MeasureID: " + Parser.MeasureID.ToString());
                var Syl = n.InnerText;
                n = Node.SelectSingleNode("text");
                var Text = n.InnerText;
                if (n == null || Text.IsNullOrEmpty())
                    throw new Exception("Can't find text for lyric. MeasureID: " + Parser.MeasureID.ToString());
                _Lyric = Parser.ConvertLyric(Syl, Text);
            }
        }

        public void Print() {
            if(_Lyric.IsNotNullAndNotEmpty()) {
                Parser.WriteString("Lyric");
                Parser.WriteString(_Lyric);
            }
            if (Chord == RangeType.Start)
                Parser.WriteString("Chord begin");
            if (Triplet == RangeType.Start)
                Parser.WriteString("Triplet");
            StringBuilder sb = new StringBuilder();
            if (Rest) {
                sb.AppendFormat("{0} beat rest", _Beat);
            } else {
                sb.AppendFormat("{0} beat {1}", _Beat, _Step);
                if (_Alter.IsNotNullAndNotEmpty())
                    sb.AppendFormat(" {0}", _Alter);
                if (_Octave.IsNotNullAndNotEmpty())
                    sb.AppendFormat(" {0}", _Octave);
                if (_Notations.IsNotNullAndNotEmpty())
                    sb.AppendFormat(" {0}", _Notations);
                if (Addition.IsNotNullAndNotEmpty())
                    sb.AppendFormat(" {0}", Addition);
                if(Tie != RangeType.None)
                    sb.Append(" tied");
            }
            Parser.WriteString(sb);
            if (Chord == RangeType.Stop)
                Parser.WriteString("Chord end");
            if(Tie == RangeType.Stop)
                Parser.WriteString("End Tie");
        }

        public void SetChord(RangeType rt) {
            Chord = rt;
        }
    }
}
