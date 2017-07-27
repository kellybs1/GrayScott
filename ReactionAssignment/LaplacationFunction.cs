
/*
 * LaplacianFunction Class 
 * Author: Brendan Kelly
 * Date: 15 April 2017
 * Description: Base class for a single Laplacian function
 */

namespace ReactionAssignment
{
    
    public abstract class LaplacationFunction
    {
        public enum ELaplacianType { DeltaMeans,  Perpendicular, Convolution, };

        public double DiffA { get; set; }
        public double DiffB { get; set; }
        public LaplacationFunction()
        {
            //force diffs to be set
            SetDiffs();                    
        }


        public abstract double ComputeLaplacianValue(Cell currentCell, Cell[] neighbours, Cell.EConcentrationType chemical);

        public abstract void SetDiffs();


        //gets the current chemical concentration of given chemical
        public virtual double CurrentCellConcentration(Cell currentCell, Cell.EConcentrationType chemical)
        {
            double concentration = 0;
            switch (chemical)
            {
                case Cell.EConcentrationType.A:
                    concentration = currentCell.AConcentration;
                    break;

                case Cell.EConcentrationType.B:
                    concentration = currentCell.BConcentration;
                    break;
            }
            return concentration;
        }


        //gets the total concentration of given chemical from neighbours
        public virtual double TotalNeighbourConcentration(Cell.EConcentrationType chemical, Cell[] neighbours)
        {
            double total = 0;
            switch (chemical)
            {
                case Cell.EConcentrationType.A:
                    foreach (Cell neighbour in neighbours)
                    {
                        total += neighbour.AConcentration;
                    }
                    break;

                case Cell.EConcentrationType.B:
                    foreach (Cell neighbour in neighbours)
                    {
                        total += neighbour.BConcentration;
                    }
                    break;
            }
            return total;
        }


        //comprehensible ToString output
        public abstract override string ToString();         
    }


    public class LaplacianConvolution : LaplacationFunction
    {
        /*
         * LaplacianPerpendicular Class 
         * Author: Brendan Kelly
         * Date: 16 April 2017
         * Description: A descendant Laplacian function that calculates Laplacian value using the Perpendicular technique
         */

        public LaplacianConvolution()
        {
        }


        //set Diff constants
        public override void SetDiffs()
        {
            DiffA = Constants.DIFFA_CONVOLUTION_DELTAMEANS;
            DiffB = Constants.DIFFB_CONVOLUTION_DELTAMEANS;
        }


        //calculates the Lap value of a given cell's neighbours
        public override double ComputeLaplacianValue(Cell currentCell, Cell[] neighbours, Cell.EConcentrationType chemical)
        {
            //get adjusted total of neighbours concentrations
            double totalNeighbours = TotalNeighbourConcentration(chemical, neighbours);

            //multiply current cell's concentration
            double currentConcentration = CurrentCellConcentration(currentCell, chemical);

            //sum final value
            double final = totalNeighbours + currentConcentration;
            return final;
        }


        //gets the total concentration of given chemical from neighbours - ovverride includes calcuation with multiplier
        public override double TotalNeighbourConcentration(Cell.EConcentrationType chemical, Cell[] neighbours)
        {
            int nNeighbours = neighbours.Length;
            double total = 0;
            //Important: loops is this switch rely on array alternating diagonal and perpendicular
            switch (chemical)
            {
                case Cell.EConcentrationType.A:
                    for (int i = 0; i < nNeighbours; i++)
                    {
                        //if element position is even it is diagonal
                        if (i % 2 == 0)
                            total += (neighbours[i].AConcentration * Constants.CONVOLUTION_DIAGONAL_MULTIPLIER);
                        else
                            total += (neighbours[i].AConcentration * Constants.CONVOLUTION_PERPENDICULAR_MULTIPLIER);
                    }
                    break;

                case Cell.EConcentrationType.B:
                    for (int i = 0; i < nNeighbours; i++)
                    {
                        //if element position is even it is diagonal
                        if (i % 2 == 0)
                            total += (neighbours[i].BConcentration * Constants.CONVOLUTION_DIAGONAL_MULTIPLIER);
                        else
                            total += (neighbours[i].BConcentration * Constants.CONVOLUTION_PERPENDICULAR_MULTIPLIER);
                    }
                    break;
            }
            return total;
        }


        //gets the current chemical concentration of given chemical - override includes multiplier
        public override double CurrentCellConcentration(Cell currentCell, Cell.EConcentrationType chemical)
        {
            double concentration = 0;
            switch (chemical)
            {
                case Cell.EConcentrationType.A:
                    concentration = currentCell.AConcentration * Constants.CONVOLUTION_SELF_MULTIPLIER;
                    break;

                case Cell.EConcentrationType.B:
                    concentration = currentCell.BConcentration * Constants.CONVOLUTION_SELF_MULTIPLIER;
                    break;
            }
            return concentration;
        }


        public override string ToString()
        {
            return ELaplacianType.Convolution.ToString();
        }

    }



 
    public class LaplacianDeltaMeans : LaplacationFunction
    {
        /*
         * LaplacianDeltaMeans Class 
         * Author: Brendan Kelly
         * Date: 16 April 2017
         * Description: A descendant Laplacian function that calculates Laplacian value using the Delta Means technique
         */

        public LaplacianDeltaMeans()
        {
        }


        //set Diff constants
        public override void SetDiffs()
        {
            DiffA = Constants.DIFFA_CONVOLUTION_DELTAMEANS;
            DiffB = Constants.DIFFB_CONVOLUTION_DELTAMEANS;
        }


        //calculates the Lap value of a given cell's neighbours
        public override double ComputeLaplacianValue(Cell currentCell, Cell[] neighbours, Cell.EConcentrationType chemical)
        {
            //get the total of neighbour concentrations           
            double total = TotalNeighbourConcentration(chemical, neighbours);

            //average the total with number of neighbours
            int nNeighbours = neighbours.Length;
            double avgNeighbourConcentration = total / nNeighbours;

            //get the current cell's concentration 
            double currentConcentration = CurrentCellConcentration(currentCell, chemical);

            //difference between the two values
            double final = avgNeighbourConcentration - currentConcentration;

            return final;
        }

        public override string ToString()
        {
            return ELaplacianType.DeltaMeans.ToString();
        }

    }


    public class LaplacianPerpendicular : LaplacationFunction
    {

        /*
         * LaplacianPerpendicular Class 
         * Author: Brendan Kelly
         * Date: 16 April 2017
         * Description: A descendant Laplacian function that calculates Laplacian value using the Perpendicular technique
         */

        private double rh;
        public LaplacianPerpendicular()
        {

            //calculate rh
            double h = Constants.H1 / Constants.H2;
            rh = 1.0 / h / h;
        }


        //set Diff constants
        public override void SetDiffs()
        {
            DiffA = Constants.DIFFA_PERPENDICULAR;
            DiffB = Constants.DIFFB_PERPENDICULAR;
        }


        //calculates the Lap value of a given cell's neighbours
        public override double ComputeLaplacianValue(Cell currentCell, Cell[] neighbours, Cell.EConcentrationType chemical)
        {
            //get the total of neighbour concentrations           
            double totalNeighbours = TotalNeighbourConcentration(chemical, neighbours);
            //multiply current cell's concentration
            double concentration = CurrentCellConcentration(currentCell, chemical);
            double multiConcentration = concentration * Constants.PERPENDICULAR_CONCENTRATION_MULTIPLIER;
            //calculcate final value
            double final = rh * (totalNeighbours - multiConcentration);
            return final;
        }


        //gets the total concentration of given chemical from neighbours - override calculates for N,E,S,W neighbours only
        public override double TotalNeighbourConcentration(Cell.EConcentrationType chemical, Cell[] neighbours)
        {
            int nNeighbours = neighbours.Length;
            double total = 0;
            //Important: loops is this switch rely on array alternating diagonal and perpendicular
            switch (chemical)
            {
                case Cell.EConcentrationType.A:
                    for (int i = 0; i < nNeighbours; i++)
                    {
                        //if element position is odd it is perpendicular
                        if (i % 2 != 0)
                            total += neighbours[i].AConcentration;
                    }
                    break;

                case Cell.EConcentrationType.B:
                    for (int i = 0; i < nNeighbours; i++)
                    {
                        //if element position is odd it is perpendicular
                        if (i % 2 != 0)
                            total += neighbours[i].BConcentration;
                    }
                    break;
            }
            return total;
        }

        public override string ToString()
        {
            return ELaplacianType.Perpendicular.ToString();
        }
    }

}
