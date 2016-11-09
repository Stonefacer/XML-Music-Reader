using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using System.Diagnostics;

using LibMain;

namespace Tests {

    [TestClass]
    public class UnitTest1 {

        private void CompareFiles(string TestResult, string Expected) {
            using (StreamReader FileResult = new StreamReader(TestResult)) {
                using (StreamReader FileExpected = new StreamReader(Expected)) {
                    var StrResult = FileResult.ReadLine();
                    var StrExpected = FileExpected.ReadLine();
                    int LineId = 1;
                    while ((!FileResult.EndOfStream) && (!FileExpected.EndOfStream)) {
                        Assert.AreEqual(StrExpected, StrResult, "Line: " + LineId.ToString());
                        StrResult = FileResult.ReadLine();
                        StrExpected = FileExpected.ReadLine();
                        LineId++;
                    }
                    Assert.IsTrue(FileResult.EndOfStream, "Test result file has more rows");
                    Assert.IsTrue(FileExpected.EndOfStream, "Expected file has have more rows");
                }
            }
        }

        [TestMethod]
        public void ParserAllCheckedTest() {
            string[] Tests = new string[] { "Test0.xml", "Test0.txt", "TestExpected0.txt" };
            Parser.ShowBarLine = true;
            Parser.ShowClef = true;
            Parser.ShowComposer = true;
            Parser.ShowPartName = true;
            Parser.ShowMeasure = true;
            Parser.ShowOctave = true;
            Parser.ShowRepeats = true;
            Parser.ShowTextBox = true;
            Parser.ShowTimeSignature = true;
            Parser.ShowTitle = true;
            Parser.ShowKeys = true;
            Parser.ShowWords = true;
            Parser.ShowTie = true;
            Parser.ShowLyric = true;
            Parser.ShowNotes = true;
            Parser.ShowTranspose = true;
            Parser.ShowCopyrigths = true;
            Parser.ShowNotations = true;
            Parser.ShowPartInstrument = true;
            Parser.InputPath = Tests[0];
            Parser.OutputPath = Tests[1];
            Parser.Parse();
            CompareFiles(Tests[1], Tests[2]);
        }

        [TestMethod]
        public void ParserDefaultTest() {
            string[] Tests = new string[] { "Test1.xml", "Test1.txt", "TestExpected1.txt" };
            Parser.ShowBarLine = false;
            Parser.ShowClef = false;
            Parser.ShowComposer = false;
            Parser.ShowPartName = false;
            Parser.ShowMeasure = false;
            Parser.ShowOctave = false;
            Parser.ShowRepeats = false;
            Parser.ShowTextBox = false;
            Parser.ShowTimeSignature = false;
            Parser.ShowTitle = false;
            Parser.ShowKeys = false;
            Parser.ShowWords = false;
            Parser.ShowTie = false;
            Parser.ShowLyric = false;
            Parser.ShowNotes = true;
            Parser.ShowPartInstrument = false;
            Parser.InputPath = Tests[0];
            Parser.OutputPath = Tests[1];
            Parser.Parse();
            CompareFiles(Tests[1], Tests[2]);
        }

        [TestMethod]
        public void ConvertBeatTest() {
            for (int i = 1; i <= 128; i++) {
                for (int j = 1; j <= 128; j++) {
                    var buf0 = i;
                    var buf1 = j;
                    Parser.Simplyfied(ref buf0, ref buf1);
                    Trace.WriteLine(string.Format("{0}/{1} => {2}", i, j, Parser.ConvertBeat(buf0, buf1)));
                }
            }
        }

        [TestMethod]
        public void ConvertFractionsTest() {
            for(int i = 1; i <= 4; i++) {
                for (int j = 2; j < 128; j <<= 1) {
                    if (i == j)
                        continue;
                    var buf0 = i;
                    var buf1 = j;
                    Parser.Simplyfied(ref buf0, ref buf1);
                    Trace.WriteLine(string.Format("{0}/{1} => {2}", i, j, Parser.ConvertFraction(buf0, buf1)));
                }
            }
        }

    }
}
