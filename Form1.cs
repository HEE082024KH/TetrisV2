namespace TetrisV2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
            
        loadCanvas();
    }
        
    Bitmap canvasBitmap;
    Graphics canvasGraphics;
    int canvasWidth = 15;
    int canvasHeight = 20;
    int[,] canvasDotArray;
    int dotSize = 20;

    private void loadCanvas()
    {
        // Resize the picture box based on the dotsize and canvas size
        pictureBox1.Width = canvasWidth * dotSize;
        pictureBox1.Height = canvasHeight * dotSize;

        // Create Bitmap with picture box's size
        canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        canvasGraphics = Graphics.FromImage(canvasBitmap);

        canvasGraphics.FillRectangle(Brushes.LightGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

        // Load bitmap into picture box
        pictureBox1.Image = canvasBitmap;
            
        // Initialize canvas dot array. by default all elements are zero
        canvasDotArray = new int[canvasWidth, canvasHeight];
    }
}