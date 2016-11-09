using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

using Ext.System.Core;
using Ext.System.Collections.Generic;

namespace LibMain {
    public static class Parser {

        private static int[] _Primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127 };
        private static XmlDocument _Prev = null;
        private static string _PrevPath = null;
        private static int _LastRepeatID = 0;
        private static StreamWriter _Writer = null;
        private static List<ILine> _Cache = new List<ILine>();

        public static int EncodingID { get; set; }
        public static string InputPath { get; set; }
        public static string OutputPath { get; set; }
        public static bool ShowPartName { get; set; }
        public static bool ShowOctave { get; set; }
        public static bool ShowClef { get; set; }
        public static bool ShowBarLine { get; set; }
        public static bool ShowMeasure { get; set; }
        public static bool ShowTimeSignature { get; set; }
        public static bool ShowTextBox { get; set; }
        public static bool ShowRepeats { get; set; }
        public static bool ShowTitle { get; set; }
        public static bool ShowComposer { get; set; }
        public static bool ShowKeys { get; set; }
        public static bool ShowWords { get; set; }
        public static bool ShowTie { get; set; }
        public static bool ShowLyric { get; set; }
        public static bool ShowNotes { get; set; }
        public static bool ShowTranspose { get; set; }
        public static bool ShowCopyrigths { get; set; }
        public static bool ShowNotations { get; set; }
        public static bool ConvertFractions { get; set; }
        public static bool ShowPartInstrument { get; set; }
        public static int MeasureID { get; private set; }

        public static Action<string> OnNewStringAdded;

        static Parser() {
            EncodingID = 0;
            InputPath = "";
            OutputPath = "";
            ShowPartName = false;
            ShowOctave = false;
            ShowClef = false;
            ShowBarLine = false;
            ShowMeasure = false;
            ShowTimeSignature = false;
            ShowTextBox = false;
            ShowTitle = false;
            ShowComposer = false;
            ShowKeys = false;
            ShowWords = false;
            ShowLyric = false;
            ShowTranspose = false;
            ShowCopyrigths = false;
            ConvertFractions = false;
            OnNewStringAdded = null;
        }

        private static string ConvertFifths(string src, string Mode) {
            if(Mode == "Major") {
                switch(src) {
                    case "0": return "C Major";
                    case "+1": return "One Sharp G Major";
                    case "+2": return "Two Sharp D Major";
                    case "+3": return "Three Sharp A Major ";
                    case "+4": return "Four Sharp E Major";
                    case "+5": return "Five Sharp B Major";
                    case "+6": return "Six Sharp F Sharp Major";
                    case "+7": return "Seven Sharp C Sharp Major";
                    case "-1": return "One Flat F Major";
                    case "-2": return "Two Flat B Flat Major";
                    case "-3": return "Three Flat E Flat Major";
                    case "-4": return "Four Flat A Flat Major";
                    case "-5": return "Five Flat D Flat Major";
                    case "-6": return "Six Flat G Flat Major";
                    case "-7": return "Seven Flat C Flat Major";
                    default: return src;
                }
            } else if(Mode == "Minor") {
                switch(src) {
                    case "0": return "A Minor";
                    case "+1": return "One Sharp E Minor";
                    case "+2": return "Two Sharp B Minor";
                    case "+3": return "Three Sharp F Sharp Minor";
                    case "+4": return "Four Sharp C Sharp Minor";
                    case "+5": return "Five Sharp G Sharp Minor";
                    case "+6": return "Six Sharp D Sharp Minor";
                    case "+7": return "Seven Sharp A Sharp Minor";
                    case "-1": return "One Flat D Minor";
                    case "-2": return "Two Flat G Minor";
                    case "-3": return "Three Flat C Minor";
                    case "-4": return "Four Flat F Minor";
                    case "-5": return "Five Flat B Flat Minor";
                    case "-6": return "Six Flat E Flat Minor";
                    case "-7": return "Seven Flat A Flat Minor";
                    default: return src;
                }
            } else
                throw new InvalidDataException(string.Format("Unknown Key Mode: {0}", Mode));
        }

        private static string ConvertToFirstUpperLetterString(string src) {
            return Char.ToUpper(src[0]) + src.Substring(1);
        }

        private static Encoding GetEncoding() {
            switch(EncodingID) {
                case 0:
                    return Encoding.ASCII;
                case 1:
                    return Encoding.UTF8;
                default:
                    return Encoding.ASCII;
            }
        }

        public static void WriteString(string str) {
            _Writer.WriteLine(str);
            _Writer.WriteLine();
            if(ShowTextBox && OnNewStringAdded != null) {
                OnNewStringAdded(str);
            }
        }

        public static void WriteString(StringBuilder sb) {
            WriteString(sb.ToString());
        }

        public static void WriteString(string Format, params object[] Args) {
            var str = string.Format(Format, Args);
            WriteString(str);
        }

        public static string ConvertAlter(string alter) {
            switch(alter) {
                case "-1": return "flat";
                case "-2": return "double flat";
                case "1": return "sharp";
                case "2": return "double sharp";
                default: return "";
            }
        }

        private static string ConvertBarline(string src) {
            switch(src) {
                case "heavy-light": return "start repeat";
                case "light-light": return "new section";
                case "light-heavy": return "final";
                case "heavy": return "solid";
                default: return src;
            }
        }

        private static string ConvertCleaf(string Note, string Line) {
            switch(Note + Line) {
                case "G2": return "Clef G Treble";
                case "F4": return "Clef F Bass";
                case "C3": return "Clef C Alto Viola";
                case "C4": return "Clef C Tenor Cello";
                default: return Note + Line;
            }
        }

        private static void FindBeginData(XmlElement Element) {
            if(ShowTitle) {
                var Node = Element.SelectSingleNode("/score-partwise/movement-title");
                if(Node != null)
                    WriteString("Title {0}", Node.InnerText);
            }
            if(ShowComposer) {
                var Node = Element.SelectSingleNode("identification/creator");
                if(Node != null)
                    WriteString("Composer {0}", Node.InnerText);
            }
            if(ShowTranspose) {
                ParseTranspose(Element);
            }
        }

        //Part Flugelhorn
        private static Dictionary<string, string> GetParts(XmlElement Element) {
            var Result = new Dictionary<string, string>(10);
            var Node = Element.SelectSingleNode("part-list");
            if(Node == null)
                throw new Exception("Incorrect XML file. Part-list was not found.");
            foreach(XmlNode v in Node.SelectNodes("score-part")) {
                var n = v.SelectSingleNode("part-name");
                if(n == null)
                    Result[v.Attributes["id"].Value] = "";
                else
                    Result[v.Attributes["id"].Value] = n.InnerText;
            }
            return Result;
        }

        private static void ParseAttribute(XmlNode Node) {
            if(ShowKeys) {
                var n = Node.SelectSingleNode("key");
                if(n != null)
                    _Cache.Add(Line.Create("Key {0}", ConvertFifths(n.SelectSingleNode("fifths").InnerText, ConvertToFirstUpperLetterString(n.SelectSingleNode("mode").InnerText))));
            }
            // Time signature
            if(ShowTimeSignature) {
                var n = Node.SelectSingleNode("time");
                if(n != null)
                    _Cache.Add(Line.Create("Time Pattern {0} {1}", n.SelectSingleNode("beats").InnerText, n.SelectSingleNode("beat-type").InnerText));
            }
            // Clef
            if(ShowClef) {
                foreach(XmlNode n in Node.SelectNodes("clef")) {
                    if(n != null) {
                        _Cache.Add(Line.Create(ConvertCleaf(n.SelectSingleNode("sign")?.InnerText ?? "", n.SelectSingleNode("line")?.InnerText ?? "")));
                    }
                }
            }
        }

        public static void Simplyfied(ref int Top, ref int Bottom) {
            var res = AdvMath.GCD(Top, Bottom);
            while(res > 1) {
                Top /= res;
                Bottom /= res;
                res = AdvMath.GCD(Top, Bottom);
            }
        }

        public static string ConvertSingleNumber(int Num) {
            switch(Num) {
                case 0: return "";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                case 10: return "ten";
                case 11: return "eleven";
                case 12: return "twelve";
                case 13: return "thirteen";
                case 14: return "fourteen";
                case 15: return "fifteen";
                case 16: return "sixteen";
                case 17: return "seventeen";
                case 18: return "eighteen";
                case 19: return "nineteen";
                case 20: return "twenty";
            }
            var FirstPart = "";
            if(Num > 69)
                return Num.ToString();
            else if(Num >= 60) {
                FirstPart = "sixty";
                Num -= 60;
            } else if(Num >= 50) {
                FirstPart = "fifty";
                Num -= 50;
            } else if(Num >= 50) {
                FirstPart = "fifty";
                Num -= 50;
            } else if(Num >= 40) {
                FirstPart = "forty";
                Num -= 40;
            } else if(Num >= 30) {
                FirstPart = "thirty";
                Num -= 30;
            } else if(Num >= 20) {
                FirstPart = "twenty";
                Num -= 20;
            }
            if(Num == 0)
                return FirstPart;
            return string.Format("{0}{1}", FirstPart, ConvertSingleNumber(Num));
        }

        public static string ConvertFraction(int Duration, int Division) {
            var Num = Duration / Division;
            var sb = new StringBuilder();
            if(Num > 0)
                sb.AppendFormat("{0} and ", Num);
            Duration %= Division;
            switch(Division) {
                case 2:
                    sb.AppendFormat("{0}half{1}", Duration > 1 ? ConvertSingleNumber(Duration) : "", Duration > 1 ? "s" : "");
                    break;
                case 4:
                    sb.AppendFormat("{0}quarter{1}", Duration > 1 ? ConvertSingleNumber(Duration) : "", Duration > 1 ? "s" : "");
                    break;
                default:
                    if(Duration > 1)
                        sb.Append(ConvertSingleNumber(Duration));
                    Num = Division / 10 * 10;
                    switch(Division - Num) {
                        case 1:
                            sb.AppendFormat("{0}first{1}", ConvertSingleNumber(Num), Duration > 1 ? "s" : "");
                            break;
                        case 2:
                            sb.AppendFormat("{0}second{1}", ConvertSingleNumber(Num), Duration > 1 ? "s" : "");
                            break;
                        case 3:
                            sb.AppendFormat("{0}third{1}", ConvertSingleNumber(Num), Duration > 1 ? "s" : "");
                            break;
                        case 8:
                            sb.AppendFormat("{0}h{1}", ConvertSingleNumber(Division), Duration > 1 ? "s" : "");
                            break;
                        default:
                            sb.AppendFormat("{0}th{1}", ConvertSingleNumber(Division), Duration > 1 ? "s" : "");
                            break;
                    }
                    break;
            }
            return sb.ToString();
        }

        public static string ConvertBeat(int Duration, int Division) {
            Simplyfied(ref Duration, ref Division);
            if(Duration >= Division && (Duration % Division == 0))
                return (Duration / Division).ToString();
            else if(ConvertFractions)
                return ConvertFraction(Duration, Division);
            else if(Duration / Division > 0)
                return string.Format("{0} {1}/{2}", Duration / Division, Duration % Division, Division);
            else
                return string.Format("{0}/{1}", Duration, Division);
        }

        public static string ConvertLyric(string Syl, string Text) {
            switch(Syl) {
                case "begin": return Text + "-";
                case "middle": return "-" + Text + "-";
                case "end": return "-" + Text;
                default: return Text;
            }
        }

        public static string GetNotations(XmlNode Node) {
            List<string> Res = new List<string>();
            foreach(XmlNode n in Node.ChildNodes) {
                switch(n.LocalName) {
                    case "tuplet":
                    case "tie":
                    case "tied":
                        continue;
                    case "fingering":
                        _Cache.Add(Line.Create("Finger {0}", n.InnerText));
                        break;
                    case "articulations":
                    case "technical":
                        var r = GetNotations(n);
                        if(r.IsNotNullAndNotEmpty())
                            Res.Add(r);
                        break;
                    default:
                        Res.Add(n.LocalName);
                        break;
                }
            }
            return string.Join(" ", Res.ToArray());
        }

        private static string ParseNote(XmlNode CurNode, int Division, int MeasureID, string Word) {
            var Node = CurNode.SelectSingleNode("pitch");
            string Res = null;
            if(Node != null) {
                StringBuilder res = new StringBuilder();
                XmlNode n = null;
                XmlNode Tie = CurNode.SelectSingleNode("tie");
                //if (ShowTie && Tie != null && (Tie.Attributes["type"]?.Value ?? "") == "start") {
                //    //WriteString("Tie {0} beats", ConvertBeat(_BeatsSum, Division));
                //}
                string Notations = null;
                if(ShowNotations) {
                    n = CurNode.SelectSingleNode("notations");
                    if(n != null) {
                        Notations = GetNotations(n);
                        var Tp = n.SelectSingleNode("tuplet");
                        if(Tp != null) {
                            if(Tp.Attributes["type"].Value == "start")
                                res.Append("Triplet\r\n\r\n");
                        }
                    }
                }
                n = CurNode.SelectSingleNode("duration");
                if(n == null)
                    throw new Exception("Duration is not present. Measure number " + MeasureID);
                n = Node.SelectSingleNode("step");
                if(n == null)
                    throw new Exception("Step is not present. Measure number " + MeasureID);
                var step = n.InnerText;
                var Dur = CurNode.SelectSingleNode("duration").InnerText.ToInt();
                res.AppendFormat("{0} beat {1}", ConvertBeat(Dur, Division), step);
                n = Node.SelectSingleNode("alter");
                if(n != null)
                    res.AppendFormat(" {0}", ConvertAlter(n.InnerText));
                if(ShowOctave) {
                    n = Node.SelectSingleNode("octave");
                    if(n != null)
                        res.AppendFormat(" {0}", n.InnerText);
                }
                if(ShowWords && Word != null)
                    res.AppendFormat(" {0}", Word);
                if(ShowNotations && (!Notations.IsNullOrEmpty()))
                    res.AppendFormat(" {0}", Notations);
                Res = res.ToString();
            } else if(CurNode.SelectSingleNode("rest") != null) {
                WriteString("{0} beat rest", ConvertBeat(CurNode.SelectSingleNode("duration").InnerText.ToInt(), Division));
            } else
                throw new Exception("Incorrect body for tag 'note'. Measure number " + MeasureID.ToString());
            Node = CurNode.SelectSingleNode("lyric");
            if(ShowLyric && Node != null) {
                var n = Node.SelectSingleNode("syllabic");
                if(n == null)
                    throw new Exception("Can't find syllabic for lyric. MeasureID: " + MeasureID.ToString());
                var Syl = n.InnerText;
                n = Node.SelectSingleNode("text");
                var Text = n.InnerText;
                if(n == null || Text.IsNullOrEmpty())
                    throw new Exception("Can't find text for lyric. MeasureID" + MeasureID.ToString());
                WriteString("Lyric");
                WriteString(ConvertLyric(Syl, Text));
            }
            return Res;
        }

        private static void ParseBarline(XmlNode CurNode, int MeasureID, ref int RepeatId) {
            //string Res = "";
            if(ShowBarLine) {
                var Node = CurNode.SelectSingleNode("bar-style");
                if((Node?.InnerText ?? "") == "light-light")
                    _Cache.Add(Line.Create("Barline new section"));
            }
            if(ShowRepeats) {
                var Node = CurNode.SelectSingleNode("ending");
                string EndType = null;
                string EndNumber = null;
                if(Node != null) {
                    EndType = Node.Attributes["type"].Value;
                    EndNumber = Node.Attributes["number"].Value;
                }
                Node = CurNode.SelectSingleNode("repeat");
                if(Node != null) {
                    if(Node.Attributes["direction"].Value == "backward") {
                        _Cache.Add(Line.Create("REPEAT Back to measure {0}", _LastRepeatID));
                        _LastRepeatID = 0;
                    } else if(Node.Attributes["direction"].Value == "forward")
                        _LastRepeatID = MeasureID;
                }
                //if (EndType != null) {
                //    if (EndNumber == null)
                //        WriteString("Repeat {0}", EndType);
                //    else
                //        WriteString("Repeat {0} {1}", EndType, EndNumber);
                //}
            }
        }

        private static string ParseWord(XmlNode CurNode) {
            var Node = CurNode.SelectSingleNode("direction-type");
            if(Node != null) {
                Node = Node.SelectSingleNode("words");
                if(Node != null)
                    return Node.InnerText;
            }
            return null;
        }

        private static void ParseTranspose(XmlElement el) {
            var Node = el.SelectSingleNode("/transpose");
            if(Node == null) {
                Node = el.SelectSingleNode("/score-partwise/transpose");
                if(Node == null)
                    return;
            }
            var Dia = Node.SelectSingleNode("diatonic")?.InnerText.ToInt(0) ?? 0;
            if(Dia == 0)
                return;
            WriteString("Transpose {0} {1}", Dia < 0 ? "down" : "up", Dia.Abs());
        }

        private static void ParseCopyrigths(XmlElement el, StreamWriter sw) {
            var Node = el.SelectSingleNode("/score-partwise/identification/rights");
            if(Node == null)
                return;
            string res = Node.InnerText;
            res = res.Replace("Copyright ", "");
            res = res.Replace("© ", "");
            res = res.Replace("©", "");
            WriteString("COPYRIGHT {0}", res);
        }

        public static void Parse() {
            XmlDocument MainXMLSource = _Prev;
            if(MainXMLSource == null || InputPath != _PrevPath) {
                MainXMLSource = new XmlDocument();
                MainXMLSource.Load(InputPath);
                _PrevPath = InputPath;
                _Prev = MainXMLSource;
            }
            Encoding enc = GetEncoding();
            Dictionary<string, string> PartName = null;
            using(_Writer = new StreamWriter(OutputPath, false, enc)) {
                if(ShowComposer || ShowTitle)
                    FindBeginData(MainXMLSource.DocumentElement);
                if(ShowPartName)
                    PartName = GetParts(MainXMLSource.DocumentElement);
                Note.Division = -1;
                int RepeatId = -1;
                foreach(XmlNode v in MainXMLSource.SelectNodes("/score-partwise/part")) {
                    if(ShowPartName) {
                        var Part = PartName[v.Attributes["id"].Value];
                        if(Part.IsNotNullAndNotEmpty())
                            WriteString("Part {0}", Part);
                    }
                    if(ShowPartInstrument) {
                        var Part = v.SelectSingleNode("part-name");
                        if(Part != null) {
                            var res = Part.InnerText;
                            if(res.IsNotNullAndNotEmpty())
                                WriteString("Instrument {0}", res);
                        }
                    }
                    Tie LastTie = null;
                    _Cache.Clear();
                    foreach(XmlNode MeasureNode in v.SelectNodes("measure")) {
                        MeasureID = MeasureNode.Attributes["number"].Value.ToInt();
                        // Measure number
                        if(ShowMeasure)
                            _Cache.Add(Line.Create("Measure {0}", MeasureID));
                        // Div dont print
                        var DivBuf = MeasureNode.SelectSingleNode("attributes/divisions")?.InnerText.ToInt(-1) ?? -1;
                        if(DivBuf > 0)
                            Note.Division = DivBuf;
                        if(Note.Division < 1)
                            throw new Exception("Division was not found.");
                        bool Chord = false;
                        foreach(XmlNode CurNode in MeasureNode.ChildNodes) {
                            switch(CurNode.Name) {
                                case "attributes":
                                    if(ShowClef || ShowTimeSignature || ShowKeys)
                                        ParseAttribute(CurNode);
                                    break;
                                case "note":
                                    if(ShowNotes) {
                                        var CurNote = new Note(CurNode);
                                        var n = CurNode.SelectSingleNode("chord");
                                        if(n != null) {
                                            if(!Chord) {
                                                Chord = true;
                                                (_Cache[_Cache.Count - 1] as Note)?.SetChord(RangeType.Start);
                                            }
                                        } else if(Chord) {
                                            Chord = false;
                                            (_Cache[_Cache.Count - 1] as Note)?.SetChord(RangeType.Stop);
                                        }
                                        if(CurNote.Tie == RangeType.Start) {
                                            if(LastTie == null) {
                                                LastTie = new Tie();
                                                _Cache.Add(LastTie);
                                            }
                                        }
                                        LastTie?.Add(CurNote.Duration, Note.Division);
                                        if(CurNote.Tie == RangeType.Stop)
                                            LastTie = null;
                                        if(LastTie != null && CurNote.Tie != RangeType.Start)
                                            CurNote.Tie = RangeType.Between;
                                        _Cache.Add(CurNote);
                                    }
                                    break;
                                case "direction":
                                    if(ShowWords) {
                                        var Word = ParseWord(CurNode);
                                        if(Word == ")" && ShowNotes) {
                                            //_Cache.Add(new InvisibleLine(InvisibleLine.IDSpicatto));
                                            var buf = _Cache.GetLast() as Note;
                                            if(buf != null)
                                                buf.Addition = "spicatto";
                                        } else if(Word != null)
                                            _Cache.Add(Line.Create("Word {0}", Word));
                                    }
                                    break;
                                case "barline":
                                    if(ShowBarLine || ShowRepeats) {
                                        ParseBarline(CurNode, MeasureID, ref RepeatId);
                                    }
                                    break;
                            }
                        }
                    }
                    foreach(var il in _Cache)
                        il.Print();
                }
                //
                //END
                //
                WriteString("END");
                if(ShowCopyrigths)
                    ParseCopyrigths(MainXMLSource.DocumentElement, _Writer);
                //WriteString("Piranha Touch Aural Visual\r\nCopyright {0} by Stave Breakthrough", DateTime.Now.Year.ToString());
                //WriteString("www.stavebreakthrough.com");
            }
        }
    }
}
