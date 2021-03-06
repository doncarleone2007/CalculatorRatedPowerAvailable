using CalculatorRatedPowerAvailable.Logics.Models;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CalculatorRatedPowerAvailable
{
    public partial class ResultForm : Form
    {
        public Calculate Result { get; set; }
        public ResultForm()
        {
            InitializeComponent();

            this.Load += ResultForm_Load;
        }

        private void BtnDownloadDocumentationPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save PDF Files";
            //saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                Section section = doc.AddSection();
                Paragraph Para = section.AddParagraph();
                Para.AppendRTF(richTextBoxResultDocument.Rtf);

                doc.SaveToFile(saveFileDialog1.FileName, FileFormat.PDF);
                //Convert to PDF
                //document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Создан результат расчёта в PDF файле", "Выполнен процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doc.Close();

                try
                {
                    Process.Start(saveFileDialog1.FileName);
                }
                catch
                {
                }
            }
        }

        private void BtnDownloadCalculatePDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save PDF Files";
            //saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                Section section = doc.AddSection();
                Paragraph Para = section.AddParagraph();
                Para.AppendRTF(richTextBoxResultCalculate.Rtf);

                doc.SaveToFile(saveFileDialog1.FileName, FileFormat.PDF);
                //Convert to PDF
                //document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Создан результат расчёта в PDF файле", "Выполнен процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doc.Close();

                try
                {
                    Process.Start(saveFileDialog1.FileName);
                }
                catch
                {
                }
            }
        }

        private void BtnDownloadDocumentationWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save Word Files";
            //saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "docx";
            saveFileDialog1.Filter = "Word files (*.docx)|*.docx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                Section section = doc.AddSection();
                Paragraph Para = section.AddParagraph();
                Para.AppendRTF(richTextBoxResultDocument.Rtf);

                doc.SaveToFile(saveFileDialog1.FileName, FileFormat.Docx);
                //Convert to PDF
                //document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Создан результат расчёта в Word файле", "Выполнен процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doc.Close();

                try
                {
                    Process.Start(saveFileDialog1.FileName);
                }
                catch
                {
                }
            }
        }

        private void BtnDownloadCalculateWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save Word Files";
            //saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "docx";
            saveFileDialog1.Filter = "Word files (*.docx)|*.docx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                Section section = doc.AddSection();
                Paragraph Para = section.AddParagraph();
                Para.AppendRTF(richTextBoxResultCalculate.Rtf);

                doc.SaveToFile(saveFileDialog1.FileName, FileFormat.Docx);
                //Convert to PDF
                //document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Создан результат расчёта в Word файле", "Выполнен процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doc.Close();

                try
                {
                    Process.Start(saveFileDialog1.FileName);
                }
                catch
                {
                }
            }
        }

        Dictionary<string, string> GetReplaceResultDictionary()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();

            replaceDict.Add("#grsname#", Result.GrsName.ToUpperInvariant().ToString());
            replaceDict.Add("#subgrsname#", Result.SubGrsName.ToUpperInvariant().ToString());
            replaceDict.Add("#msm#", Result.Msantimeter.ToString());
            replaceDict.Add("#bigr#", Result.R.ToString());
            replaceDict.Add("#smallk#", Result.K.ToString());
            replaceDict.Add("#had#", Result.Had.ToString());
            replaceDict.Add("#psm#", Result.Psantimeter.ToString());
            replaceDict.Add("#bigg#", Result.G.ToString());
            replaceDict.Add("#ndga#", Result.Ndga.ToString());


            return replaceDict;
        }

        public ResultForm(Calculate model)
        {
            InitializeComponent();

            Result = model;

            lbMsm.Text = Result.Msantimeter.ToString();
            lbR.Text = Result.R.ToString();
            lbSmallK.Text = Result.K.ToString();
            lbSmallKComment.Text = Result.IsCalculateK ? "Расчитана в программе" : string.Empty;
            lbHad.Text = Result.Had.ToString();
            lbPsm.Text = Result.Psantimeter.ToString();
            lbG.Text = Result.G.ToString();
            lbNdga.Text = Result.Ndga.ToString();
            if (model.Nnominal > 0m || model.EffectProcent > 0m)
            {
                lbResultEffectivity.Text = Result.IsEffectCalculate ? "Эффективный расчёт" : "Неэффективный расчёт";
                lbResultEffectivity.ForeColor = Result.IsEffectCalculate ? Color.Green : Color.Red;
            }
            else
                lbResultEffectivity.Visible = false;


            this.Load += ResultForm_Load;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            picBoxMsm.Visible = !Result.IsPsantimeter;
            picBoxMsmWithPsm.Visible = Result.IsPsantimeter;

            SetRtfToRichtextBoxResultCalculate();
            SetRtfToRichtextBoxResultDocument();

            SetRtfToRichtextBoxResultCalculate97();
            SetRtfToRichtextBoxResultDocument97();

            btnClose.Click += BtnClose_Click;
            btnDownloadCalculateWord.Click += BtnDownloadCalculateWord_Click;
            btnDownloadDocumentationWord.Click += BtnDownloadDocumentationWord_Click;

            btnDownloadCalculateWord97.Click += BtnDownloadCalculateWord97_Click;
            btnDownloadDocumentationWord97.Click += BtnDownloadDocumentationWord97_Click;

            btnDownloadCalculatePDF.Click += BtnDownloadCalculatePDF_Click;
            btnDownloadDocumentationPDF.Click += BtnDownloadDocumentationPDF_Click;
        }

        private void BtnDownloadDocumentationWord97_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save Word Files";
            //saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "doc";
            saveFileDialog1.Filter = "Word 97-2003 Documents (*.doc)|*.doc";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                Section section = doc.AddSection();
                Paragraph Para = section.AddParagraph();
                Para.AppendRTF(richTextBox97Document.Rtf);

                doc.SaveToFile(saveFileDialog1.FileName, FileFormat.Docx);
                //Convert to PDF
                //document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Создан результат расчёта в Word файле", "Выполнен процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doc.Close();

                try
                {
                    Process.Start(saveFileDialog1.FileName);
                }
                catch
                {
                }
            }
        }

        private void BtnDownloadCalculateWord97_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save Word Files";
            //saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.OverwritePrompt = true;
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "doc";
            saveFileDialog1.Filter = "Word 97-2003 Documents (*.doc)|*.doc";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document();
                Section section = doc.AddSection();
                Paragraph Para = section.AddParagraph();
                Para.AppendRTF(richTextBox97Calculate.Rtf);

                doc.SaveToFile(saveFileDialog1.FileName, FileFormat.Docx);
                //Convert to PDF
                //document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Создан результат расчёта в Word файле", "Выполнен процесс", MessageBoxButtons.OK, MessageBoxIcon.Information);
                doc.Close();

                try
                {
                    Process.Start(saveFileDialog1.FileName);
                }
                catch
                {
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetRtfToRichtextBoxResultCalculate()
        {
            var document = new Document();
            document.LoadRtf(Path.Combine(Environment.CurrentDirectory, Result.IsPsantimeter ? "calculateWithPSmTemplate.rtf" : "calculateTemplate.rtf"));
            
            Dictionary<string, string> dictReplace = GetReplaceResultDictionary();
            dictReplace.Add("#smallkcomment#", Result.IsCalculateK ? "рассчитанное значение" : string.Empty);

            
            foreach (KeyValuePair<string, string> kvp in dictReplace)
            {
                document.Replace(kvp.Key, kvp.Value, true, true);
            }

            document.SaveToFile(Path.Combine(Environment.CurrentDirectory, $"resultCalculate.rtf"), FileFormat.Rtf);
            document.Close();

            richTextBoxResultCalculate.LoadFile(Path.Combine(Environment.CurrentDirectory, $"resultCalculate.rtf"));
        }

        private void SetRtfToRichtextBoxResultDocument()
        {
            var document = new Document();
            document.LoadRtf(Path.Combine(Environment.CurrentDirectory, Result.IsPsantimeter ? "documentPsmTemplate.rtf" : "documentTemplate.rtf"));
            //get strings to replace
            Dictionary<string, string> dictReplace = GetReplaceResultDictionary();
            dictReplace.Add("#v1#", Result.V1.ToString());
            dictReplace.Add("#v2#", Result.V2.ToString());
            dictReplace.Add("#v3#", Result.V3.ToString());
            dictReplace.Add("#v4#", Result.V4.ToString());
            dictReplace.Add("#v5#", Result.V5.ToString());
            dictReplace.Add("#v6#", Result.V6.ToString());
            dictReplace.Add("#v7#", Result.V7.ToString());
            dictReplace.Add("#v8#", Result.V8.ToString());
            dictReplace.Add("#v9#", Result.V9.ToString());
            dictReplace.Add("#v10#", Result.V10.ToString());
            dictReplace.Add("#v11#", Result.V11.ToString());

            //Replace text
            foreach (KeyValuePair<string, string> kvp in dictReplace)
            {
                document.Replace(kvp.Key, kvp.Value, true, true);
            }

            document.SaveToFile(Path.Combine(Environment.CurrentDirectory, $"resultDocument.rtf"), FileFormat.Rtf);
            document.Close();

            richTextBoxResultDocument.LoadFile(Path.Combine(Environment.CurrentDirectory, $"resultDocument.rtf"));
        }

        private void SetRtfToRichtextBoxResultCalculate97()
        {
            var document = new Document();
            document.LoadRtf(Path.Combine(Environment.CurrentDirectory, Result.IsPsantimeter ? "calculateWithPSmTemplate97.rtf" : "calculateTemplate97.rtf"));

            Dictionary<string, string> dictReplace = GetReplaceResultDictionary();
            dictReplace.Add("#smallkcomment#", Result.IsCalculateK ? "рассчитанное значение" : string.Empty);


            foreach (KeyValuePair<string, string> kvp in dictReplace)
            {
                document.Replace(kvp.Key, kvp.Value, true, true);
            }

            document.SaveToFile(Path.Combine(Environment.CurrentDirectory, $"resultCalculate97.rtf"), FileFormat.Rtf);
            document.Close();

            richTextBox97Calculate.LoadFile(Path.Combine(Environment.CurrentDirectory, $"resultCalculate97.rtf"));
        }

        private void SetRtfToRichtextBoxResultDocument97()
        {
            var document = new Document();
            document.LoadRtf(Path.Combine(Environment.CurrentDirectory, Result.IsPsantimeter ? "documentPsmTemplate97.rtf" : "documentTemplate97.rtf"));
            //get strings to replace
            Dictionary<string, string> dictReplace = GetReplaceResultDictionary();
            dictReplace.Add("#v1#", Result.V1.ToString());
            dictReplace.Add("#v2#", Result.V2.ToString());
            dictReplace.Add("#v3#", Result.V3.ToString());
            dictReplace.Add("#v4#", Result.V4.ToString());
            dictReplace.Add("#v5#", Result.V5.ToString());
            dictReplace.Add("#v6#", Result.V6.ToString());
            dictReplace.Add("#v7#", Result.V7.ToString());
            dictReplace.Add("#v8#", Result.V8.ToString());
            dictReplace.Add("#v9#", Result.V9.ToString());
            dictReplace.Add("#v10#", Result.V10.ToString());
            dictReplace.Add("#v11#", Result.V11.ToString());

            //Replace text
            foreach (KeyValuePair<string, string> kvp in dictReplace)
            {
                document.Replace(kvp.Key, kvp.Value, true, true);
            }

            document.SaveToFile(Path.Combine(Environment.CurrentDirectory, $"resultDocument97.rtf"), FileFormat.Rtf);
            document.Close();

            richTextBox97Document.LoadFile(Path.Combine(Environment.CurrentDirectory, $"resultDocument97.rtf"));
        }
    }
}