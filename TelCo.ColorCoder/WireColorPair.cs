namespace TelCo.ColorCoder
{
    using System.Drawing;

    /// <summary>
    /// Contains the Major and Minor color of the wire.
    /// </summary>
    internal class WireColorPair
    {
        internal Color MajorColor { get; set; }

        internal Color MinorColor { get; set; }

        /// <summary>
        /// Used to get the Color pair in a pre-defined string format.
        /// </summary>
        /// <returns>
        /// Color pair in the format 'Major color, Minor color'.
        /// </returns>
        public override string ToString()
        {
            return $"Major Color:{MajorColor.Name}, Minor Color:{MinorColor.Name}";
        }
    }
}
