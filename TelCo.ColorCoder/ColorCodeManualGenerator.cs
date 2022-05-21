namespace TelCo.ColorCoder
{
    internal class ColorCodeManualGenerator
    {
        internal string GenerateManual()
        {
            WireColorPairCalculator colorPairCalculator = new WireColorPairCalculator();
            string manual = "\n-------------------------------------------\n";
            manual += "| Pair Number | Major Color | Minor Color |\n";
            manual += "-------------------------------------------\n";
            int minimumPairNumber = 1;
            int maximumPairNumber = 25;

            int pairNumber = minimumPairNumber;
            while (pairNumber <= maximumPairNumber)
            {
                WireColorPair colorPair = colorPairCalculator.ConvertPairNumberToColorPair(pairNumber);
                manual += $"|{CenterAlignDataForGivenLength(pairNumber.ToString(), 13)}|"
                          + $"{CenterAlignDataForGivenLength(colorPair.MajorColor.Name, 13)}|"
                          + $"{CenterAlignDataForGivenLength(colorPair.MinorColor.Name, 13)}|\n";
                pairNumber++;
            }

            manual += "-------------------------------------------\n";
            return manual;
        }

        /// <summary>
        /// The function returns a string of given length with the given data center aligned in it.
        /// </summary>
        /// <param name="data">String data.</param>
        /// <param name="stringLength">Required string length (not data length).</param>
        private string CenterAlignDataForGivenLength(string data, int stringLength)
        {
            int leftPadding = (stringLength - data.Length) / 2;
            int rightPadding = stringLength - data.Length - leftPadding;

            return new string(' ', leftPadding) + data + new string(' ', rightPadding);
        }
    }
}
