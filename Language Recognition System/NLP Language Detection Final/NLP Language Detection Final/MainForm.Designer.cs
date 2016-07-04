namespace NLP_Language_Detection_Final
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.btn_singleLineInput = new Janus.Windows.EditControls.UIButton();
            this.editBox_sinleInput = new Janus.Windows.GridEX.EditControls.EditBox();
            this.btn_testDatafromFiles = new Janus.Windows.EditControls.UIButton();
            this.btn_TestDatafromDB = new Janus.Windows.EditControls.UIButton();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.btn_probabilityNgram = new Janus.Windows.EditControls.UIButton();
            this.btn_buildNgramfromFile = new Janus.Windows.EditControls.UIButton();
            this.btn_buildNgramfromDB = new Janus.Windows.EditControls.UIButton();
            this.btn_generateAccuracyData = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTab1
            // 
            this.uiTab1.Location = new System.Drawing.Point(0, 2);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(443, 403);
            this.uiTab1.TabIndex = 0;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1,
            this.uiTabPage2});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.btn_generateAccuracyData);
            this.uiTabPage1.Controls.Add(this.btn_singleLineInput);
            this.uiTabPage1.Controls.Add(this.editBox_sinleInput);
            this.uiTabPage1.Controls.Add(this.btn_testDatafromFiles);
            this.uiTabPage1.Controls.Add(this.btn_TestDatafromDB);
            this.uiTabPage1.Location = new System.Drawing.Point(1, 25);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(441, 377);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Test";
            // 
            // btn_singleLineInput
            // 
            this.btn_singleLineInput.Location = new System.Drawing.Point(11, 281);
            this.btn_singleLineInput.Margin = new System.Windows.Forms.Padding(4);
            this.btn_singleLineInput.Name = "btn_singleLineInput";
            this.btn_singleLineInput.Size = new System.Drawing.Size(176, 28);
            this.btn_singleLineInput.TabIndex = 9;
            this.btn_singleLineInput.Text = "Test Single INput";
            this.btn_singleLineInput.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btn_singleLineInput.Click += new System.EventHandler(this.btn_singleLineInput_Click);
            // 
            // editBox_sinleInput
            // 
            this.editBox_sinleInput.Location = new System.Drawing.Point(11, 241);
            this.editBox_sinleInput.Name = "editBox_sinleInput";
            this.editBox_sinleInput.Size = new System.Drawing.Size(420, 22);
            this.editBox_sinleInput.TabIndex = 8;
            this.editBox_sinleInput.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // btn_testDatafromFiles
            // 
            this.btn_testDatafromFiles.Location = new System.Drawing.Point(12, 93);
            this.btn_testDatafromFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btn_testDatafromFiles.Name = "btn_testDatafromFiles";
            this.btn_testDatafromFiles.Size = new System.Drawing.Size(175, 28);
            this.btn_testDatafromFiles.TabIndex = 7;
            this.btn_testDatafromFiles.Text = "Test Data from Files";
            this.btn_testDatafromFiles.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btn_testDatafromFiles.Click += new System.EventHandler(this.btn_testDatafromFiles_Click);
            // 
            // btn_TestDatafromDB
            // 
            this.btn_TestDatafromDB.Location = new System.Drawing.Point(12, 23);
            this.btn_TestDatafromDB.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TestDatafromDB.Name = "btn_TestDatafromDB";
            this.btn_TestDatafromDB.Size = new System.Drawing.Size(175, 28);
            this.btn_TestDatafromDB.TabIndex = 6;
            this.btn_TestDatafromDB.Text = "Test Data from DB";
            this.btn_TestDatafromDB.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            // 
            // uiTabPage2
            // 
            this.uiTabPage2.Controls.Add(this.btn_probabilityNgram);
            this.uiTabPage2.Controls.Add(this.btn_buildNgramfromFile);
            this.uiTabPage2.Controls.Add(this.btn_buildNgramfromDB);
            this.uiTabPage2.Location = new System.Drawing.Point(1, 25);
            this.uiTabPage2.Name = "uiTabPage2";
            this.uiTabPage2.Size = new System.Drawing.Size(441, 377);
            this.uiTabPage2.TabStop = true;
            this.uiTabPage2.Text = "Learn";
            // 
            // btn_probabilityNgram
            // 
            this.btn_probabilityNgram.Location = new System.Drawing.Point(23, 179);
            this.btn_probabilityNgram.Margin = new System.Windows.Forms.Padding(4);
            this.btn_probabilityNgram.Name = "btn_probabilityNgram";
            this.btn_probabilityNgram.Size = new System.Drawing.Size(167, 77);
            this.btn_probabilityNgram.TabIndex = 7;
            this.btn_probabilityNgram.Text = "Build Probability N-Grams  from File";
            this.btn_probabilityNgram.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btn_probabilityNgram.Click += new System.EventHandler(this.btn_probabilityNgramfromFile_Click);
            // 
            // btn_buildNgramfromFile
            // 
            this.btn_buildNgramfromFile.Location = new System.Drawing.Point(23, 91);
            this.btn_buildNgramfromFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buildNgramfromFile.Name = "btn_buildNgramfromFile";
            this.btn_buildNgramfromFile.Size = new System.Drawing.Size(167, 28);
            this.btn_buildNgramfromFile.TabIndex = 5;
            this.btn_buildNgramfromFile.Text = "Build N-Grams from File";
            this.btn_buildNgramfromFile.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btn_buildNgramfromFile.Click += new System.EventHandler(this.btn_buildNgramfromFile_Click);
            // 
            // btn_buildNgramfromDB
            // 
            this.btn_buildNgramfromDB.Location = new System.Drawing.Point(23, 29);
            this.btn_buildNgramfromDB.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buildNgramfromDB.Name = "btn_buildNgramfromDB";
            this.btn_buildNgramfromDB.Size = new System.Drawing.Size(167, 28);
            this.btn_buildNgramfromDB.TabIndex = 4;
            this.btn_buildNgramfromDB.Text = "Build N-Grams from DB";
            this.btn_buildNgramfromDB.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btn_buildNgramfromDB.Click += new System.EventHandler(this.btn_buildNgramfromDB_Click);
            // 
            // btn_generateAccuracyData
            // 
            this.btn_generateAccuracyData.Location = new System.Drawing.Point(12, 165);
            this.btn_generateAccuracyData.Margin = new System.Windows.Forms.Padding(4);
            this.btn_generateAccuracyData.Name = "btn_generateAccuracyData";
            this.btn_generateAccuracyData.Size = new System.Drawing.Size(175, 28);
            this.btn_generateAccuracyData.TabIndex = 10;
            this.btn_generateAccuracyData.Text = "Generate Accuracy Data";
            this.btn_generateAccuracyData.VisualStyle = Janus.Windows.UI.VisualStyle.Office2003;
            this.btn_generateAccuracyData.Click += new System.EventHandler(this.btn_generateAccuracyData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 403);
            this.Controls.Add(this.uiTab1);
            this.Name = "MainForm";
            this.Text = "NLP Language Detection";
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            this.uiTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.EditControls.UIButton btn_buildNgramfromFile;
        private Janus.Windows.EditControls.UIButton btn_buildNgramfromDB;
        private Janus.Windows.EditControls.UIButton btn_testDatafromFiles;
        private Janus.Windows.EditControls.UIButton btn_TestDatafromDB;
        private Janus.Windows.GridEX.EditControls.EditBox editBox_sinleInput;
        private Janus.Windows.EditControls.UIButton btn_singleLineInput;
        private Janus.Windows.EditControls.UIButton btn_probabilityNgram;
        private Janus.Windows.EditControls.UIButton btn_generateAccuracyData;
    }
}

