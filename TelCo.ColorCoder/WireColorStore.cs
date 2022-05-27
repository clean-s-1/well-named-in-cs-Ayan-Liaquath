namespace TelCo.ColorCoder
{
    using System.Drawing;

    /// <summary>
    /// Contains the list of Major and Minor wire colors.
    /// </summary>
    internal static class WireColorStore
    {
        static WireColorStore()
        {
            MajorColors = new[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            MinorColors = new[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        internal static Color[] MajorColors { get; }

        internal static Color[] MinorColors { get; }
    }
}
