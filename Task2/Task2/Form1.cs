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
        Random _random = new Random();
        int _count = 0;
        public Form1()
        {
            InitializeComponent();
            CountLabel.Text = "0";
            FigureComboBox.SelectedIndex = 0;
            _brush = new SolidBrush(Color.Green);
            ColorButton.BackColor = _brush.Color;
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                _brush = new SolidBrush(ColorDialog.Color);
                ColorButton.BackColor = ColorDialog.Color;
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            int widht = Panel.ClientSize.Width;
            int height = Panel.ClientSize.Height;
            Graphics g = Panel.CreateGraphics();
            if (e.Button == MouseButtons.Left)
            {
                _count++;
                CountLabel.Text = _count.ToString();
                int length = _random.Next(1, 40);
                if (FigureComboBox.SelectedIndex == 0)
                {
                    var dx = e.X;
                    var dy = e.Y;
                    Circle circle = new Circle(e.Location, length, _brush);
                    _circles.Add(circle);
                    do
                    {
                        length = _random.Next(1, 20);
                    }
                    while (dy - 0 <= length || Math.Abs(dy - height) <= length || dx - 0 <= length || Math.Abs(dx - widht) <= length);
                    Invoke(() =>
                    {
                        g.FillEllipse(_brush, dx - length, dy - length, length * 2, length * 2);
                    });
                }
                else
                {
                    var dx = e.X;
                    var dy = e.Y;
                    Square square = new Square(e.Location, length, length, _brush);
                    _squares.Add(square);
                    do
                    {
                        length = _random.Next(1, 20);
                    }
                    while (dy - 0 <= length || Math.Abs(dy - height) <= length || dx - 0 <= length || Math.Abs(dx - widht) <= length);
                    Invoke(() =>
                    {
                        g.FillRectangle(_brush, dx - length, dy - length, length * 2, length * 2);
                    });
                }

            }

        }
    }
}