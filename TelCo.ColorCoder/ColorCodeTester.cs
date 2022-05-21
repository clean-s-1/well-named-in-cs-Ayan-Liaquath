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
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair);
            Debug.Assert(testPair.MajorColor.Equals(Color.White));
            Debug.Assert(testPair.MinorColor.Equals(Color.Brown));

            pairNumber = 5;
            testPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair);
            Debug.Assert(testPair.MajorColor.Equals(Color.White));
            Debug.Assert(testPair.MinorColor.Equals(Color.SlateGray));

            pairNumber = 23;
            testPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair);
            Debug.Assert(testPair.MajorColor.Equals(Color.Violet));
            Debug.Assert(testPair.MinorColor.Equals(Color.Green));

            testPair = new WireColorPair { MajorColor = Color.Yellow, MinorColor = Color.Green };
            pairNumber = pairNumberCalculator.ConvertColorPairToPairNumber(testPair);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair, pairNumber);
            Debug.Assert(pairNumber.Equals(18));

            testPair = new WireColorPair { MajorColor = Color.Red, MinorColor = Color.Blue };
            pairNumber = pairNumberCalculator.ConvertColorPairToPairNumber(testPair);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair, pairNumber);
            Debug.Assert(pairNumber.Equals(6));

            ColorCodeManualGenerator colorCodeManualGenerator = new ColorCodeManualGenerator();
            Console.WriteLine(colorCodeManualGenerator.GenerateManual());
        }
    }
}
