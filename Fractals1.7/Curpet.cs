using System.Drawing;
using System.Drawing.Drawing2D;

namespace Fractals1._7
{
    /// <summary>
    /// This class is for The Sierpinski Carpet fractal.
    /// </summary>
    class Curpet : Fractal
    {
        int Length { get; set; }
        RectangleF Recti { get; set; }
        Bitmap Bitmapic { get; set; }
        /// <summary>
        /// Constructor for The Sierpinski Carpet.
        /// </summary>
        /// <param name="length">Length of the square side.</param>
        /// <param name="recutsion_depth">Recursion depth.</param>
        /// <param name="recti">The main triangle.</param>
        /// <param name="bitmapic">Bitmap with the main fractal.</param>
        public Curpet(int length, int recutsion_depth, RectangleF recti, Bitmap bitmapic) : base(recutsion_depth)
        {
            Length = length;
            Recursion_depth = recutsion_depth;
            Recti = recti;
            Bitmapic = bitmapic;
        }
        /// <summary>
        /// Method for drawing The Sierpinski Carpet fractal.
        /// </summary>
        /// <param name="drawing">The basis for our drawing.</param>
        /// <param name="step">The number of recursion steps already taken.</param>
        /// <param name="recti">The triangle where the recursion will be performed.</param>
        public void DrawCurpet(Graphics drawing, int step, RectangleF recti)
        {
            if (step == 0)
            {
                // Define coordinates for grandolini fill.
                var a = (Bitmapic.Size.Width - Length * Choice.Zoom) / 2;
                var b = (Bitmapic.Size.Height - Length * Choice.Zoom) / 2;
                LinearGradientBrush linGrBrush = new LinearGradientBrush(new PointF(a, b), new Point(a + Length * Choice.Zoom, b + Length * Choice.Zoom), Choice.ColorSet[0], Choice.ColorSet[Choice.ColorSet.Count - 1]);
                drawing.FillRectangle(linGrBrush, recti);
            }
            else
            {
                // Recursively calling the drawing of other squares.
                float width = recti.Width / 3f, x0 = recti.Left, x1 = x0 + width, x2 = x0 + width * 2f;
                float height = recti.Height / 3f, y0 = recti.Top, y1 = y0 + height, y2 = y0 + height * 2f;
                DrawCurpet(drawing, step - 1, new RectangleF(x0, y0, width, height));
                DrawCurpet(drawing, step - 1, new RectangleF(x1, y0, width, height));
                DrawCurpet(drawing, step - 1, new RectangleF(x2, y0, width, height));
                DrawCurpet(drawing, step - 1, new RectangleF(x0, y1, width, height));
                DrawCurpet(drawing, step - 1, new RectangleF(x2, y1, width, height));
                DrawCurpet(drawing, step - 1, new RectangleF(x0, y2, width, height));
                DrawCurpet(drawing, step - 1, new RectangleF(x1, y2, width, height));
                DrawCurpet(drawing, step - 1, new RectangleF(x2, y2, width, height));

            }
        }
    }
}
