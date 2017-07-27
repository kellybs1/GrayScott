
/*
 * LaplacianFunctionFactory Class 
 * Author: Brendan Kelly
 * Date: 17 April 2017
 * Description: Generates different Laplacian function based on input values
 */

namespace ReactionAssignment
{  
    public class LaplacianFunctionFactory
    {
        public LaplacianFunctionFactory()
        {
        }


        //generates a laplacian function object based on input choice
        public LaplacationFunction GenerateLaplacianFunction(LaplacationFunction.ELaplacianType laplacianChoice)
        {
            LaplacationFunction chosenFunction = null;

            //generate the chosen laplacian function
            switch (laplacianChoice)
            {
                case LaplacationFunction.ELaplacianType.Convolution:
                    chosenFunction = new LaplacianConvolution();
                    break;

                case LaplacationFunction.ELaplacianType.DeltaMeans:
                    chosenFunction = new LaplacianDeltaMeans();
                    break;

                case LaplacationFunction.ELaplacianType.Perpendicular:
                    chosenFunction = new LaplacianPerpendicular();
                    break;                   
            }

            return chosenFunction;
        }
    }
}
