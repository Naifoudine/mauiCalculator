using System;
namespace mauiCalculator
{
	public static class Calculate
	{
		public static double Calculer(double val1, double val2, string operatorMath)
		{
			double result = 0;

            switch (operatorMath)
            {
				case "/":
					result = val1 / val2;
					break;
                case "-":
                    result = val1 - val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                case "+":
                    result = val1 + val2;
                    break;
                default:
					break;
            }

            return result;
		}
	}
}

