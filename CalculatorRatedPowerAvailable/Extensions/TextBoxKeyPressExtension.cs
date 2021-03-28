using System.Windows.Forms;

namespace CalculatorRatedPowerAvailable.Extensions
{
    public static class TextBoxKeyPressExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool TextBoxHandle(this KeyPressEventArgs e, object sender)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ',') && (e.KeyChar != '-'))
            {
                return true;
            }

            if ((e.KeyChar == '-') && !string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                return true;
            }

            if (e.KeyChar == '0')
            {
                //if (string.IsNullOrWhiteSpace((sender as TextBox).Text) && ((sender as TextBox).Text.Contains('0')))
                //    return true;
                if (!string.IsNullOrWhiteSpace((sender as TextBox).Text) && ((sender as TextBox).Text.Substring(0,1) == "0") && !(sender as TextBox).Text.Contains(","))
                    return true;
                //if (!string.IsNullOrWhiteSpace((sender as TextBox).Text) && (sender as TextBox).Text.IndexOf(',') == -1)
                //    return true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ','))
            {
                if (string.IsNullOrWhiteSpace((sender as TextBox).Text))
                    return true;
                if ((sender as TextBox).Text.Contains(','))
                    return true;
            }

            return false;
        }
    }
}
