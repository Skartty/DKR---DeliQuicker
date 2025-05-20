using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox2 : UserControl
{
    private TextBox textBox = new TextBox();
    private string placeholderText = "Digite aqui...";
    private bool isFocused = false;

    [Browsable(true)]
    public string PlaceholderText
    {
        get => placeholderText;
        set { placeholderText = value; Invalidate(); }
    }

    public override string Text
    {
        get => textBox.Text;
        set => textBox.Text = value;
    }

    public RoundedTextBox2()
    {
        this.BackColor = Color.White;
        this.Padding = new Padding(10);
        this.Size = new Size(200, 30);

        textBox.BorderStyle = BorderStyle.None;
        textBox.Dock = DockStyle.Fill;
        textBox.BackColor = Color.WhiteSmoke;
        textBox.Font = new Font("Zen Maru Gothic", 9);
        textBox.ForeColor = Color.Black;
        textBox.Lines = new string[] { };
        textBox.Multiline = true;

        textBox.Enter += (s, e) => { isFocused = true; Invalidate(); };
        textBox.Leave += (s, e) => { isFocused = false; Invalidate(); };
        textBox.TextChanged += (s, e) => Invalidate();

        this.Controls.Add(textBox);
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        int borderRadius = 15;
        int borderThickness = 1;

        Rectangle rect = this.ClientRectangle;
        rect.Inflate(-borderThickness, -borderThickness);

        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
            path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
            path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color borderColor = isFocused ? Color.DodgerBlue : Color.Gray;
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }

            this.Region = new Region(path);

            if (string.IsNullOrEmpty(textBox.Text) && !textBox.Focused && !string.IsNullOrEmpty(PlaceholderText))
            {
                using (Brush brush = new SolidBrush(Color.Gray))
                {
                    e.Graphics.DrawString(PlaceholderText, textBox.Font, brush, new PointF(12, 7));
                }
            }
        }
    }
}
