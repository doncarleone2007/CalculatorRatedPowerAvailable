using AppSoftware.KatexSharpRunner;
using CalculatorRatedPowerAvailable.Extensions;
using CalculatorRatedPowerAvailable.Helper.Consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorRatedPowerAvailable.Logics.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Calculate
    {
        /// <summary>
        /// 
        /// </summary>
        public string GrsName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubGrsName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Pvxod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Pvixod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Q { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Temperature { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Z { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal K { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCalculateK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V6 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V7 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V8 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V9 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal V11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal T { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Msantimeter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Psantimeter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPsantimeter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal R { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal G { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Had { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Ndga { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Nnominal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal EffectProcent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ResultEffectProcent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEffectCalculate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pvxod"></param>
        /// <param name="Pvixod"></param>
        /// <param name="Q"></param>
        /// <param name="t"></param>
        /// <param name="z"></param>
        /// <param name="k"></param>
        /// <param name="v1"></param>
        /// <param name="V2"></param>
        /// <param name="V3"></param>
        /// <param name="v4"></param>
        /// <param name="V5"></param>
        /// <param name="V6"></param>
        /// <param name="V7"></param>
        /// <param name="V8"></param>
        /// <param name="V9"></param>
        /// <param name="V10"></param>
        /// <param name="V11"></param>
        public Calculate(string grsName, string subGrsName, decimal pSm, decimal pVxod, decimal pVixod, decimal q, decimal t, decimal z, decimal k, decimal v1, decimal v2, decimal v3, decimal v4, decimal v5, decimal v6, decimal v7, decimal v8, decimal v9, decimal v10, decimal v11, decimal nNominal, decimal effectProcent)
        {
            this.GrsName = grsName;
            this.SubGrsName = subGrsName;

            this.Pvxod = pVxod;
            this.Pvixod = pVixod;
            this.Q = q;
            this.Temperature = t;

            this.Z = z;
            this.K = k;

            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
            this.V4 = v4;
            this.V5 = v5;
            this.V6 = v6;
            this.V7 = v7;
            this.V8 = v8;
            this.V9 = v9;
            this.V10 = v10;
            this.V11 = v11;
            this.R = 0m;
            this.Psantimeter = pSm;

            this.IsPsantimeter = this.Psantimeter > 0m;

            this.Nnominal = nNominal;
            this.EffectProcent = effectProcent;
        }

        public string IsError()
        {
            if (string.IsNullOrWhiteSpace(GrsName))
                return "Укажите наименование ГРС";

            if (string.IsNullOrWhiteSpace(SubGrsName))
                return "Укажите наименование замерной нитки";

            if (Psantimeter > 0)
            {
                if (V1 + V2 + V3 + V9 + V10 + V11 > 0)
                    CalculateSmallK();
                else
                    K = SmallKConstants.KAll;
            }
            else
            {
                if (V1 != 0 && !V1.CheckIntervalParams(90m, 97.9m))
                    return "V1 параметр \"Объёмная концентрация метана\" несоответсвует";

                if (V2 != 0 && !V2.CheckIntervalParams(0.75m, 4.75m))
                    return "V2 параметр \"Объёмная концентрация этана\" несоответсвует";

                if (V3 != 0 && !V3.CheckIntervalParams(0.30m, 3.5m))
                    return "V3 параметр \"Объёмная концентрация пропана\" несоответсвует";

                if (V4 != 0 && !V4.CheckIntervalParams(0.01m, 0.5m))
                    return "V4 параметр \"Объёмная концентрация i-бутана\" несоответсвует";

                if (!V5.CheckIntervalParams(0m, 0.4m))
                    return "V5 параметр \"Объёмная концентрация n-бутана\" несоответсвует";

                if (!V6.CheckIntervalParams(0m, 0.2m))
                    return "V6 параметр \"Объёмная концентрация  i-пентана\" несоответсвует";

                if (!V7.CheckIntervalParams(0m, 0.15m))
                    return "V7 параметр \"Объёмная концентрация  n-пентана\" несоответсвует";

                if (!V8.CheckIntervalParams(0m, 0.3m))
                    return "V8 параметр \"Объёмная концентрация гексана\" несоответсвует";

                if (V9 != 0 && !V9.CheckIntervalParams(0.1m, 2.5m))
                    return "V9 параметр \"Объёмная концентрация углекислого газа\" несоответсвует";

                if (V10 != 0 && !V10.CheckIntervalParams(0.2m, 1.3m))
                    return "V10 параметр \"Объёмная концентрация азота\" несоответсвует";

                if (!V11.CheckIntervalParams(0m, 0.3m))
                    return "V11 параметр \"Объёмная концентрация кислорода\" несоответсвует";

                if (K == 0)
                {
                    CalculateSmallK();
                }
                else if (!K.CheckIntervalParams(1.24m, 2.1m))
                    return "k параметр \"Объёмный показатель адиабаты\" несоответсвует";
                else
                    this.IsCalculateK = false;
            }

            if (Z == 0)
                this.Z = 0.882m;
            else if (!Z.CheckIntervalParams(0.6m, 0.9999m))
                return "z параметр \"Коэффициент сжимаемости\" несоответсвует";

            if (!Pvxod.CheckIntervalParams(0.01m, 6m))
                return "Pвх параметр \"Давление газа на входе в ДГА\" несоответсвует";

            if (!Pvixod.CheckIntervalParams(0.01m, 4m))
                return "Pвых параметр \"Давление газа на выходе из ДГА\" несоответсвует";

            if (!Q.CheckIntervalParams(100m, 100000000m))
                return "Q параметр \"Расход газа по нитке\" несоответсвует";

            if (!Temperature.CheckIntervalParams(10m, 90m))
                return "t параметр \"Температура\" несоответсвует";

            if ((Nnominal > 0 && EffectProcent == 0) || (Nnominal == 0 && EffectProcent > 0))
                return "Укажите Nnominal и Procent, чтобы узнать эффективность расчета";

            CalculateParams();
            return string.Empty;
        }

        private void CalculateSmallK()
        {
            this.IsCalculateK = true;
            K = Math.Round((SmallKConstants.kV1 * V1 + SmallKConstants.kV2 * V2 + SmallKConstants.kV3 * V3 + SmallKConstants.kV9 * V9 + SmallKConstants.kV10 * V10 + SmallKConstants.kV11 * V11) / 100, 3);
        }

        private void CalculateParams()
        {
            this.T = Temperature + 273m;

            if(IsPsantimeter)
            {
                this.Msantimeter = Math.Round(Psantimeter * 22.4m, 3);
            }
            else
            {
                this.Msantimeter = Math.Round((V1 * MolarMassConstants.m1 + V2 * MolarMassConstants.m2 + V3 * MolarMassConstants.m3 + V4 * MolarMassConstants.m4 + V5 * MolarMassConstants.m5
                                                 + V6 * MolarMassConstants.m6 + V7 * MolarMassConstants.m7 + V8 * MolarMassConstants.m8 + V9 * MolarMassConstants.m9
                                                  + V10 * MolarMassConstants.m10 + V11 * MolarMassConstants.m11) / 100, 3);

                this.Psantimeter = Math.Round(Msantimeter / 22.4m, 3);
            }
            

            

            this.G = Math.Round((this.Q * this.Psantimeter) / 3600, 3);

            this.R = Math.Round(RConstants.R0 / this.Msantimeter, 3);

            var powResult = Math.Pow(Convert.ToDouble((this.Pvixod / this.Pvxod)), Convert.ToDouble((this.K - 1) / this.K));

            this.Had = Math.Round((K / (K - 1)) * this.Z * this.R * this.T * (1 - Convert.ToDecimal(powResult)), 3);

            this.Ndga = Math.Round(this.G * this.Had * NyuDGAConstants.NYUdga * NyuDGAConstants.NYUm, 3);

            this.ResultEffectProcent = Math.Round((100 * this.Nnominal) / this.Ndga, 3);

            this.IsEffectCalculate = this.ResultEffectProcent >= this.EffectProcent;
        }
    }
}
