namespace XML_Music_Reader {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.txtInputPath = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.chbShowPartName = new System.Windows.Forms.CheckBox();
            this.chbOctave = new System.Windows.Forms.CheckBox();
            this.chbClef = new System.Windows.Forms.CheckBox();
            this.chbBarline = new System.Windows.Forms.CheckBox();
            this.grbSettings = new System.Windows.Forms.GroupBox();
            this.chbPartInstrument = new System.Windows.Forms.CheckBox();
            this.chbConvertFractions = new System.Windows.Forms.CheckBox();
            this.chbComposer = new System.Windows.Forms.CheckBox();
            this.chbTitle = new System.Windows.Forms.CheckBox();
            this.chbRepeats = new System.Windows.Forms.CheckBox();
            this.chbTextBox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chbNotes = new System.Windows.Forms.CheckBox();
            this.chbLyric = new System.Windows.Forms.CheckBox();
            this.chbTie = new System.Windows.Forms.CheckBox();
            this.chbNotation = new System.Windows.Forms.CheckBox();
            this.chbCopyrigths = new System.Windows.Forms.CheckBox();
            this.chbTranspose = new System.Windows.Forms.CheckBox();
            this.chbWords = new System.Windows.Forms.CheckBox();
            this.chbKeys = new System.Windows.Forms.CheckBox();
            this.chbTimeSignature = new System.Windows.Forms.CheckBox();
            this.chbMeasure = new System.Windows.Forms.CheckBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.grbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPreview
            // 
            this.txtPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreview.Location = new System.Drawing.Point(12, 204);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ReadOnly = true;
            this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPreview.Size = new System.Drawing.Size(638, 75);
            this.txtPreview.TabIndex = 0;
            // 
            // txtInputPath
            // 
            this.txtInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputPath.Location = new System.Drawing.Point(51, 13);
            this.txtInputPath.Name = "txtInputPath";
            this.txtInputPath.Size = new System.Drawing.Size(500, 20);
            this.txtInputPath.TabIndex = 1;
            this.txtInputPath.Text = "music.xml";
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseInput.Location = new System.Drawing.Point(557, 10);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInput.TabIndex = 2;
            this.btnBrowseInput.Text = "browse";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputPath.Location = new System.Drawing.Point(51, 39);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.ReadOnly = true;
            this.txtOutputPath.Size = new System.Drawing.Size(408, 20);
            this.txtOutputPath.TabIndex = 4;
            this.txtOutputPath.Text = "result.txt";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Location = new System.Drawing.Point(557, 37);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutput.TabIndex = 6;
            this.btnBrowseOutput.Text = "browse";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // chbShowPartName
            // 
            this.chbShowPartName.AutoSize = true;
            this.chbShowPartName.Checked = true;
            this.chbShowPartName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowPartName.Location = new System.Drawing.Point(51, 65);
            this.chbShowPartName.Name = "chbShowPartName";
            this.chbShowPartName.Size = new System.Drawing.Size(103, 17);
            this.chbShowPartName.TabIndex = 7;
            this.chbShowPartName.Text = "Show part name";
            this.chbShowPartName.UseVisualStyleBackColor = true;
            // 
            // chbOctave
            // 
            this.chbOctave.AutoSize = true;
            this.chbOctave.Checked = true;
            this.chbOctave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOctave.Location = new System.Drawing.Point(161, 65);
            this.chbOctave.Name = "chbOctave";
            this.chbOctave.Size = new System.Drawing.Size(89, 17);
            this.chbOctave.TabIndex = 7;
            this.chbOctave.Text = "Show octave";
            this.chbOctave.UseVisualStyleBackColor = true;
            // 
            // chbClef
            // 
            this.chbClef.AutoSize = true;
            this.chbClef.Checked = true;
            this.chbClef.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbClef.Location = new System.Drawing.Point(274, 65);
            this.chbClef.Name = "chbClef";
            this.chbClef.Size = new System.Drawing.Size(73, 17);
            this.chbClef.TabIndex = 8;
            this.chbClef.Text = "Show clef";
            this.chbClef.UseVisualStyleBackColor = true;
            // 
            // chbBarline
            // 
            this.chbBarline.AutoSize = true;
            this.chbBarline.Checked = true;
            this.chbBarline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbBarline.Location = new System.Drawing.Point(359, 65);
            this.chbBarline.Name = "chbBarline";
            this.chbBarline.Size = new System.Drawing.Size(88, 17);
            this.chbBarline.TabIndex = 9;
            this.chbBarline.Text = "Show Barline";
            this.chbBarline.UseVisualStyleBackColor = true;
            // 
            // grbSettings
            // 
            this.grbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSettings.Controls.Add(this.chbPartInstrument);
            this.grbSettings.Controls.Add(this.chbConvertFractions);
            this.grbSettings.Controls.Add(this.chbComposer);
            this.grbSettings.Controls.Add(this.chbTitle);
            this.grbSettings.Controls.Add(this.chbRepeats);
            this.grbSettings.Controls.Add(this.chbTextBox);
            this.grbSettings.Controls.Add(this.comboBox1);
            this.grbSettings.Controls.Add(this.chbNotes);
            this.grbSettings.Controls.Add(this.chbLyric);
            this.grbSettings.Controls.Add(this.chbTie);
            this.grbSettings.Controls.Add(this.chbNotation);
            this.grbSettings.Controls.Add(this.chbCopyrigths);
            this.grbSettings.Controls.Add(this.chbTranspose);
            this.grbSettings.Controls.Add(this.chbWords);
            this.grbSettings.Controls.Add(this.chbKeys);
            this.grbSettings.Controls.Add(this.chbTimeSignature);
            this.grbSettings.Controls.Add(this.chbMeasure);
            this.grbSettings.Controls.Add(this.label1);
            this.grbSettings.Controls.Add(this.chbBarline);
            this.grbSettings.Controls.Add(this.txtInputPath);
            this.grbSettings.Controls.Add(this.chbClef);
            this.grbSettings.Controls.Add(this.btnBrowseInput);
            this.grbSettings.Controls.Add(this.chbOctave);
            this.grbSettings.Controls.Add(this.chbShowPartName);
            this.grbSettings.Controls.Add(this.label2);
            this.grbSettings.Controls.Add(this.txtOutputPath);
            this.grbSettings.Controls.Add(this.btnBrowseOutput);
            this.grbSettings.Location = new System.Drawing.Point(12, 12);
            this.grbSettings.Name = "grbSettings";
            this.grbSettings.Size = new System.Drawing.Size(638, 157);
            this.grbSettings.TabIndex = 10;
            this.grbSettings.TabStop = false;
            this.grbSettings.Text = "Settings";
            // 
            // chbPartInstrument
            // 
            this.chbPartInstrument.AutoSize = true;
            this.chbPartInstrument.Checked = true;
            this.chbPartInstrument.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPartInstrument.Location = new System.Drawing.Point(467, 134);
            this.chbPartInstrument.Name = "chbPartInstrument";
            this.chbPartInstrument.Size = new System.Drawing.Size(125, 17);
            this.chbPartInstrument.TabIndex = 17;
            this.chbPartInstrument.Text = "Show part instrument";
            this.chbPartInstrument.UseVisualStyleBackColor = true;
            // 
            // chbConvertFractions
            // 
            this.chbConvertFractions.AutoSize = true;
            this.chbConvertFractions.Location = new System.Drawing.Point(51, 134);
            this.chbConvertFractions.Name = "chbConvertFractions";
            this.chbConvertFractions.Size = new System.Drawing.Size(106, 17);
            this.chbConvertFractions.TabIndex = 16;
            this.chbConvertFractions.Text = "Convert fractions";
            this.chbConvertFractions.UseVisualStyleBackColor = true;
            // 
            // chbComposer
            // 
            this.chbComposer.AutoSize = true;
            this.chbComposer.Checked = true;
            this.chbComposer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbComposer.Location = new System.Drawing.Point(359, 88);
            this.chbComposer.Name = "chbComposer";
            this.chbComposer.Size = new System.Drawing.Size(102, 17);
            this.chbComposer.TabIndex = 15;
            this.chbComposer.Text = "Show composer";
            this.chbComposer.UseVisualStyleBackColor = true;
            // 
            // chbTitle
            // 
            this.chbTitle.AutoSize = true;
            this.chbTitle.Checked = true;
            this.chbTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTitle.Location = new System.Drawing.Point(274, 88);
            this.chbTitle.Name = "chbTitle";
            this.chbTitle.Size = new System.Drawing.Size(72, 17);
            this.chbTitle.TabIndex = 15;
            this.chbTitle.Text = "Show title";
            this.chbTitle.UseVisualStyleBackColor = true;
            // 
            // chbRepeats
            // 
            this.chbRepeats.AutoSize = true;
            this.chbRepeats.Checked = true;
            this.chbRepeats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRepeats.Location = new System.Drawing.Point(161, 88);
            this.chbRepeats.Name = "chbRepeats";
            this.chbRepeats.Size = new System.Drawing.Size(91, 17);
            this.chbRepeats.TabIndex = 14;
            this.chbRepeats.Text = "Show repeats";
            this.chbRepeats.UseVisualStyleBackColor = true;
            // 
            // chbTextBox
            // 
            this.chbTextBox.AutoSize = true;
            this.chbTextBox.Checked = true;
            this.chbTextBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTextBox.Location = new System.Drawing.Point(467, 88);
            this.chbTextBox.Name = "chbTextBox";
            this.chbTextBox.Size = new System.Drawing.Size(165, 17);
            this.chbTextBox.TabIndex = 13;
            this.chbTextBox.Text = "Show output in textbox below";
            this.chbTextBox.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ASCII",
            "UTF8"});
            this.comboBox1.Location = new System.Drawing.Point(464, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chbNotes
            // 
            this.chbNotes.AutoSize = true;
            this.chbNotes.Checked = true;
            this.chbNotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbNotes.Location = new System.Drawing.Point(467, 111);
            this.chbNotes.Name = "chbNotes";
            this.chbNotes.Size = new System.Drawing.Size(82, 17);
            this.chbNotes.TabIndex = 11;
            this.chbNotes.Text = "Show notes";
            this.chbNotes.UseVisualStyleBackColor = true;
            // 
            // chbLyric
            // 
            this.chbLyric.AutoSize = true;
            this.chbLyric.Checked = true;
            this.chbLyric.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbLyric.Location = new System.Drawing.Point(359, 111);
            this.chbLyric.Name = "chbLyric";
            this.chbLyric.Size = new System.Drawing.Size(79, 17);
            this.chbLyric.TabIndex = 11;
            this.chbLyric.Text = "Show lyrics";
            this.chbLyric.UseVisualStyleBackColor = true;
            // 
            // chbTie
            // 
            this.chbTie.AutoSize = true;
            this.chbTie.Checked = true;
            this.chbTie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTie.Location = new System.Drawing.Point(274, 111);
            this.chbTie.Name = "chbTie";
            this.chbTie.Size = new System.Drawing.Size(67, 17);
            this.chbTie.TabIndex = 11;
            this.chbTie.Text = "Show tie";
            this.chbTie.UseVisualStyleBackColor = true;
            this.chbTie.CheckedChanged += new System.EventHandler(this.chbTie_CheckedChanged);
            // 
            // chbNotation
            // 
            this.chbNotation.AutoSize = true;
            this.chbNotation.Checked = true;
            this.chbNotation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbNotation.Location = new System.Drawing.Point(359, 134);
            this.chbNotation.Name = "chbNotation";
            this.chbNotation.Size = new System.Drawing.Size(99, 17);
            this.chbNotation.TabIndex = 11;
            this.chbNotation.Text = "Show notations";
            this.chbNotation.UseVisualStyleBackColor = true;
            // 
            // chbCopyrigths
            // 
            this.chbCopyrigths.AutoSize = true;
            this.chbCopyrigths.Checked = true;
            this.chbCopyrigths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCopyrigths.Location = new System.Drawing.Point(274, 134);
            this.chbCopyrigths.Name = "chbCopyrigths";
            this.chbCopyrigths.Size = new System.Drawing.Size(81, 17);
            this.chbCopyrigths.TabIndex = 11;
            this.chbCopyrigths.Text = "Show rights";
            this.chbCopyrigths.UseVisualStyleBackColor = true;
            // 
            // chbTranspose
            // 
            this.chbTranspose.AutoSize = true;
            this.chbTranspose.Checked = true;
            this.chbTranspose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTranspose.Location = new System.Drawing.Point(161, 134);
            this.chbTranspose.Name = "chbTranspose";
            this.chbTranspose.Size = new System.Drawing.Size(102, 17);
            this.chbTranspose.TabIndex = 11;
            this.chbTranspose.Text = "Show transpose";
            this.chbTranspose.UseVisualStyleBackColor = true;
            // 
            // chbWords
            // 
            this.chbWords.AutoSize = true;
            this.chbWords.Checked = true;
            this.chbWords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbWords.Location = new System.Drawing.Point(161, 111);
            this.chbWords.Name = "chbWords";
            this.chbWords.Size = new System.Drawing.Size(84, 17);
            this.chbWords.TabIndex = 11;
            this.chbWords.Text = "Show words";
            this.chbWords.UseVisualStyleBackColor = true;
            // 
            // chbKeys
            // 
            this.chbKeys.AutoSize = true;
            this.chbKeys.Checked = true;
            this.chbKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbKeys.Location = new System.Drawing.Point(51, 111);
            this.chbKeys.Name = "chbKeys";
            this.chbKeys.Size = new System.Drawing.Size(78, 17);
            this.chbKeys.TabIndex = 11;
            this.chbKeys.Text = "Show keys";
            this.chbKeys.UseVisualStyleBackColor = true;
            this.chbKeys.CheckedChanged += new System.EventHandler(this.chbKeys_CheckedChanged);
            // 
            // chbTimeSignature
            // 
            this.chbTimeSignature.AutoSize = true;
            this.chbTimeSignature.Checked = true;
            this.chbTimeSignature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTimeSignature.Location = new System.Drawing.Point(51, 88);
            this.chbTimeSignature.Name = "chbTimeSignature";
            this.chbTimeSignature.Size = new System.Drawing.Size(97, 17);
            this.chbTimeSignature.TabIndex = 11;
            this.chbTimeSignature.Text = "Time Signature";
            this.chbTimeSignature.UseVisualStyleBackColor = true;
            // 
            // chbMeasure
            // 
            this.chbMeasure.AutoSize = true;
            this.chbMeasure.Checked = true;
            this.chbMeasure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbMeasure.Location = new System.Drawing.Point(467, 65);
            this.chbMeasure.Name = "chbMeasure";
            this.chbMeasure.Size = new System.Drawing.Size(96, 17);
            this.chbMeasure.TabIndex = 10;
            this.chbMeasure.Text = "Show measure";
            this.chbMeasure.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 175);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(93, 180);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(179, 13);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "Please press button \'process\' to start";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 291);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.grbSettings);
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.btnProcess);
            this.Name = "Form1";
            this.Text = "XML Music files reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbSettings.ResumeLayout(false);
            this.grbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.TextBox txtInputPath;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.CheckBox chbShowPartName;
        private System.Windows.Forms.CheckBox chbOctave;
        private System.Windows.Forms.CheckBox chbClef;
        private System.Windows.Forms.CheckBox chbBarline;
        private System.Windows.Forms.GroupBox grbSettings;
        private System.Windows.Forms.CheckBox chbMeasure;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.CheckBox chbTimeSignature;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chbTextBox;
        private System.Windows.Forms.CheckBox chbRepeats;
        private System.Windows.Forms.CheckBox chbComposer;
        private System.Windows.Forms.CheckBox chbTitle;
        private System.Windows.Forms.CheckBox chbKeys;
        private System.Windows.Forms.CheckBox chbWords;
        private System.Windows.Forms.CheckBox chbTie;
        private System.Windows.Forms.CheckBox chbLyric;
        private System.Windows.Forms.CheckBox chbNotes;
        private System.Windows.Forms.CheckBox chbConvertFractions;
        private System.Windows.Forms.CheckBox chbTranspose;
        private System.Windows.Forms.CheckBox chbCopyrigths;
        private System.Windows.Forms.CheckBox chbNotation;
        private System.Windows.Forms.CheckBox chbPartInstrument;
    }
}

