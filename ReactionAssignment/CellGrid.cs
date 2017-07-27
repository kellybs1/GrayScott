
/*
 * CellGrid Class 
 * Author: Brendan Kelly
 * Date: 15 April 2017
 * Description: Holds and manages a 2 dimensional array of Cell objects
 */

namespace ReactionAssignment
{
    public class CellGrid
    {
        public Cell[,] Cells { get; set; }
        private int gridSize;
        private double feedA;
        private double killB;
        private double diffA;
        private double diffB;
        private ISeeder currentSeeder;
        private LaplacationFunction currentLaplacianFunction;

        public CellGrid(double inFeedA, double inKillB, LaplacationFunction inLaplacianFunction, ISeeder chosenSeeder)
        {
            feedA = inFeedA;
            killB = inKillB;
            gridSize = Constants.GRID_SIZE_LARGE;
            Cells = new Cell[gridSize, gridSize];
            currentLaplacianFunction = inLaplacianFunction;
            diffA = currentLaplacianFunction.DiffA;
            diffB = currentLaplacianFunction.DiffB;
            currentSeeder = chosenSeeder;
            //set the cells up
            initialiseCells();
            generateNeighbours();
            currentSeeder.SeedGrid(Cells);
        }


        //initialises all cells with their array of neighbours
        private void initialiseCells()
        {
            //for each cell in column
            for (int col = 0; col < gridSize; col++)
            {
                //for each cell in row
                for (int row = 0; row < gridSize; row++)
                {
                    //get neighbours
                    Cell[] neighbours = new Cell[Constants.N_CELL_NEIGHBOURS];
                    //make a new Cell and give it the neighbours
                    Cell newCell = new Cell(neighbours);
                    Cells[col, row] = newCell;
                }
            }                                                         
        }


        //generates the neighbours for a cell based on its col and row values
        private void generateNeighbours()
        {
            //for each cell in column
            for (int col = 0; col < gridSize; col++)
            {
                //for each cell in row
                for (int row = 0; row < gridSize; row++)
                {

                    //define area around cell
                    int colLeft = col - 1;
                    int colRight = col + 1;
                    int rowAbove = row - 1;
                    int rowBelow = row + 1;

                    //wrap edges
                    if (colLeft < 0)
                        colLeft = gridSize - 1;

                    if (colRight > gridSize - 1)
                        colRight = 0;

                    if (rowAbove < 0)
                        rowAbove = gridSize - 1;

                    if (rowBelow > gridSize - 1)
                        rowBelow = 0;

                    //assign neighbours - IMPORTANT that North-west is neighbour 0 for perpendicular
                    Cells[col, row].Neighbours[0] = Cells[colLeft, rowAbove];           //NW
                    Cells[col, row].Neighbours[1] = Cells[col, rowAbove];               //N
                    Cells[col, row].Neighbours[2] = Cells[colRight, rowAbove];          //NE
                    Cells[col, row].Neighbours[3] = Cells[colRight, row];               //E
                    Cells[col, row].Neighbours[4] = Cells[colRight, rowBelow];          //SE
                    Cells[col, row].Neighbours[5] = Cells[col, rowBelow];               //S
                    Cells[col, row].Neighbours[6] = Cells[colLeft, rowBelow];           //SW
                    Cells[col, row].Neighbours[7] = Cells[colLeft, row];                //W

                }
            }
        }
   

        //tells all cells to compute their new concentrations
        public void ComputeAllNextConcentrations()
        {
            foreach (Cell currentCell in Cells)
            {
                currentCell.ComputeNextConcentration(Cell.EConcentrationType.A, currentLaplacianFunction, diffA, diffB, feedA, killB);
                currentCell.ComputeNextConcentration(Cell.EConcentrationType.B, currentLaplacianFunction, diffA, diffB, feedA, killB);
            }
        }


        //tells each to to update with its newly cacluated values
        public void UpdateAllCells()
        {
            foreach (Cell currentCell in Cells)
                currentCell.UpdateConcentrations();
        }

    }
}
