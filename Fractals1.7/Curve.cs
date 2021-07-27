using System.Drawing;

namespace Fractals1._7
{
    /// <summary>
    /// This class is for The Koch Curve fractal.
    /// </summary>
    class Curve : Fractal
    {
        PointF First_point { get; set; }
        PointF Second_point { get; set; }
        PointF Third_point { get; set; }
        /// <summary>
        /// Constructor for the The Koch Curve.
        /// </summary>
        /// <param name="recursion_depth">Recursion depth.</param>
        /// <param name="first_point"></param>
        /// <param name="second_point"></param>
        /// <param name="third_point"></param>
        public Curve(int recursion_depth, PointF first_point, PointF second_point, PointF third_point) : base(recursion_depth)
        {
            Recursion_depth = recursion_depth;
            First_point = first_point;
            Second_point = second_point;
            Third_point = third_point;
        }
        /// <summary>
        /// Method for drawing a Cantor Set fractal.
        /// </summary>
        /// <param name="drawing">The basis for our drawing.</param>
        /// <param name="f_point">The starting coordinate of the line.</param>
        /// <param name="s_point">Coordinate of the middle of the straight line.</param>
        /// <param name="t_point">The final coordinate of the line.</param>
        /// <param name="step">Recursion depth.</param>
        /// <param name="c">Counter for the color gradient.</param>
        public void DrawCurve(Graphics drawing, PointF f_point, PointF s_point, PointF t_point, int step, int c)
        {
            // As long as the number of recursions is greater than 0, we continue to divide the line.
            if (step > 0)
            {
                c++;
                // Main drawing pen
                Pen pen = new Pen(Choice.ColorSet[c], 3);
                // A pen that works as an eraser.
                Pen penClear = new Pen(Color.AliceBlue, 3);
                PointF p4 = new PointF((s_point.X + 2 * f_point.X) / 3, (s_point.Y + 2 * f_point.Y) / 3);
                PointF p5 = new PointF((2 * s_point.X + f_point.X) / 3, (f_point.Y + 2 * s_point.Y) / 3);
                PointF ps = new PointF((s_point.X + f_point.X) / 2, (s_point.Y + f_point.Y) / 2);
                PointF pn = new PointF((4 * ps.X - t_point.X) / 3, (4 * ps.Y - t_point.Y) / 3);
                drawing.DrawLine(pen, p4, pn);
                drawing.DrawLine(pen, p5, pn);
                // Erasing an unnecessary straight line.
                drawing.DrawLine(penClear, p4, p5);
                DrawCurve(drawing, p4, pn, p5, step - 1, c);
                DrawCurve(drawing, pn, p5, p4, step - 1, c);
                DrawCurve(drawing, f_point, p4, new PointF((2 * f_point.X + t_point.X) / 3, (2 * f_point.Y + t_point.Y) / 3), step - 1, c);
                DrawCurve(drawing, p5, s_point, new PointF((2 * s_point.X + t_point.X) / 3, (2 * s_point.Y + t_point.Y) / 3), step - 1, c);

            }
        }
    }
}
