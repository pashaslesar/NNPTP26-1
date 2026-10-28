using System;
using System.Drawing;

namespace NNPTPZ1.PixelGraphics
{
    /// <summary>
    /// Selects pixel colors based on the found root and the number of iterations
    /// </summary>
    public class ColorManager
    {
        private readonly Color[] colors =
        {
            Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
        };

        private const int DarkeningPerIteration = 2;

        private static int Darken(int component, int amount)
        {
            return Math.Min(Math.Max(0, component - amount), 255);
        }

        public Color GetColor(int rootId, int iterationCount)
        {
            var baseColor = colors[rootId % colors.Length];
            int darkening = iterationCount * DarkeningPerIteration;

            return Color.FromArgb(Darken(baseColor.R, darkening), Darken(baseColor.G, darkening), Darken(baseColor.B, darkening));
        }
    }
}
