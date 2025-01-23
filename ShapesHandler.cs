namespace TetrisV2; 
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