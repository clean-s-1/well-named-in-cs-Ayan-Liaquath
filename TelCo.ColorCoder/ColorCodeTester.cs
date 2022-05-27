namespace TelCo.ColorCoder
{
    using System;
    using System.Diagnostics;
    using System.Drawing;

    /// <summary>
    /// The 25-pair color code, originally known as even-count color code, 
    /// is a color code used to identify individual conductors in twisted-pair 
    /// wiring for telecommunications.
    /// This class tests the mapping of pair number to color and color to pair number.
    /// </summary>
    class ColorCodeTester
    {
        private static void Main()
        {
            WireColorPairCalculator colorPairCalculator = new WireColorPairCalculator();
            WirePairNumberCalculator pairNumberCalculator = new WirePairNumberCalculator();

            int pairNumber = 4;
            WireColorPair testPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
            Debug.Assert(testPair.MajorColor.Equals(Color.White));
            Debug.Assert(testPair.MinorColor.Equals(Color.Brown));

            pairNumber = 5;
            testPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
            Debug.Assert(testPair.MajorColor.Equals(Color.White));
            Debug.Assert(testPair.MinorColor.Equals(Color.SlateGray));

            pairNumber = 23;
            testPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
            Debug.Assert(testPair.MajorColor.Equals(Color.Violet));
            Debug.Assert(testPair.MinorColor.Equals(Color.Green));

            pairNumber = -1;
            try
            {
                colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
                Debug.Fail("Expected an exception.");
            }
            catch (ArgumentException argumentException)
            {
                Debug.Assert(argumentException.ParamName.Equals($"Argument PairNumber:{pairNumber} is outside the allowed range of 1-25."));
            }

            testPair = new WireColorPair { MajorColor = Color.Yellow, MinorColor = Color.Green };
            pairNumber = pairNumberCalculator.ConvertColorPairToPairNumber(testPair);
            Debug.Assert(pairNumber.Equals(18));

            testPair = new WireColorPair { MajorColor = Color.Red, MinorColor = Color.Blue };
            pairNumber = pairNumberCalculator.ConvertColorPairToPairNumber(testPair);
            Debug.Assert(pairNumber.Equals(6));

            ColorCodeManualGenerator colorCodeManualGenerator = new ColorCodeManualGenerator();
            string manual = colorCodeManualGenerator.GenerateManual();
            Debug.Assert(!string.IsNullOrEmpty(manual));
            string[] manualLines = manual.Split("\n");
            pairNumber = 1;
            int index = 4;
            Debug.Assert(manualLines[index - 1].Contains("-------------------------------------------"));
            for (; index < manualLines.Length - 2; index++)
            {
                testPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
                Debug.Assert(manualLines[index].Contains(pairNumber.ToString()));
                Debug.Assert(manualLines[index].Contains(testPair.MajorColor.Name));
                Debug.Assert(manualLines[index].Contains(testPair.MinorColor.Name));
                pairNumber++;
            }
            Debug.Assert(manualLines[index].Contains("-------------------------------------------"));
        }
    }
}
