using System;
using System.Linq;

namespace MathRoundExtension
{
    public static class MathEx
    {
        /// <summary>
        /// 有効桁数を指定しての丸め
        /// </summary>
        /// <param name="val">丸め対象の数値</param>
        /// <param name="digit">有効桁数</param>
        /// <param name="midpointRounding">丸め方向の指示</param>
        /// <returns>丸め結果</returns>
        public static double Round(double val,
                                   int digit,
                                   MidpointRounding midpointRounding = MidpointRounding.AwayFromZero)
        {
            int dig = -Digit(val) + (digit - 1);
            if (0 <= dig && dig <= 15)
                return Math.Round(val, dig, midpointRounding);
            double coef = Math.Pow(10, dig);
            return Math.Round(val * coef, midpointRounding) / coef;
        }

        /// <summary>
        /// 有効桁数を指定しての切り上げ
        /// </summary>
        /// <param name="val">切り上げ対象の数値</param>
        /// <param name="digit">有効桁数</param>
        /// <returns>切り上げ結果</returns>
        public static double RoundUp(double val, int digit)
        {
            double coef = Math.Pow(10, -Digit(val) + (digit - 1));
            return Math.Ceiling(val * coef) / coef;
        }

        /// <summary>
        /// 有効桁数を指定しての切り捨て
        /// </summary>
        /// <param name="val">切り捨て対象の数値</param>
        /// <param name="digit">有効桁数</param>
        /// <returns>切り捨て結果</returns>
        public static double RoundDown(double val, int digit)
        {
            double coef = Math.Pow(10, -Digit(val) + (digit - 1));
            return Math.Floor(val * coef) / coef;
        }

        /// <summary>
        /// 有効桁数を指定しての切り上げ（絶対値が0から遠のく方向への切り上げ）
        /// </summary>
        /// <param name="val">切り上げ対象の数値</param>
        /// <param name="digit">有効桁数</param>
        /// <returns>切り上げ結果</returns>
        public static double TrimUp(double val, int digit)
        {
            double coef = Math.Pow(10, -Digit(val) + (digit - 1));
            return val < 0 ? Math.Floor(val * coef) / coef
                           : Math.Ceiling(val * coef) / coef;
        }

        /// <summary>
        /// 有効桁数を指定しての切り捨て（絶対値が0に近づく方向への切り捨て）
        /// </summary>
        /// <param name="val">切り捨て対象の数値</param>
        /// <param name="digit">有効桁数</param>
        /// <returns>切り捨て結果</returns>
        public static double TrimDown(double val, int digit)
        {
            double coef = Math.Pow(10, -Digit(val) + (digit - 1));
            return val < 0 ? Math.Ceiling(val * coef) / coef
                           : Math.Floor(val * coef) / coef;
        }

        /// <summary>
        /// 数値に対して先頭から指定した桁数のみ抜き出し
        /// </summary>
        /// <remarks>符号は失われる</remarks>
        /// <param name="val">抜き出し対象の数値</param>
        /// <param name="digit">桁数</param>
        /// <returns>抜き出し結果</returns>
        public static int HeadValue(double val, int digit = 1)
        {
            return ((int)RoundDown(Normalize(val) * Math.Pow(10, digit), digit)) / 10;
        }

        /// <summary>
        /// 有効桁数の判定
        /// </summary>
        /// <remarks>テスト不十分</remarks>
        /// <param name="val">有効桁数判定対象</param>
        /// <returns>有効桁数</returns>
        public static int SignificantDigits(double val)
        {
            return new String(Normalize(val).ToString("F16")
                                            .Where((c, i) => (c != '0' || i != 0) && c != '.')
                                            .ToArray())
                                            .LastIndexOfAny("123456789".ToArray()) + 1;
        }

        /// <summary>
        /// 数値をx.xxxxの形式に整える
        /// </summary>
        /// <remarks>符号は失われる</remarks>
        /// <param name="val">整形対象</param>
        /// <returns>整形後数値</returns>
        public static double Normalize(double val)
        {
            return Math.Abs(val) / Math.Pow(10, Digit(val));
        }

        /// <summary>
        /// 桁数を求める（Log10nを計算）
        /// </summary>
        /// <remarks>0を渡された場合は0を返す</remarks>
        /// <param name="val"></param>
        /// <returns>桁数</returns>
        public static int Digit(double val)
        {
            double abs = Math.Abs(val);
            if (abs == 0)
                return 0;
            else
                return (int)Math.Floor(Math.Log10(abs));
        }
    }
}
