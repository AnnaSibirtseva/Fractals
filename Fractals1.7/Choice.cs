using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Fractals1._7
{
    /// <summary>
    /// The main program code.
    /// </summary>
    public partial class Choice : Form
    {
        static int Line_length = 350;
        static int Recurs_depth = 5;
        static int First_angle = 45;
        static int Second_angle = 45;
        static double Ratio_length = 0.5;
        static Color First_color;
        static Color Second_color;
        string Current_command = "0";
        public static int Zoom = 1;
        public Bitmap bitmapic;

        public static List<Color> ColorSet;
        public Graphics drawing { get; set; }
        /// <summary>
        /// Something like a constructor for a class.
        /// </summary>
        public Choice()
        {
            InitializeComponent();
            ColorSet = GetColorGradient(First_color, Second_color, Recurs_depth);
            bitmapic = new Bitmap(Draw_panel.Width*Zoom, Draw_panel.Height*Zoom);
            drawing = Graphics.FromImage(bitmapic);
            label1.Text = String.Format($"Ratio of segment lengths: 5");
            label2.Text = String.Format($"First angle: 45°");
            label3.Text = String.Format($"Second angle: 45°");
            label7.Text = String.Format($"Line length: 350");
            label87.Text = String.Format($"Recursion steps: 5");
            colorDialog1.FullOpen = true;
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            MinimumSize = new Size(1371, 933);
        }
        /// <summary>
        /// Changing the coefficient value when the slider moves.
        /// </summary>
        private void Ratio_Scroll(object sender, EventArgs e)
        {
            label1.Text = String.Format($"Ratio of segment lengths: {Ratio.Value}");
            Ratio_length = Ratio.Value * 0.1;
            Draw_but_Click(sender, e);
        }
        /// <summary>
        /// Changing the value of the first angle when the slider moves.
        /// </summary>
        private void Angle1_Scroll(object sender, EventArgs e)
        {
            label2.Text = String.Format($"First angle: {Angle1.Value}°");
            First_angle = Angle1.Value;
            Draw_but_Click(sender, e);
        }
        /// <summary>
        /// Changing the value of the second angle when the slider moves.
        /// </summary>
        private void Angle2_Scroll(object sender, EventArgs e)
        {
            label3.Text = String.Format($"Second angle: {Angle2.Value}°");
            Second_angle = Angle2.Value;
            Draw_but_Click(sender, e);
        }
        /// <summary>
        /// Changing the length of the straight line when the slider moves.
        /// </summary>
        private void Length_Scroll(object sender, EventArgs e)
        {
            label7.Text = String.Format($"Line Length: {Length.Value}");
            Line_length = Length.Value;
            Draw_but_Click(sender, e);
        }
        /// <summary>
        /// Assign a value to the final color.
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            color2.BackColor = colorDialog1.Color;
            Second_color = colorDialog1.Color;
        }
        /// <summary>
        /// Assign a value to the initial color.
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            color1.BackColor = colorDialog1.Color;
            First_color = colorDialog1.Color;
        }
        /// <summary>
        /// We determine which fractal we will draw.
        /// </summary>
        private void Draw_but_Click(object sender, EventArgs e)
        {
            drawing.Clear(Color.AliceBlue);
            ColorSet = GetColorGradient(First_color, Second_color, Recurs_depth);
            switch (Current_command)
            {
                case "0":
                    MessageBox.Show("No fractal selected for drawing");
                    break;
                case "Tree":
                    DrawAllTree();
                    break;
                case "Carpet":
                    DrawAllCurpet();
                    break;
                case "Triangle":
                    DrawAllTriangle();
                    break;
                case "Set":
                    DrawAllSet();
                    break;
                case "Curve":
                    DrawAllCurve();
                    break;
            }
        }
        /// <summary>
        /// Creating a color gradient.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="finish">End color.</param>
        /// <param name="NumberOfColors">Number of required colors.</param>
        /// <returns></returns>
        public static List<Color> GetColorGradient(Color start, Color finish, int NumberOfColors)
        {
            ColorSet = new List<Color>();
            for (int i = 0; i <= NumberOfColors; i++)
            {
                var rAdverage = start.R + (int)((finish.R - start.R) * i / (NumberOfColors));
                var gAdverage = start.G + (int)((finish.G - start.G) * i / (NumberOfColors));
                var bAdverage = start.B + (int)((finish.B - start.B) * i / (NumberOfColors));
                ColorSet.Add(Color.FromArgb(255, rAdverage, gAdverage, bAdverage));
            }
            return ColorSet;
        }
        /// <summary>
        /// If the user wants to draw the first fractal.
        /// </summary>
        private void opt1_Click(object sender, EventArgs e)
        {
            Current_command = "Tree";
            opt1.BackColor = opt1.BackColor != Color.SteelBlue ? Color.SteelBlue : Color.LightSteelBlue;
            opt2.BackColor = Color.LightSteelBlue;
            opt3.BackColor = Color.LightSteelBlue;
            opt4.BackColor = Color.LightSteelBlue;
            opt5.BackColor = Color.LightSteelBlue;
        }
        /// <summary>
        /// If the user wants to draw the second fractal.
        /// </summary>
        private void opt2_Click(object sender, EventArgs e)
        {
            Current_command = "Curve";
            opt1.BackColor = Color.LightSteelBlue;
            opt2.BackColor = opt1.BackColor != Color.SteelBlue ? Color.SteelBlue : Color.LightSteelBlue;
            opt3.BackColor = Color.LightSteelBlue;
            opt4.BackColor = Color.LightSteelBlue;
            opt5.BackColor = Color.LightSteelBlue;
        }
        /// <summary>
        /// If the user wants to draw the third fractal.
        /// </summary>
        private void opt3_Click(object sender, EventArgs e)
        {
            Current_command = "Carpet";
            opt1.BackColor = Color.LightSteelBlue;
            opt2.BackColor = Color.LightSteelBlue;
            opt3.BackColor = opt2.BackColor != Color.SteelBlue ? Color.SteelBlue : Color.LightSteelBlue;
            opt4.BackColor = Color.LightSteelBlue;
            opt5.BackColor = Color.LightSteelBlue; ;
        }
        /// <summary>
        /// If the user wants to draw the fourth fractal.
        /// </summary>
        private void opt4_Click(object sender, EventArgs e)
        {
            Current_command = "Triangle";
            opt1.BackColor = Color.LightSteelBlue;
            opt2.BackColor = Color.LightSteelBlue;
            opt3.BackColor = Color.LightSteelBlue;
            opt4.BackColor = opt3.BackColor != Color.SteelBlue ? Color.SteelBlue : Color.LightSteelBlue;
            opt5.BackColor = Color.LightSteelBlue;
        }
        /// <summary>
        /// If the user wants to draw the fifth fractal.
        /// </summary>
        private void opt5_Click(object sender, EventArgs e)
        {
            Current_command = "Set";
            opt1.BackColor = Color.LightSteelBlue;
            opt2.BackColor = Color.LightSteelBlue;
            opt3.BackColor = Color.LightSteelBlue;
            opt4.BackColor = Color.LightSteelBlue;
            opt5.BackColor = opt4.BackColor != Color.SteelBlue ? Color.SteelBlue : Color.LightSteelBlue;
        }
        /// <summary>
        /// Changing the recursion depth when the slider moves.
        /// </summary>
        private void RecursionSteps_Scroll(object sender, EventArgs e)
        {
            label87.Text = String.Format($"Recursion steps: {RecursionSteps.Value}");
            Recurs_depth = RecursionSteps.Value;
            Draw_but_Click(sender, e);
        }
        /// <summary>
        /// Draw the fractal again when the window size changes.
        /// </summary>
        private void Choice_Resize(object sender, EventArgs e)
        {
             drawing.Clear(Color.AliceBlue);
             ColorSet = GetColorGradient(First_color, Second_color, Recurs_depth);
             switch (Current_command)
             {
                 case "Tree":
                     DrawAllTree();
                     break;
                 case "Carpet":
                     DrawAllCurpet();
                     break;
                 case "Triangle":
                     DrawAllTriangle();
                     break;
                 case "Set":
                     DrawAllSet();
                     break;
                 case "Curve":
                     DrawAllCurve();
                     break;
             }
             
        }
        /// <summary>
        /// Saving the drawn fractal.
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Image != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox5.Image.Save(saveFileDialog1.FileName + ".jpeg", ImageFormat.Jpeg);
                }
            }
            else
            {
                MessageBox.Show("Sorry, but there is nothing to save yet.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Zoom in on the image.
        /// </summary>
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if(Zoom < 10)
            {
                Zoom += 1;
            }
            Draw_but_Click(sender, e);
        }
        /// <summary>
        /// Zoom out on the image.
        /// </summary>
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if(Zoom > 1)
            {
                Zoom -= 1;
            }
            Draw_but_Click(sender, e);
        }
        /// <summary>
        /// Creating additional objects necessary for drawing a fractal.
        /// </summary>
        private void DrawAllSet()
        {
            bitmapic = new Bitmap(Draw_panel.Width * Zoom, Draw_panel.Height * Zoom);
            drawing = Graphics.FromImage(bitmapic);
            drawing.Clear(Color.AliceBlue);
            if (Recurs_depth > 6)
            {
                MessageBox.Show("In your chosen fractal, the maximum number of recursions is 6.");
            }
            else
            {
                Set set = new Set(Line_length, Ratio_length, Recurs_depth);
                set.DrawSet(drawing, (bitmapic.Size.Width) / 4, (bitmapic.Size.Height) / 2, Line_length * Zoom, 0);
                pictureBox5.Image = bitmapic;
                pictureBox5.Size = bitmapic.Size;
            }
        }
        /// <summary>
        /// Creating additional objects necessary for drawing a fractal.
        /// </summary>
        private void DrawAllTree()
        {
            bitmapic = new Bitmap(Draw_panel.Width * Zoom, Draw_panel.Height * Zoom);
            drawing = Graphics.FromImage(bitmapic);
            drawing.Clear(Color.AliceBlue);
            Tree fractal = new Tree(First_angle, Second_angle, Recurs_depth, Ratio_length);
            fractal.Draw(drawing, 0, (bitmapic.Size.Width) / 2, (bitmapic.Size.Height) * 0.75, (750 * Zoom) / (Ratio_length * 10), 0, ColorSet[0]);
            pictureBox5.Image = bitmapic;
            pictureBox5.Size = bitmapic.Size;
        }
        /// <summary>
        /// Creating additional objects necessary for drawing a fractal.
        /// </summary>
        private void DrawAllCurpet()
        {
            bitmapic = new Bitmap(Draw_panel.Width * Zoom, Draw_panel.Height * Zoom);
            drawing = Graphics.FromImage(bitmapic);
            drawing.Clear(Color.AliceBlue);
            RectangleF recti = new RectangleF(new PointF((bitmapic.Size.Width - Line_length * Zoom) / 2, (bitmapic.Size.Height - Line_length * Zoom) / 2), new SizeF(Line_length * Zoom, Line_length * Zoom));
            if (Recurs_depth > 6)
            {
                MessageBox.Show("In your chosen fractal, the maximum number of recursions is 6.");
            }
            else
            {
                Curpet curpet = new Curpet(Line_length, Recurs_depth, recti, bitmapic);
                curpet.DrawCurpet(drawing, Recurs_depth, recti);
                pictureBox5.Image = bitmapic;
                pictureBox5.Size = bitmapic.Size;
            }
        }
        /// <summary>
        /// Creating additional objects necessary for drawing a fractal.
        /// </summary>
        private void DrawAllTriangle()
        {
            bitmapic = new Bitmap(Draw_panel.Width * Zoom, Draw_panel.Height * Zoom);
            drawing = Graphics.FromImage(bitmapic);
            drawing.Clear(Color.AliceBlue);
            if (Recurs_depth > 7)
            {
                MessageBox.Show("In your chosen fractal, the maximum number of recursions is 7.");
            }
            else
            {
                PointF first_point = new Point(340*Zoom, 230*Zoom);
                PointF second_point = new Point(130*Zoom, 630*Zoom);
                PointF third_point = new Point(550*Zoom, 630*Zoom);
                Triangle triangle = new Triangle(Recurs_depth, first_point, second_point, third_point);
                triangle.DrawTriangle(drawing, Recurs_depth, first_point, second_point, third_point);
                pictureBox5.Image = bitmapic;
                pictureBox5.Size = bitmapic.Size;
            }
        }
        /// <summary>
        /// Creating additional objects necessary for drawing a fractal.
        /// </summary>
        private void DrawAllCurve()
        {
            bitmapic = new Bitmap(Draw_panel.Width * Zoom, Draw_panel.Height * Zoom);
            drawing = Graphics.FromImage(bitmapic);
            drawing.Clear(Color.AliceBlue);
            if (Recurs_depth > 5)
            {
                MessageBox.Show("In your chosen fractal, the maximum number of recursions is 5.");
            }
            else
            {
                Pen pen = new Pen(ColorSet[0], 3);
                PointF first_point = new PointF(bitmapic.Size.Width / 6, bitmapic.Size.Height / 2);
                PointF second_point = new PointF(bitmapic.Size.Width / 6 + (Line_length * 6 / 5) * Zoom, bitmapic.Size.Height / 2);
                PointF third_point = new PointF((bitmapic.Size.Width / 6 + (Line_length * 6 / 5) * Zoom + bitmapic.Size.Width / 6) / 2, (int)(bitmapic.Size.Height / 2 + (Line_length * 6 / 5) * Zoom * Math.Sqrt(3) / 3));
                drawing.DrawLine(pen, first_point, second_point);
                Curve curve = new Curve(Recurs_depth, first_point, second_point, third_point);
                curve.DrawCurve(drawing, first_point, second_point, third_point, Recurs_depth, 0);
                pictureBox5.Image = bitmapic;
                pictureBox5.Size = bitmapic.Size;
            }
        }
        /// <summary>
        /// We show the user a small hint about the relationship between sliders and fractals.
        /// </summary>
        private void Question_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t*****Instructions on what each slider means for each fractal*****\n" +
                "Tree Of Pythagoras:\n" +
                "\t> Ratio of segment lengths - How many times the next line is smaller (divided by 10)\n" +
                "\t> First Angle - The angle of the left straight line\n" +
                "\t> Second Angle - The angle of the right straight line\n" +
                "\t> Recursion steps - Number of recursion steps\n"+
                "The Koch Curve:\n" +
                "\t> Recursion steps - Number of recursion steps\n" +
                "\t> Line length - Length of a straight line\n" +
                "Sierpinsky carpet:\n" +
                "\t> Recursion steps - Number of recursion steps\n" +
                "\t> Line length - Length of the square side\n" +
                "Sierpinski triangle:\n" +
                "\t> Recursion steps - Number of recursion steps\n" +
                "The Cantor Set:\n" +
                "\t> Ratio of segment Lengths - Distance from one straight line to another (multiplied by 10)\n" +
                "\t> Recursion steps - Number of recursion steps\n" +
                "\t> Line length - Length of a straight line\n");

        }
        /// <summary>
        /// Method for closing the first form.
        /// </summary>
        private void Choice_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Closing up the greeting form.
            (Application.OpenForms[0] as FractalForm).Close();
        }
    }
}
