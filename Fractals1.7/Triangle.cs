using System.Drawing;
using System.Drawing.Drawing2D;

namespace Fractals1._7
{
    /// <summary>
    /// This class is for The Sierpinski Triangle fractal.
    /// </summary>
    class Triangle : Fractal
    {
        PointF First_point { get; set; }
        PointF Second_point { get; set; }
        PointF Third_point { get; set; }

        /// <summary>
        /// Constructor for the Sierpinski Triangle.
        /// </summary>
        /// <param name="recursion_depth">Recursion depth.</param>
        /// <param name="first_point">Coordinates of the upper vertex of the triangle.</param>
        /// <param name="second_point">Coordinates of the left vertex of the triangle.</param>
        /// <param name="third_point">Coordinates of the right vertex of the triangle.</param>
        public Triangle(int recursion_depth, PointF first_point, PointF second_point, PointF third_point) : base(recursion_depth)
        {
            Recursion_depth = recursion_depth;
            First_point = first_point;
            Second_point = second_point;
            Third_point = third_point;
        }
        /// <summary>
        /// Method for drawing a Sierpinski Triangle fractal.
        /// </summary>
        /// <param name="drawing">The basis for our drawing.</param>
        /// <param name="step">The number of recursion steps already taken.</param>
        /// <param name="top_point">New coordinates of the upper vertex of new the triangle.</param>
        /// <param name="left_point">New coordinates of the left vertex of the triangle.</param>
        /// <param name="right_point">New coordinates of the right vertex of the triangle.</param>
        public void DrawTriangle(Graphics drawing, int step, PointF top_point, PointF left_point, PointF right_point)
        {
            if (step == 0)
            {
                LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(130*Choice.Zoom, 630*Choice.Zoom), new Point(550*Choice.Zoom, 230* Choice.Zoom), Choice.ColorSet[0], Choice.ColorSet[Choice.ColorSet.Count - 1]);
                PointF[] points = { top_point, right_point, left_point };
                drawing.FillPolygon(linGrBrush, points);
            }
            else
            {
                PointF left_mid = new PointF(
                    (top_point.X + left_point.X) / 2f,
                    (top_point.Y + left_point.Y) / 2f);
                PointF right_mid = new PointF(
                    (top_point.X + right_point.X) / 2f,
                    (top_point.Y + right_point.Y) / 2f);
                PointF bottom_mid = new PointF(
                    (left_point.X + right_point.X) / 2f,
                    (left_point.Y + right_point.Y) / 2f);
                DrawTriangle(drawing, step - 1, top_point, left_mid, right_mid);
                DrawTriangle(drawing, step - 1, left_mid, left_point, bottom_mid);
                DrawTriangle(drawing, step - 1, right_mid, bottom_mid, right_point);
            }
        }
    }
}
