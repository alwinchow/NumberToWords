namespace TechTest2024
{
	public class RecursiveDictionaryLoopupService
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

		public string NumberToWords(UInt64 number)
		{
			if (number.Equals(0))
			{
				return "ZERO";
			}

			var dicMapping = new Dictionary<UInt64, string>()
			{
				{ 1000000000000000000, "QUINTILLION" },
				{ 1000000000000000, "QUADRILLION" },
				{ 1000000000000, "TRILLION" },
				{ 1000000000, "BILLION" },
				{ 1000000, "MILLION" },
				{ 1000, "THOUSAND" },
				{ 100, "HUNDRED" },
				{ 90, "NINETY" },
				{ 80, "EIGHTY" },
				{ 70, "SEVENTY" },
				{ 60, "SIXTY" },
				{ 50, "FIFTY" },
				{ 40, "FORTY" },
				{ 30, "THIRTY" },
				{ 20, "TWENTY" },
				{ 19, "NINETEEN" },
				{ 18, "EIGHTEEN" },
				{ 17, "SEVENTEEN" },
				{ 16, "SIXTEEN" },
				{ 15, "FIFTEEN" },
				{ 14, "FOURTEEN" },
				{ 13, "THIRTEEN" },
				{ 12, "TWELVE" },
				{ 11, "ELEVEN" },
				{ 10, "TEN" },
				{ 9, "NINE" },
				{ 8, "EIGHT" },
				{ 7, "SEVEN" },
				{ 6, "SIX" },
				{ 5, "FIVE" },
				{ 4, "FOUR" },
				{ 3, "THREE" },
				{ 2, "TWO" },
				{ 1, "ONE" }
			};

			foreach (var item in dicMapping)
			{
				if(number >= item.Key)
				{
					if (item.Key >= 100)
					{
						return $"{NumberToWords(number / item.Key)} {item.Value} {NumberToWords(number % item.Key)}";
					}
					else
					{
						return $"{item.Value}{(item.Key >= 20 ? "-" : " ")}{NumberToWords(number % item.Key)}";
					}
				}
			}

			return string.Empty;
		}
	}
}
