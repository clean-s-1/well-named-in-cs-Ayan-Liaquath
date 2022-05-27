namespace TelCo.ColorCoder
{
    using System;

    internal class WirePairNumberCalculator
    {
        internal int ConvertColorPairToPairNumber(WireColorPair colorPair)
        {
            int majorColorIndex = -1; // Invalid index (Not found status by default)  
            for (int i = 0; i < WireColorStore.MajorColors.Length; i++)
            {
                if (WireColorStore.MajorColors[i] == colorPair.MajorColor)
                {
                    majorColorIndex = i;
                    break;
                }
            }

            int minorColorIndex = -1; // Invalid index (Not found status by default)
            for (int i = 0; i < WireColorStore.MinorColors.Length; i++)
            {
                if (WireColorStore.MinorColors[i] == colorPair.MinorColor)
                {
                    minorColorIndex = i;
                    break;
                }
            }

            if (majorColorIndex == -1 || minorColorIndex == -1)
            {
                throw new ArgumentException($"Unknown Colors: {colorPair}");
            }

            int pairNumber = (majorColorIndex * WireColorStore.MinorColors.Length) + (minorColorIndex + 1); // Note: +1 as array index starts from 0.
            
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colorPair, pairNumber);
            return pairNumber;
        }
    }
}
