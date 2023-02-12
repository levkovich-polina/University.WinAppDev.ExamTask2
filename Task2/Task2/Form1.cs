namespace Task2
{
    public partial class Form1 : Form
    {
        public class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            public SolidBrush Brush { get; set; }
            public Circle(Point point, int radius, SolidBrush brush)
            {
                Center = point;
                Radius = radius;
                Brush = brush;
            }
        }
        public class Square
        {
            public Point Center { get; set; }
            public int Widht { get; set; }
            public int Height { get; set; }
            public SolidBrush Brush { get; set; }
            public Square(Point point, int widht, int height, SolidBrush brush)
            {
                Center = point;
                Widht = widht;
                Height = height;
                Brush = brush;
            }
        }
        List<Circle> _circles = new List<Circle>();
        List<Square> _squares = new List<Square>();
        SolidBrush _brush;
        public Form1()
        {
            InitializeComponent();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                _brush = new SolidBrush(ColorDialog.Color);
                ColorButton.BackColor = ColorDialog.Color;
            }
        }
    }
}