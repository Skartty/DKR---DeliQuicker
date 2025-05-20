using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox : UserControl
{
    private TextBox textBox = new TextBox();

    public RoundedTextBox()
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

        this.Controls.Add(textBox);
    }

    public override string Text
    {
        get => textBox.Text;
        set => textBox.Text = value;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (GraphicsPath path = new GraphicsPath())
        {
            int radius = 15;
            Rectangle rect = this.ClientRectangle;
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);

            using (Pen pen = new Pen(Color.Gray, 2.0f))
            {
                //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                             
            }
        }
    }
}
