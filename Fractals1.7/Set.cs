using System.Drawing;

namespace Fractals1._7
{
    /// <summary>
    /// This class is for The Cantor Set fractal.
    /// </summary>
    class Set : Fractal
    {
        int Length { get; set; }
        double Ratio_length { get; set; }
        /// <summary>
        /// Constructor for the Cantor Set.
        /// </summary>
        /// <param name="length">Initial length of a straight line.</param>
        /// <param name="ratio_lenth">Distance from one straight line to another.</param>
        /// <param name="recursion_depth">Recursion depth.</param>
        public Set(int length, double ratio_lenth, int recursion_depth) : base(recursion_depth)
        {
            Length = length;
            Recursion_depth = recursion_depth;
            Ratio_length = ratio_lenth;
        }
        /// <summary>
        /// Method for drawing a Cantor Set fractal.
        /// </summary>
        /// <param name="drawing">The basis for our drawing.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="width">The width of the lines of the following</param>
        /// <param name="step">The number of recursion steps already taken.</param>
        public void DrawSet(Graphics drawing, int x, int y, int width, int step)
        {
            // Setting the line color.
            SolidBrush brush = new SolidBrush(Choice.ColorSet[step]);
            Pen myPen = new Pen(brush, 1);
            // Recursively calling the drawing of the remaining lines.
            if (step < Recursion_depth)
            {
                drawing.DrawRectangle(myPen, x, y, width, 10);
                drawing.FillRectangle(brush, x, y, width, 10);
                y = y + (int)(Ratio_length * 100);
                DrawSet(drawing, x + width * 2 / 3, y, width / 3, step + 1);
                DrawSet(drawing, x, y, width / 3, step + 1);
            }
        }
    }
}
