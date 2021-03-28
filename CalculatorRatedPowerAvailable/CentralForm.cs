using CalculatorRatedPowerAvailable.Extensions;
using CalculatorRatedPowerAvailable.Helper.Encrypts;
using CalculatorRatedPowerAvailable.Logics.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CalculatorRatedPowerAvailable
{
    public partial class CentralForm : Form
    {
        public string UnCorrectLicenseText { get; set; }
        public DateTime EndLicenseDate { get; set; }
        public CentralForm()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;

            toolStripMenuItem3.Click += ToolStripMenuItem3_Click;
            toolStripMenuItem2.Click += ToolStripMenuItem2_Click;

            btnClear.Click += BtnClear_Click;
            btnCalculate.Click += BtnCalculate_Click;

            txtV1.KeyPress += Value_KeyPress;
            txtV2.KeyPress += Value_KeyPress;
            txtV3.KeyPress += Value_KeyPress;
            txtV4.KeyPress += Value_KeyPress;
            txtV5.KeyPress += Value_KeyPress;
            txtV6.KeyPress += Value_KeyPress;
            txtV7.KeyPress += Value_KeyPress;
            txtV8.KeyPress += Value_KeyPress;
            txtV9.KeyPress += Value_KeyPress;
            txtV10.KeyPress += Value_KeyPress;
            txtV11.KeyPress += Value_KeyPress;
            txtZ.KeyPress += Value_KeyPress;
            txtSmallK.KeyPress += Value_KeyPress;
            txtPvxod.KeyPress += Value_KeyPress;
            txtPvixod.KeyPress += Value_KeyPress;
            txtTemperature.KeyPress += Value_KeyPress;
            txtQ.KeyPress += Value_KeyPress;
            txtNnominal.KeyPress += Value_KeyPress;
            txtPsm.KeyPress += Value_KeyPress;

            this.FormClosing += CentralForm_FormClosing;
        }

        private void CentralForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            
            if(MessageBox.Show(this, "Действительно хотите выйти?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            Application.DoEvents();

            //MessageBox msg = new MessageBox("Действительно хотите выйти?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //msg.
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutBoxForm();
            aboutForm.Show();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Действительно хотите выйти?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void CheckLicense()
        {
            var path = Path.Combine(Application.StartupPath, "license.txt");
            if (!File.Exists(path))
            {
                UnCorrectLicenseText = "Не найдена лицензия";
                return;
            }

            var license = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(license))
            {
                UnCorrectLicenseText = "Не найдена лицензия";
                return;
            }

            DateTime licenseDate;
            if (!DateTime.TryParse(EncryptHelper.Decrypt(license), out licenseDate))
            {
                UnCorrectLicenseText = "Неопознанная лицензия";
                return;
            }

            if (DateTime.Now >= licenseDate)
            {
                UnCorrectLicenseText = "Истек время лицензии";
                return;
            }

            EndLicenseDate = licenseDate;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UnCorrectLicenseText))
            {
                MessageBox.Show(UnCorrectLicenseText);
                Environment.Exit(0);
            }

            var calculate = new Calculate(txtGrsName.Text, txtSubGrsName.Text, txtPsm.Text.ToDecimal(), txtPvxod.Text.ToDecimal(), txtPvixod.Text.ToDecimal(), txtQ.Text.ToDecimal(), txtTemperature.Text.ToDecimal(),
                                          txtZ.Text.ToDecimal(), txtSmallK.Text.ToDecimal(), txtV1.Text.ToDecimal(), txtV2.Text.ToDecimal(), txtV3.Text.ToDecimal(), txtV4.Text.ToDecimal(),
                                          txtV5.Text.ToDecimal(), txtV6.Text.ToDecimal(), txtV7.Text.ToDecimal(), txtV8.Text.ToDecimal(), txtV9.Text.ToDecimal(), txtV10.Text.ToDecimal(),
                                          txtV11.Text.ToDecimal(), txtNnominal.Text.ToDecimal(), nupProcent.Value);

            var errorText = calculate.IsError();
            if (!string.IsNullOrWhiteSpace(errorText))
            {
                MessageBox.Show(errorText);
                return;
            }

            var resultForm = new ResultForm(calculate);
            resultForm.Show();
        }

        private void Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.TextBoxHandle(sender);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtGrsName.Text =
            txtSubGrsName.Text =
            txtV1.Text =
            txtV2.Text =
            txtV3.Text =
            txtV4.Text =
            txtV5.Text =
            txtV6.Text =
            txtV7.Text =
            txtV8.Text =
            txtV9.Text =
            txtV10.Text =
            txtV11.Text =
            txtZ.Text =
            txtSmallK.Text =
            txtPvxod.Text =
            txtPvixod.Text =
            txtTemperature.Text =
            txtQ.Text =
            txtPsm.Text =
            txtNnominal.Text = string.Empty;
            nupProcent.Value = 0m;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"Время: {DateTime.Now}";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CheckLicense();
            
            if(!string.IsNullOrWhiteSpace(UnCorrectLicenseText))
            {
                toolStripStatusLabel2.Text = UnCorrectLicenseText;
                toolStripStatusLabel2.ForeColor = Color.Red;
            }
            else
            {
                toolStripStatusLabel2.Text = $"Дата окончания лицензии до {EndLicenseDate.ToString("dd MMMM yyyyг. HHч. mmм.")}";
                toolStripStatusLabel2.ForeColor = Color.Black;
            }
        }
    }
}
