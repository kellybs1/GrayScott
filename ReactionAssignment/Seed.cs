using System;
using System.Linq;
namespace ReactionAssignment
{

    public enum ESeedingAlgorithmType { CentreFour, FourCorners, RandomFour, RandomSixteen, CentreSixteen, CentreSixtyFour }
    public interface ISeeder
    {
        /*
         * ISeeder Interface
         * Author: Brendan Kelly
         * Date: 25 April 2017
         * Description: Interface that defines method to be implemented by classes that provide initial seeding to the main grid of cells
         */

        void SeedGrid(Cell[,] cellGrid);
    }


    public class SeedCenterSixteen : ISeeder
    {

        /*
         * SeedCentreSixteen Class 
         * Author: Brendan Kelly
         * Date: 26 April 2017
         * Description: Class algorithm seeds sixteen cells in center of grid
         */

        public SeedCenterSixteen()
        {
        }

        public void SeedGrid(Cell[,] cellGrid)
        {
            //gridsize
            int gridSize = Constants.GRID_SIZE_LARGE;
            //find start cell
            int col0 = (gridSize / 2) - Constants.SIXTEEN_CENTER_OFFSET;
            //find limits
            int colMax = col0 + Constants.SIXTEEN_CENTER_SIZE;
            int rowMax = colMax;


            for (int col = col0; col < colMax; col++)
            {
                for (int row = col0; row < rowMax; row++)
                {
                    cellGrid[col, row].AConcentration = Constants.CELL_START_B;
                    cellGrid[col, row].BConcentration = Constants.CELL_START_A;
                }
            }
        }


        public override string ToString()
        {
            return ESeedingAlgorithmType.CentreSixteen.ToString();
        }
    }


    public class SeedCenterSixtyFour : ISeeder
    {
        /*
         * SeedCentreSixtyFour Class 
         * Author: Brendan Kelly
         * Date: 26 April 2017
         * Description: Class algorithm seeds 64 cells in center of grid
         */
        public void SeedGrid(Cell[,] cellGrid)
        {
            //gridsize
            int gridSize = Constants.GRID_SIZE_LARGE;
            //find start cell
            int col0 = (gridSize / 2) - Constants.SIXTYFOUR_CENTER_OFFSET;
            //find limits
            int colMax = col0 + Constants.SIXTYFOUR_CENTER_SIZE;
            int rowMax = colMax;


            for (int col = col0; col < colMax; col++)
            {
                for (int row = col0; row < rowMax; row++)
                {
                    cellGrid[col, row].AConcentration = Constants.CELL_START_B;
                    cellGrid[col, row].BConcentration = Constants.CELL_START_A;
                }
            }
        }


        public override string ToString()
        {
            return ESeedingAlgorithmType.CentreSixtyFour.ToString();
        }
    }


    public class SeedCentreFour : ISeeder
    {
        /*
         * SeedCentreFour Class 
         * Author: Brendan Kelly
         * Date: 25 April 2017
         * Description: Class algorithm seeds four cells in center of grid
         */
        public SeedCentreFour()
        {
        }

        public void SeedGrid(Cell[,] cellGrid)
        {
            //gridsize
            int gridSize = Constants.GRID_SIZE_LARGE;
            //find start cell
            int col0 = (gridSize / 2) - 1;
            int row0 = col0;
            //find limit
            int colMax = col0 + Constants.FOUR_CENTER_SIZE;
            int rowMax = row0 + Constants.FOUR_CENTER_SIZE;

            for (int col = col0; col < colMax; col++)
            {
                for (int row = row0; row < rowMax; row++)
                {
                    cellGrid[col, row].AConcentration = Constants.CELL_START_B;
                    cellGrid[col, row].BConcentration = Constants.CELL_START_A;
                }
            }
        }
        public override string ToString()
        {
            return ESeedingAlgorithmType.CentreFour.ToString();
        }
    }


    public class SeedFourCorners : ISeeder
    {
        /*
         * SeedFourCorners Class 
         * Author: Brendan Kelly
         * Date: 25 April 2017
         * Description: Class algorithm seeds four cornermost cells in a grid
         */

        public void SeedGrid(Cell[,] cellGrid)
        {
            //gridsize
            int gridSize = Constants.GRID_SIZE_LARGE;

            int col0 = 0;
            int col1 = gridSize - 1;
            int row0 = 0;
            int row1 = gridSize - 1;
            //a
            cellGrid[col0, row0].AConcentration = Constants.CELL_START_B;
            cellGrid[col1, row0].AConcentration = Constants.CELL_START_B;
            cellGrid[col0, row1].AConcentration = Constants.CELL_START_B;
            cellGrid[col1, row1].AConcentration = Constants.CELL_START_B;
            //b
            cellGrid[col0, row0].BConcentration = Constants.CELL_START_A;
            cellGrid[col1, row0].BConcentration = Constants.CELL_START_A;
            cellGrid[col0, row1].BConcentration = Constants.CELL_START_A;
            cellGrid[col1, row1].BConcentration = Constants.CELL_START_A;
        }


        public override string ToString()
        {
            return ESeedingAlgorithmType.FourCorners.ToString();
        }
    }


    public class SeedRandomFour : ISeeder
    {
        /*
         * SeedRandomFour Class 
         * Author: Brendan Kelly
         * Date: 25 April 2017
         * Description: Class algorithm seeds four random cells
         */


        private Random rand;
        public SeedRandomFour()
        {
            rand = new Random();
        }

        public void SeedGrid(Cell[,] cellGrid)
        {
            //gridsize
            int max = Constants.GRID_SIZE_LARGE - 1;

            int nCellsToSeed = Constants.FOUR_RAND_COUNT;

            Cell[] chosen = new Cell[nCellsToSeed];
            int col = rand.Next(max);
            int row = rand.Next(max);
            for (int i = 0; i < nCellsToSeed; i++)
            {
                //keep regenerating randoms until we're using different cells
                while (chosen.Contains(cellGrid[col, row]))
                {
                    col = rand.Next(max);
                    row = rand.Next(max);
                }
                //add it to chosen
                chosen[i] = cellGrid[col, row];
                //seed
                cellGrid[col, row].AConcentration = Constants.CELL_START_B;
                cellGrid[col, row].BConcentration = Constants.CELL_START_A;
            }
        }


        public override string ToString()
        {
            return ESeedingAlgorithmType.RandomFour.ToString();
        }
    }



    public class SeedRandomSixteen : ISeeder
    {
        /*
         * SeedRandomFour Class 
         * Author: Brendan Kelly
         * Date: 25 April 2017
         * Description: Class algorithm seeds sixteen random cells
         */

        private Random rand;

        public SeedRandomSixteen()
        {
            rand = new Random();
        }

        public void SeedGrid(Cell[,] cellGrid)
        {
            //gridsize
            int max = Constants.GRID_SIZE_LARGE - 1;

            int nCellsToSeed = Constants.SIXTEEN_RAND_COUNT;

            Cell[] chosen = new Cell[nCellsToSeed];
            int col = rand.Next(max);
            int row = rand.Next(max);
            for (int i = 0; i < nCellsToSeed; i++)
            {
                //keep regenerating randoms until we're using different cells
                while (chosen.Contains(cellGrid[col, row]))
                {
                    col = rand.Next(max);
                    row = rand.Next(max);
                }
                //add it to chosen
                chosen[i] = cellGrid[col, row];
                //seed
                cellGrid[col, row].AConcentration = Constants.CELL_START_B;
                cellGrid[col, row].BConcentration = Constants.CELL_START_A;
            }
        }


        public override string ToString()
        {
            return ESeedingAlgorithmType.RandomSixteen.ToString();
        }
    }
}
