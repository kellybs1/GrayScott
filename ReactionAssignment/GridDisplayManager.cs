
using System.Drawing;

/*
 * GridDisplayManager Class 
 * Author: Brendan Kelly
 * Date: 19 April 2017
 * Description: Class responsible for turning a grid of cells into a shaded bitmap
 */

namespace ReactionAssignment
{ 
    public class GridDisplayManager
    {      
        private Graphics offScreenCanvas;
        private Graphics mainCanvas;
        private Bitmap offScreenBitmap;
        private int cellSize;
        private int nCols;
        private int nRows;

        public GridDisplayManager(Bitmap inOffScreenBitmap, Graphics inOffScreenCanvas, Graphics inMainCanvas)
        {
            mainCanvas = inMainCanvas;
            offScreenCanvas = inOffScreenCanvas;
            offScreenBitmap = inOffScreenBitmap;
            cellSize = Constants.GRID_PANEL_SIZE / Constants.GRID_SIZE_LARGE;
            //get 2D array width and height
            nRows = Constants.GRID_SIZE_LARGE;
            nCols = Constants.GRID_SIZE_LARGE;
        }


        //draws the shaded grid to buffer
        public void ShadeGrid(Cell[,] cells, IShadingAlgorithm currentShader)
        {
            //for each column
            for (int col = 0; col < nCols; col++)
            {
                //for each row
                for (int row = 0; row < nRows; row++)
                {
                    //get the concentration
                    double currentCellB = cells[col, row].BConcentration;
                    //generate colour and brush
                    Color cellColour = currentShader.ShadeCell(currentCellB);
                    Brush drawBrush = new SolidBrush(cellColour);
                    //find the right spot for this cell's rectangle
                    int xPos = col * cellSize;
                    int yPos = row * cellSize;
                    //draw the rectangle
                    Rectangle drawRect = new Rectangle(xPos, yPos, cellSize, cellSize);
                    offScreenCanvas.FillRectangle(drawBrush, drawRect);
                }
            }
        }


        //draws current buffer to panel
        public void DrawToScreen()
        {
            mainCanvas.DrawImage(offScreenBitmap, 0, 0);
        }



        //tests drawing to canvas actually works
        private void TestDraw()
        {
            Rectangle drawrect = new Rectangle(0, 0, Constants.GRID_PANEL_SIZE, Constants.GRID_PANEL_SIZE);
            Brush fill = new SolidBrush(Color.Green);
            offScreenCanvas.FillRectangle(fill, drawrect);
        }


        //properties
        public Bitmap OffScreenBitmap
        { get { return offScreenBitmap; } set { offScreenBitmap = value; } }
    }
}
