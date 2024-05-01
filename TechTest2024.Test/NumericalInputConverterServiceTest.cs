using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechTest2024.Test
{
    [TestClass]
    public class NumericalInputConverterServiceTest
    {
        [TestMethod]
        public void NumberToWordsUnitMap_Correct_Unit_Mapping()
        {
            // Arange
            string[] unitsMap = ["", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"];
            
            IIterativeStringConcatenationService converter = new IterativeStringConcatenationService();

            for (ulong i = 1; i < 20; i++)
            {
                // Act
                var result = converter.NumberToWords(i);

                // Assert
                Assert.IsTrue(result == unitsMap[i]);
            }
        }

        [TestMethod]
        public void TestNumberToWordsTenMap()
        {
            // Arange
            IIterativeStringConcatenationService converter = new IterativeStringConcatenationService();

            // Act
            var result10 = converter.NumberToWords(10);
            var result20 = converter.NumberToWords(20);
            var result30 = converter.NumberToWords(30);
            var result40 = converter.NumberToWords(40);
            var result50 = converter.NumberToWords(50);
            var result60 = converter.NumberToWords(60);
            var result70 = converter.NumberToWords(70);
            var result80 = converter.NumberToWords(80);
            var result90 = converter.NumberToWords(90);

            // Assert
            Assert.IsTrue("TEN" == result10);
            Assert.IsTrue("TWENTY" == result20);
            Assert.IsTrue("THIRTY" == result30);
            Assert.IsTrue("FORTY" == result40);
            Assert.IsTrue("FIFTY" == result50);
            Assert.IsTrue("SIXTY" == result60);
            Assert.IsTrue("SEVENTY" == result70);
            Assert.IsTrue("EIGHTY" == result80);
            Assert.IsTrue("NINETY" == result90);
        }

		[TestMethod]
		public void TestNumberToWords(double number, string expected)
		{
			// Arange
			IIterativeStringConcatenationService converter = new IterativeStringConcatenationService();

			// Act
			var result = converter.ToWords("123.45");
			var result1 = converter.ToWords("1234567.89");

			Assert.AreEqual("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", result);
			Assert.AreEqual("ONE MILLION TWO HUNDRED AND THIRTY-FOUR THOUSAND FIVE HUNDRED AND SIXTY-SEVEN DOLLARS AND EIGHTY-NINE CENTS", result1);
		}

		[TestMethod]
		public void TestNumberToWords_Fail(double number, string expected)
		{
			// Arange
			IIterativeStringConcatenationService converter = new IterativeStringConcatenationService();

			// Act
			var result = converter.ToWords("-0");
			var result1 = converter.ToWords("18,446,744,073,709,551,616");

            Assert.AreEqual("Number is to big or to small for UInt64, max from 0 to 18,446,744,073,709,551,615", result);
            Assert.AreEqual("Number is to big or to small for UInt64, max from 0 to 18,446,744,073,709,551,615", result1);
        }
	}
}