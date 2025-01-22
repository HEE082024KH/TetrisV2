using Timer = System.Windows.Forms.Timer;

namespace TetrisV2;

public partial class Form1 : Form
{
    Shape currentShape;
    Timer timer = new Timer();
    
    public Form1()
    {
        InitializeComponent();
            
        LoadCanvas();
        currentShape = GetRandomShapeWithCenterAligned();

        timer.Tick += Timer_Tick;
        timer.Interval = 500;
        timer.Start();
    }

    // Make shapes move down every tick
    private void Timer_Tick(object sender, EventArgs e)
    {
        var isMoveSuccess = MoveShapeIfPossible(moveDown: 1);

        // if shape reached bottom or touched any other shapes
        if (!isMoveSuccess)
        {
            // copy working image into canvas image
            canvasBitmap = new Bitmap(workingBitmap);

            UpdateCanvasDotArrayWithCurrentShape();
                
            // get next shape
            currentShape = GetRandomShapeWithCenterAligned();
        }
    }
    
    Bitmap canvasBitmap;
    Graphics canvasGraphics;
    int canvasWidth = 17;
    int canvasHeight = 20;
    int[,] canvasDotArray;
    int dotSize = 20;

    private void LoadCanvas()
    {
        // Resize the picture box based on the dotsize and canvas size
        pictureBox1.Width = canvasWidth * dotSize;
        pictureBox1.Height = canvasHeight * dotSize;

        // Create Bitmap with picture box's size
        canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        canvasGraphics = Graphics.FromImage(canvasBitmap);

        canvasGraphics.FillRectangle(Brushes.DarkSlateGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

        // Load bitmap into picture box
        pictureBox1.Image = canvasBitmap;
            
        // Initialize canvas dot array. by default all elements are zero
        canvasDotArray = new int[canvasWidth, canvasHeight];
    }
    
    int currentX;
    int currentY;
    
    class Shape
    {
        public int Width;
        public int Height;
        public required int[,] Dots;
    }

    // Holds the different shapes
    static class ShapesHandler
    {
        private static Shape[] shapesArray;
        
        // static constructor : No need to manually initialize
        static ShapesHandler()
        {
            // Create shapes add into the array.
            shapesArray = new[]
                {
                    new Shape
                    {
                        Width = 2,
                        Height = 2,
                        Dots = new[,]
                        {
                            { 1, 1 },
                            { 1, 1 }
                        }
                    },
                    new Shape
                    {
                        Width = 1,
                        Height = 4,
                        Dots = new[,]
                        {
                            { 0, 1 },
                            { 0, 1 },
                            { 0, 1 },
                            { 0, 1 }
                        }
                    },
                    new Shape 
                    {
                        Width = 3,
                        Height = 2,
                        Dots = new[,]
                        {
                            { 0, 1, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape 
                    {
                        Width = 3,
                        Height = 2,
                        Dots = new[,]
                        {
                            { 0, 0, 1 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape 
                    {
                        Width = 3,
                        Height = 2,
                        Dots = new[,]
                        {
                            { 1, 0, 0 },
                            { 1, 1, 1 }
                        }
                    },
                    new Shape 
                    {
                        Width = 3,
                        Height = 2,
                        Dots = new[,]
                        {
                            { 1, 1, 0 },
                            { 0, 1, 1 }
                        }
                    },
                    new Shape 
                    {
                        Width = 3,
                        Height = 2,
                        Dots = new[,]
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

    // Drop shapes in the center
    private Shape GetRandomShapeWithCenterAligned()
    {
        var shape = ShapesHandler.GetRandomShape();
            
        // Calculate the x and y values as if the shape lies in the center
        currentX = 7;
        currentY = -shape.Height;

        return shape;
    }
    
    // Returns if it reaches the bottom or touches any other blocks
    private bool MoveShapeIfPossible(int moveDown = 0, int moveSide = 0)
    {
        var newX = currentX + moveSide;
        var newY = currentY + moveDown;

        // check if it reaches the bottom or side bar
        if (newX < 0 || newX + currentShape.Width > canvasWidth
                     || newY + currentShape.Height > canvasHeight)
            return false;

        // check if it touches any other blocks 
        for (int i = 0; i < currentShape.Width; i++)
        {
            for (int j = 0; j < currentShape.Height; j++)
            {
                if (newY + j > 0 && canvasDotArray[newX + i, newY + j] == 1 && currentShape.Dots[j, i] == 1)
                    return false;
            }
        }

        currentX = newX;
        currentY = newY;

        DrawShape();

        return true;
    }

    Bitmap workingBitmap;
    Graphics workingGraphics;

    // Draws shapes with specified color
    private void DrawShape()
    {
        workingBitmap = new Bitmap(canvasBitmap);
        workingGraphics = Graphics.FromImage(workingBitmap);

        for (int i = 0; i < currentShape.Width; i++)
        {
            for (int j = 0; j < currentShape.Height; j++)
            {
                if (currentShape.Dots[j, i] == 1)
                    workingGraphics.FillRectangle(Brushes.LightSalmon, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
            }
        }

        pictureBox1.Image = workingBitmap;
    }
    
    private void UpdateCanvasDotArrayWithCurrentShape()
    {
        for (int i = 0; i < currentShape.Width; i++)
        {
            for (int j = 0; j < currentShape.Height; j++)
            {
                if (currentShape.Dots[j, i] == 1)
                {
                    CheckIfGameOver();

                    canvasDotArray[currentX + i, currentY + j] = 1;
                }
            }
        }
    }

    private void CheckIfGameOver()
    {
        if (currentY < 0)
        {
            timer.Stop();
            MessageBox.Show("Game Over");
            Application.Restart();
        }
    }
}
