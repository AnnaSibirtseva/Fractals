using System;
using System.Drawing;

namespace Fractals1._7
{
    /// <summary>
    /// This class is for Pythagorean Tree fractal.
    /// </summary>
    class Tree : Fractal
    {
        int First_angle { get; set; }
        int Second_angle { get; set; }
        double Ratio { get; set; }
        /// <summary>
        /// Constructor for the Pythagorean tree.
        /// </summary>
        /// <param name="angle1">First tilt angle.</param>
        /// <param name="angle2">Second tilt angle.</param>
        /// <param name="recursion_depth">Recursion depth.</param>
        /// <param name="ratio">How many times will the next segment be smaller than the previous one.</param>
        public Tree(int angle1, int angle2, int recursion_depth, double ratio) 
            : base(recursion_depth)
        {
            First_angle = angle1;
            Second_angle = angle2;
            Recursion_depth = recursion_depth;
            Ratio = ratio;
        }
        /// <summary>
        /// Method for drawing a Pythagorean Tree fractal.
        /// </summary>
        /// <param name="drawing">The basis for our drawing.</param>
        /// <param name="step">Steps of our recursion.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="length">The length of the original straight line.</param>
        /// <param name="angle">Initial tilt angle.</param>
        /// <param name="color">Color for drawing a straight line.</param>
        public void Draw(Graphics drawing, int step, double x, double y, double length, int angle, Color color)
        {
            double newX, newY;
            newX = x - length * Math.Sin(angle * Math.PI / 180);
            newY = y - length * Math.Cos(angle * Math.PI / 180);
            drawing.DrawLine(new Pen(new SolidBrush(color), 2), (int)x, (int)y, (int)newX, (int)newY);
            // Recursively calling the drawing of the remaining lines.
            if (step < Recursion_depth)
            {
                Draw(drawing, step + 1, newX, newY, length * Ratio, (int)(angle + First_angle), Choice.ColorSet[step]);
                Draw(drawing, step + 1, newX, newY, length * Ratio, (int)(angle - Second_angle), Choice.ColorSet[step]);
            }
        }
    }
}
