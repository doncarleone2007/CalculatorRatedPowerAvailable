using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorRatedPowerAvailable.Extensions
{
    public static class ParamsExtensions
    {
        public static bool CheckIntervalParams(this decimal value, decimal minValue, decimal maxValue)
        {
            if (value >= minValue && value <= maxValue)
                return true;
            return false;
        }
    }
}
