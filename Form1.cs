using Timer = System.Windows.Forms.Timer;

namespace TetrisV2;

public partial class Form1 : Form
{
    Shape currentShape;
    Timer timer = new Timer();
    Bitmap canvasBitmap;
    Graphics canvasGraphics;
    int canvasWidth = 17;
    int canvasHeight = 20;
    int[,] canvasDotArray;
    int dotSize = 20;
    int currentX;
    int currentY;
    Bitmap workingBitmap;
    Graphics workingGraphics;
    
    public Form1()
    {
        InitializeComponent();
            
        LoadCanvas();
        currentShape = GetRandomShapeWithCenterAligned();

        timer.Tick += Timer_Tick;
        timer.Interval = 500;
        timer.Start();

        this.KeyDown += Form1_KeyDown;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
    // Make shapes move down every tick
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
    
    class Shape
    {
        public int Width;
        public int Height;
        public required int[,] Dots;

        private int[,] backupDots;

        public void Turn()
        {
            // back the dots values into backup dots
            // so that it can be simply used for rolling back
            backupDots = Dots;
            
            Dots = new int[Height, Width];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[Height - 1 - j, i];
                }
            }

            var temp = Width;
            Width = Height;
            Height = temp;
        }
        
        // the rolling back occurs when player rotating the shape
        // but it will touch other shapes and needs to be rolled back
        public void Rollback()
        {
            Dots = backupDots;
            
            var temp = Width;
            Width = Height;
            Height = temp;
        }
    }

    static class ShapesHandler
    {
    // Holds the different shapes
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

    private Shape GetRandomShapeWithCenterAligned()
    {
    // Drop shapes in the center
        var shape = ShapesHandler.GetRandomShape();
            
        // Calculate the x and y values as if the shape lies in the center
        currentX = 7;
        currentY = -shape.Height;

        return shape;
    }
    
    private bool MoveShapeIfPossible(int moveDown = 0, int moveSide = 0)
    {
    // Returns if it reaches the bottom or touches any other blocks
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
    
    private void DrawShape()
    {
    // Draws shapes with specified color
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

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        var verticalMove = 0;
        var horizontalMove = 0;
        
        // calculate the vertical and horizontal move values
        // based on the key pressed
        switch (e.KeyCode)
        {
            case Keys.Left:
                verticalMove--;
                break;
            case Keys.Right:
                verticalMove++;
                break;
            case Keys.Down:
                horizontalMove++;
                break;
            case Keys.Up:
                currentShape.Turn();
                break;
            default:
                return;
        }
        
        var isMoveSuccess = MoveShapeIfPossible(verticalMove, horizontalMove);
        
        // if the player was trying to rotate the shape, but
        // that move was not possible - rollback the shape
        if (!isMoveSuccess && e.KeyCode == Keys.Up)
        {
            currentShape.Rollback();
        }
    }
}
