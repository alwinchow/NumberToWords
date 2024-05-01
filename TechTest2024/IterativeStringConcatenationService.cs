namespace TechTest2024
{
	public class IterativeStringConcatenationService : IIterativeStringConcatenationService
	{
		public string ToWords(string numericInput)
		{
            try
            {
				if (string.IsNullOrWhiteSpace(numericInput))
					return "ZERO";

				if (!decimal.TryParse(numericInput, out decimal result))
				{
					return "ZERO";
				}

				var dollarPart = (UInt64)result;
				var centPart = (UInt64)((result - dollarPart) * 100);

				var words = NumberToWords(dollarPart);
				if (centPart > 0)
				{
					words = $"{words} AND {NumberToWords(centPart)} CENTS";
				}

				return words;
			}
            catch (ArgumentOutOfRangeException e)
            {
                return e.ToString();
            }
			catch (OverflowException e)
			{
				return "Number is to big or to small for UInt64, max from 0 to 18,446,744,073,709,551,615";
			}
		}

		/// <summary>
		/// Max until QUINTILLION
		/// </summary>
		/// <param name="number">Max 18,446,744,073,709,551,615</param>
		/// <returns></returns>
		public string NumberToWords(UInt64 number)
        {
            if (number == 0)
			{
				return "ZERO";
			}

            var words = string.Empty;

			if ((number / 1000000000000000000) > 0)
			{
				words += $"{NumberToWords(number / 1000000000000000000)} QUINTILLION";
				number %= 1000000000000000000;
			}

			if ((number / 1000000000000000) > 0)
			{
				words += $"{NumberToWords(number / 1000000000000000)} QUADRILLION";
				number %= 1000000000000000;
			}

			if ((number / 1000000000000) > 0)
			{
				words += $"{NumberToWords(number / 1000000000000)} TRILLION";
				number %= 1000000000000;
			}

			if ((number / 1000000000) > 0)
			{
				words += $"{NumberToWords(number / 1000000000)} BILLION";
				number %= 1000000000;
			}

			if ((number / 1000000) > 0)
            {
                words += $"{NumberToWords(number / 1000000)} MILLION";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += $"{NumberToWords(number / 1000)} THOUSAND";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += $"{NumberToWords(number / 100)} HUNDRED";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
				{
					words += "AND ";
				}

                string[] unitsMap = ["", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"];
                string[] tensMap = ["", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"];

				if (number < 20)
				{
					words += unitsMap[number];
				}
				else
				{
					words += tensMap[number / 10];
					if ((number % 10) > 0)
					{
						words += "-" + unitsMap[number % 10];
					}
				}
            }

            return words;
        }
    }
}
