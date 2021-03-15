using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorRatedPowerAvailable.Extensions
{
    public static class StringExtensions
    {
        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0m;

            return Convert.ToDecimal(value);
        }
    }
}
