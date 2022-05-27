namespace TelCo.ColorCoder
{
    using System.Collections.Generic;
    using System.Drawing;
    
    internal class ColorCodeManualGenerator
    {
        internal IList<(int PairNumber, Color MajorColor, Color MinorColor)> GenerateManual()
        {
            WireColorPairCalculator colorPairCalculator = new WireColorPairCalculator();

            IList<(int PairNumber, Color MajorColor, Color MinorColor)> manual = new List<(int PairNumber, Color MajorColor, Color MinorColor)>();
            int minimumPairNumber = 1;
            int maximumPairNumber = 25;

            int pairNumber = minimumPairNumber;

            while (pairNumber <= maximumPairNumber)
            {
                WireColorPair colorPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
                manual.Add((pairNumber, colorPair.MajorColor, colorPair.MinorColor));
                pairNumber++;
            }

            return manual;
        }
    }
}
