
/*
 * ShadingAlgorithmFactory class
 * Author: Brendan Kelly
 * Date: 19 April 2017
 * Description: Class that generates IshadingAlgorithm-implementing objects based on input
 */


namespace ReactionAssignment
{
    public class ShadingAlgorithmFactory
    {
        public ShadingAlgorithmFactory()
        {
        }

        public IShadingAlgorithm GenerateShadingAlgorithm(EShadingAlgorithmType shaderChoice)
        {
            IShadingAlgorithm chosenShader = null;
            //pick the shading algorith based on choice
            switch (shaderChoice)
            {
                case EShadingAlgorithmType.Greyscale:
                    chosenShader = new GreyScaleShader();
                    break;

                case EShadingAlgorithmType.ShortRainbow:
                    chosenShader = new ShortRainbowShader();
                    break;

                case EShadingAlgorithmType.LongRainbow:
                    chosenShader = new LongRainbowShader();
                    break;
            }

            return chosenShader;
        }
    }
}
