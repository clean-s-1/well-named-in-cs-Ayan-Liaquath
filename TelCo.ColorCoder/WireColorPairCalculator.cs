namespace TelCo.ColorCoder
{
    using System;

    internal class WireColorPairCalculator
    {
        internal WireColorPair ConvertPairNumberToColorPair(int pairNumber)
        {
            int minorColorCount = WireColorStore.MinorColors.Length;
            int majorColorCount = WireColorStore.MajorColors.Length;

            if (pairNumber < 1 || pairNumber > minorColorCount * majorColorCount) 
            {
                throw new ArgumentOutOfRangeException($"Argument PairNumber:{pairNumber} is outside the allowed range of 1-25.");
            }

            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1; // As array indexes start from 0.
            int majorColorIndex = zeroBasedPairNumber / minorColorCount;
            int minorColorIndex = zeroBasedPairNumber % minorColorCount;

            WireColorPair wireColorPair = new WireColorPair
            {
                MajorColor = WireColorStore.MajorColors[majorColorIndex],
                MinorColor = WireColorStore.MinorColors[minorColorIndex]
            };

            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, wireColorPair);

            return wireColorPair;
        }
    }
}
