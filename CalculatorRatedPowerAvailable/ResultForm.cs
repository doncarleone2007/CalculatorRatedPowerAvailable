using CalculatorRatedPowerAvailable.Logics.Models;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            btnDownloadCalculateWord.Click += BtnDownloadCalculateWord_Click;
        }

        private void BtnDownloadCalculateWord_Click(object sender, EventArgs e)
        {


            //initialize word object
            var templatePath = Path.Combine(Environment.CurrentDirectory, "calculateTemplate.docx");
            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Не найден шаблон для создания расчета");
                return;
            }


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save Word Files";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "docx";
            saveFileDialog1.Filter = "Text files (*.docx)|*.docx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var document = new Document();
                document.LoadRtf(templatePath);
                //get strings to replace
                Dictionary<string, string> dictReplace = GetReplaceDictionary();
                //Replace text
                foreach (KeyValuePair<string, string> kvp in dictReplace)
                {
                    document.Replace(kvp.Key, kvp.Value, true, true);
                }
                //Save doc file.
                document.SaveToFile(Path.Combine(Environment.CurrentDirectory, $"{saveFileDialog1.FileName}.docx"), FileFormat.Docx);
                //Convert to PDF
                //document.SaveToFile(pdfPath, FileFormat.PDF);
                MessageBox.Show("Создан результат расчёта в Word файле", "doc processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                document.Close();
            }
        }

        Dictionary<string, string> GetReplaceDictionary()
        {
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            //replaceDict.Add("#msm#", Result.Msantimeter.ToString());
            //replaceDict.Add("#bigr#", Result.R.ToString());
            //replaceDict.Add("#smallk#", Result.K.ToString());
            //replaceDict.Add("#smallkcomment#", Result.IsCalculateK? "рассчитанное значение":string.Empty);
            //replaceDict.Add("#had#", Result.Had.ToString());
            //replaceDict.Add("#psm#", Result.Psantimeter.ToString());
            //replaceDict.Add("#bigg#", Result.G.ToString());
            //replaceDict.Add("#ndga#", Result.Ndga.ToString());


            replaceDict.Add("#msm#", "1233");
            replaceDict.Add("#bigr#", "123ss3");
            replaceDict.Add("#smallk#", "123gdfgd3");
            replaceDict.Add("#smallkcomment#", "рассчитанное значение");
            replaceDict.Add("#had#", "123cxcxcxcxc3");
            replaceDict.Add("#psm#", "1ppppp233");
            replaceDict.Add("#bigg#", "123GGGGGG3");
            replaceDict.Add("#ndga#", "nddndndndndnd");

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

            this.Load += ResultForm_Load;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            var document = new Document();
            document.LoadRtf(Path.Combine(Environment.CurrentDirectory, "calculateTemplate.docx"));
            //get strings to replace
            Dictionary<string, string> dictReplace = GetReplaceDictionary();
            //Replace text
            foreach (KeyValuePair<string, string> kvp in dictReplace)
            {
                document.Replace(kvp.Key, kvp.Value, true, true);
            }

            document.SaveToFile(Path.Combine(Environment.CurrentDirectory, $"resultCalculate.docx"), FileFormat.Docx);
            richTextBox1.LoadFile(Path.Combine(Environment.CurrentDirectory, $"resultCalculate.docx"));
        }
    }
}
