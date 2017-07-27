using System;
using System.Drawing;

namespace ReactionAssignment
{

    public enum EShadingAlgorithmType { Greyscale, ShortRainbow, LongRainbow }
    public interface IShadingAlgorithm
    {
        /*
     * IShadingAlgorithm Interface
     * Author: Brendan Kelly
     * Date: 18 April 2017
     * Description: Interface that defines method to be implemented by classes that apply shading algoriths
     */

        Color ShadeCell(double concentration);
    }



    public class ShortRainbowShader : IShadingAlgorithm
    {
        /*
         * ShortRainbowShader class
         * Author: Brendan Kelly
         * Date: 24 April 2017
         * Description: IShadingAlgorith implementer that shades using a short rainbow algorithm from https://www.particleincell.com/2014/colormap/
         */

        //https://www.particleincell.com/2014/colormap/


        public ShortRainbowShader()
        {
        }

        public Color ShadeCell(double concentration)
        {
            //invert and group
            double invertedGrouping = (1 - concentration) / Constants.SHORT_RAINBOW_GROUP_DIVIDER;
            //integer to divide grouping by
            int colourSplitter = (int)Math.Floor(invertedGrouping);
            //fractional part from 0-255
            int colourFraction = (int)Math.Floor(Constants.MAX_RGB_VALUE * (invertedGrouping - colourSplitter));
            //return correct colour
            Color outColour = Color.FromArgb(0, 0, 0);
            switch (colourSplitter)
            {
                case 0:
                    outColour = Color.FromArgb(Constants.MAX_RGB_VALUE, colourFraction, 0);
                    break;

                case 1:
                    outColour = Color.FromArgb(Constants.MAX_RGB_VALUE - colourFraction, Constants.MAX_RGB_VALUE, 0);
                    break;

                case 2:
                    outColour = Color.FromArgb(0, Constants.MAX_RGB_VALUE, colourFraction);
                    break;

                case 3:
                    outColour = Color.FromArgb(0, Constants.MAX_RGB_VALUE - colourFraction, Constants.MAX_RGB_VALUE);
                    break;

                case 4:
                    outColour = Color.FromArgb(0, 0, Constants.MAX_RGB_VALUE);
                    break;
            }

            return outColour;
        }


        //comprehensible string output
        public override string ToString()
        {
            return EShadingAlgorithmType.ShortRainbow.ToString();
        }
    }



    public class LongRainbowShader : IShadingAlgorithm
    {
        /*
         * LongRainbowShader class
         * Author: Brendan Kelly
         * Date: 24 April 2017
         * Description: IShadingAlgorith implementer that shades using a longrainbow algorithm from https://www.particleincell.com/2014/colormap/
         */


        //https://www.particleincell.com/2014/colormap/

        public LongRainbowShader()
        {
        }

        public Color ShadeCell(double concentration)
        {
            //invert and group
            double invertedGrouping = (1 - concentration) / Constants.LONG_RAINBOW_GROUP_DIVIDER;
            //integer to divide grouping by
            int colourSplitter = (int)Math.Floor(invertedGrouping);
            //fractional part from 0-255
            int colourFraction = (int)Math.Floor(Constants.MAX_RGB_VALUE * (invertedGrouping - colourSplitter));
            //return correct colour
            Color outColour = Color.FromArgb(0, 0, 0);
            switch (colourSplitter)
            {
                case 0:
                    outColour = Color.FromArgb(Constants.MAX_RGB_VALUE, colourFraction, 0);
                    break;

                case 1:
                    outColour = Color.FromArgb(Constants.MAX_RGB_VALUE - colourFraction, Constants.MAX_RGB_VALUE, 0);
                    break;

                case 2:
                    outColour = Color.FromArgb(0, Constants.MAX_RGB_VALUE, colourFraction);
                    break;

                case 3:
                    outColour = Color.FromArgb(0, Constants.MAX_RGB_VALUE - colourFraction, Constants.MAX_RGB_VALUE);
                    break;

                case 4:
                    outColour = Color.FromArgb(colourFraction, 0, Constants.MAX_RGB_VALUE);
                    break;

                case 5:
                    outColour = Color.FromArgb(Constants.MAX_RGB_VALUE, 0, Constants.MAX_RGB_VALUE);
                    break;
            }

            return outColour;
        }


        //comprehensible string output
        public override string ToString()
        {
            return EShadingAlgorithmType.LongRainbow.ToString();
        }
    }



    public class GreyScaleShader : IShadingAlgorithm
    {
        /*
         * GreyScaleShader class
         * Author: Brendan Kelly
         * Date: 18 April 2017
         * Description: IShadingAlgorith implementer that shades in greyscale
         */

        //https://www.particleincell.com/2014/colormap/

        public GreyScaleShader()
        {
        }


        public Color ShadeCell(double concentration)
        {
            //normalize
            double x = concentration * Constants.MAX_RGB_VALUE;
            int y = (int)Math.Floor(x);
            Color outColour = Color.FromArgb(y, y, y);
            return outColour;
        }


        //comprehensible string output
        public override string ToString()
        {
            return EShadingAlgorithmType.Greyscale.ToString();
        }
    }
}
