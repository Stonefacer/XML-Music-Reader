using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using Ext.System.Core;

using LibMain;

namespace XML_Music_Reader {
    public partial class Form1 : Form {

        private BackgroundWorker bw = new BackgroundWorker();

        public Form1() {
            InitializeComponent();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            btnBrowseInput.Enabled = true;
            grbSettings.Enabled = true;
            btnProcess.Enabled = true;
            string res = "Done";
            if (e.Error != null) {
                var ExType = e.Error.GetType().ToString();
                switch (ExType) {
                    case "System.IO.FileNotFoundException":
                        MessageBox.Show("Can't find or open XML file.");
                        break;
                    default:
                        res = e.Error.GetType().ToString() + ":" + e.Error.Message;
                        break;
                }
            }
            lblState.Text = res;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            Parser.Parse();
        }

        private void button1_Click(object sender, EventArgs e) {
            btnBrowseInput.Enabled = false;
            grbSettings.Enabled = false;
            lblState.Text = "Working...";
            Parser.ShowBarLine = chbBarline.Checked;
            Parser.ShowOctave = chbOctave.Checked;
            Parser.ShowClef = chbClef.Checked;
            Parser.ShowPartName = chbShowPartName.Checked;
            Parser.ShowMeasure = chbMeasure.Checked;
            Parser.ShowTimeSignature = chbTimeSignature.Checked;
            Parser.ShowTextBox = chbTextBox.Checked;
            Parser.ShowRepeats = chbRepeats.Checked;
            Parser.ShowComposer = chbComposer.Checked;
            Parser.ShowTitle = chbTitle.Checked;
            Parser.ShowWords = chbWords.Checked;
            Parser.ShowTie = chbTie.Checked;
            Parser.ShowLyric = chbLyric.Checked;
            Parser.ShowNotes = chbNotes.Checked;
            Parser.ConvertFractions = chbConvertFractions.Checked;
            Parser.ShowTranspose = chbTranspose.Checked;
            Parser.ShowCopyrigths = chbCopyrigths.Checked;
            Parser.ShowNotations = chbNotation.Checked;
            Parser.ShowKeys = chbKeys.Checked;
            Parser.ShowPartInstrument = chbPartInstrument.Checked;
            Parser.InputPath = txtInputPath.Text;
            Parser.OutputPath = txtOutputPath.Text;
            Parser.OnNewStringAdded = (Action<string>)((string str) => {
                this.Invoke((Action)(() => {
                    txtPreview.AppendText(str);
                    txtPreview.AppendText("\r\n\r\n");
                }));
            });
            txtPreview.Text = "";
            btnProcess.Enabled = false;
            bw.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e) {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            Parser.EncodingID = comboBox1.SelectedIndex;
        }

        private void btnBrowseInput_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog() {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "XML file|*.xml|All files|*",
                FilterIndex = 0,
                Multiselect = false
            };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            txtInputPath.Text = ofd.FileName;
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog() {
                AddExtension = true,
                CheckPathExists = true,
                Filter = "Text file|*.txt"
            };
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            txtOutputPath.Text = sfd.FileName;
        }

        private void chbTie_CheckedChanged(object sender, EventArgs e) {
            //if (chbTie.Checked) {
            //    MessageBox.Show("Does not implemeted!");
            //    chbTie.Checked = false;
            //}
        }

        private void chbKeys_CheckedChanged(object sender, EventArgs e) {

        }
    }
}
