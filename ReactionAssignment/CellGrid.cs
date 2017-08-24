
/*
 * CellGrid Class 
 * Author: Brendan Kelly
 * Date: 15 April 2017
 * Description: Holds and manages a 2 dimensional array of Cell objects
 */

using System.Threading;

namespace ReactionAssignment
{
    public class CellGrid
    {
        //threading
        private const int nThreads = 4;
        //divide 2d array of cells into two groups (do more division later, this is for testing) (must be that grid size is a power of 2)  
        private int groupSize;
        private int group1RowLow;
        private int group1RowHigh;
        private int group2RowLow;
        private int group2RowHigh;
        private int group3RowLow;
        private int group3RowHigh;
        private int group4RowLow;
        private int group4RowHigh;
        //end threading
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
            //set up threading groups
            groupSize = gridSize / nThreads;
            group1RowLow = 0;
            group1RowHigh = group1RowLow + groupSize - 1;
            group2RowLow = group1RowHigh + 1;
            group2RowHigh = group2RowLow + groupSize - 1;
            group3RowLow = group2RowHigh + 1;
            group3RowHigh = group3RowLow + groupSize - 1;
            group4RowLow = group3RowHigh + 1;
            group4RowHigh = group4RowLow + groupSize - 1;
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

        //use multithreading to computer all next concentrations
        public void ComputeAllNextConcentrationsMultiThread()
        {
            //process A
            cellThreadProcessor(Cell.EConcentrationType.A);
            //process B
            cellThreadProcessor(Cell.EConcentrationType.B);
        }

        //sub method for for ComputeAllNextConcentrationsMultiThread()
        private void cellThreadProcessor(Cell.EConcentrationType cellType)
        {
            Thread[] cellThreads = new Thread[nThreads];
            //make threads for each group
            //compute first group on first thread
            if (cellType == Cell.EConcentrationType.A)
            {
                cellThreads[0] = new Thread(() => computeSection(group1RowLow, group1RowHigh, Cell.EConcentrationType.A));
                cellThreads[1] = new Thread(() => computeSection(group2RowLow, group2RowHigh, Cell.EConcentrationType.A));
                cellThreads[2] = new Thread(() => computeSection(group3RowLow, group3RowHigh, Cell.EConcentrationType.A));
                cellThreads[3] = new Thread(() => computeSection(group4RowLow, group4RowHigh, Cell.EConcentrationType.A));
            }
            else
            {
                cellThreads[0] = new Thread(() => computeSection(group1RowLow, group1RowHigh, Cell.EConcentrationType.B));
                cellThreads[1] = new Thread(() => computeSection(group2RowLow, group2RowHigh, Cell.EConcentrationType.B));
                cellThreads[2] = new Thread(() => computeSection(group3RowLow, group3RowHigh, Cell.EConcentrationType.B));
                cellThreads[3] = new Thread(() => computeSection(group4RowLow, group4RowHigh, Cell.EConcentrationType.B));
            }
          
            //start groups
            for (int i = 0; i < nThreads; i++)
                cellThreads[i].Start();
              
            //make sure not to carry on until all threads are processed
            for (int i = 0; i < nThreads; i++)
                cellThreads[i].Join();
        }


        //sub method for for ComputeAllNextConcentrationsMultiThread()
        private void computeSection(int groupRowLow, int groupRowHigh, Cell.EConcentrationType cellType)
        {
            //for each cell in the give ngroup
            for (int col = 0; col < gridSize; col++)
                for (int row = groupRowLow; row <= groupRowHigh; row++)
                    //pick the right concentration and calculate it
                    if (cellType == Cell.EConcentrationType.A)               
                     Cells[col, row].ComputeNextConcentration(Cell.EConcentrationType.A, currentLaplacianFunction, diffA, diffB, feedA, killB);
                    else
                     Cells[col, row].ComputeNextConcentration(Cell.EConcentrationType.B, currentLaplacianFunction, diffA, diffB, feedA, killB);
        }


        //tells each to to update with its newly cacluated values
        public void UpdateAllCells()
        {
            foreach (Cell currentCell in Cells)
                currentCell.UpdateConcentrations();
        }

        //runs multithreaded version of updating cell concentrations
        public void UpdateAllCellsMultiThread()
        {
            Thread[] updateThreads = new Thread[nThreads];
            //make threads for each group
            updateThreads[0] = new Thread(() => updateSection(group1RowLow, group1RowHigh));
            updateThreads[1] = new Thread(() => updateSection(group2RowLow, group2RowHigh));
            updateThreads[2] = new Thread(() => updateSection(group3RowLow, group3RowHigh));
            updateThreads[3] = new Thread(() => updateSection(group4RowLow, group4RowHigh));

            //start groups
            for (int i = 0; i < nThreads; i++)
                updateThreads[i].Start();

            //make sure not to carry on until all threads are processed
            for (int i = 0; i < nThreads; i++)
                updateThreads[i].Join();
        }

        //sub method for for UpdateAllCellsMultiThread()
        private void updateSection(int groupRowLow, int groupRowHigh)
        {
            //for each cell in the give ngroup
            for (int col = 0; col < gridSize; col++)
                for (int row = groupRowLow; row <= groupRowHigh; row++)
                    //update the cell
                    Cells[col, row].UpdateConcentrations();
        }

    }
}
