
/*
 * Cell Class 
 * Author: Brendan Kelly
 * Date: 15 April 2017
 * Description: Holds and manages informatioh for a single cell 
 */


namespace ReactionAssignment
{
    
    public class Cell
    {
        public enum EConcentrationType { A, B };

        public Cell[] Neighbours { get; set; }
        public double AConcentration { get; set; }
        public double BConcentration { get; set; }
        private double nextAConcentration;
        private double nextBConcentration;



        public Cell(Cell[] inNeighbours)   
        {
            Neighbours = inNeighbours;
            AConcentration = Constants.CELL_START_A;
            BConcentration = Constants.CELL_START_B;
        }


        //computes concentration of A or B
        public void ComputeNextConcentration(EConcentrationType chemical, LaplacationFunction currentLaplacianFunction, 
                                             double diffA, double diffB, double feedA, double killB)
        {
            double ABSquared = AConcentration * BConcentration * BConcentration; //used in both equations

            switch (chemical)
            {
                case EConcentrationType.A:
                    //calculate sections
                    double lapA = currentLaplacianFunction.ComputeLaplacianValue(this, Neighbours, EConcentrationType.A);
                    double diffALapA = diffA * lapA;                   
                    double feedA1MinusA = feedA * (1 - AConcentration);
                    //final calculation
                    double nextAConcentrationDirty = AConcentration + diffALapA - ABSquared + feedA1MinusA;
                    nextAConcentration = FixConcentrationRounding(nextAConcentrationDirty);
                    break;

                case EConcentrationType.B:
                    //calculate sections
                    double lapB = currentLaplacianFunction.ComputeLaplacianValue(this, Neighbours, EConcentrationType.B);
                    double diffBLapB = diffB * lapB;
                    double killBPlusFeedAB = (killB + feedA) * BConcentration;
                    //final calculation
                    double nextBConcentrationDirty = BConcentration + diffBLapB + ABSquared - killBPlusFeedAB;
                    nextBConcentration = FixConcentrationRounding(nextBConcentrationDirty);
                    break;
            }
        }


        //fix rounding on rounding errors
        private double FixConcentrationRounding(double concentration)
        {
            if (concentration < 0)
                concentration = 0.0;

            if (concentration > 1)
                concentration = 1.0;

            return concentration;
        }


        //updates current concentrations with next values
        public void UpdateConcentrations()
        {
            AConcentration = nextAConcentration;
            BConcentration = nextBConcentration;
        }

     
    }
  
}
