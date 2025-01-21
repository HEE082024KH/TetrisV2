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
    
    int currentX;
    int currentY;

    private Shape getRandomShapeWithCenterAligned()
    {
        var shape = ShapesHandler.GetRandomShape();
            
        // Calculate the x and y values as if the shape lies in the center
        currentX = 7;
        currentY = -shape.Height;

        return shape;
    }
    
    class Shape
    {
        public int Width;
        public int Height;
        public int[,] Dots;
    }
    
    static class ShapesHandler
    {
        private static Shape[] shapesArray;
        
        // static constructor : No need to manually initialize
        static ShapesHandler()
        {
            // Create shapes add into the array.
            shapesArray = new Shape[]
                {
                    new Shape {
                        Width = 2,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 1 },
                            { 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 1,
                        Height = 4,
                        Dots = new int[,]
                        {
                            { 1 },
                            { 1 },
                            { 1 },
                            { 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 1, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 0, 1 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 0, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 1, 1, 0 },
                            { 0, 1, 1 }
                        }
                    },
                    new Shape {
                        Width = 3,
                        Height = 2,
                        Dots = new int[,]
                        {
                            { 0, 1, 1 },
                            { 1, 1, 0 }
                        }
                    }
                    // new shapes can be added here..
                };
        }
        
        // Get a shape form the array in a random basis
        public static Shape GetRandomShape()
        {
            var shape = shapesArray[new Random().Next(shapesArray.Length)];

            return shape;
        }
    }
}