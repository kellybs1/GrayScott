
/*
 * Constants Class 
 * Author: Brendan Kelly
 * Date: 15 April 2017
 * Description: Holds constant values to be used throughout the ReactionAssignment project
 */


namespace ReactionAssignment
{
    public static class Constants
    {
        //Seeding
        public static int FOUR_CENTER_SIZE = 2;
        public static int FOUR_RAND_COUNT = 4;
        public static int SIXTEEN_CENTER_SIZE = 4;
        public static int SIXTEEN_CENTER_OFFSET = 2;
        public static int SIXTEEN_RAND_COUNT = 16;
        public static int SIXTYFOUR_CENTER_SIZE = 8;
        public static int SIXTYFOUR_CENTER_OFFSET = 4;

        //---------------------------------------------------------------------------------------------

        //Drawing
        public static int GRID_PANEL_SIZE = 256; //this is the size of the panel on the form

        //---------------------------------------------------------------------------------------------

        //Shading
        public static int MAX_RGB_VALUE = 255;
        public static double SHORT_RAINBOW_GROUP_DIVIDER = 0.25;
        public static double LONG_RAINBOW_GROUP_DIVIDER = 0.2;

        //---------------------------------------------------------------------------------------------

        //Cell
        public static double CELL_START_A = 1.0;
        public static double CELL_START_B = 0.0;

        //---------------------------------------------------------------------------------------------

        //CellGrid
        public static int N_CELL_NEIGHBOURS = 8;
        public static int GRID_SIZE_LARGE = 64;

        //---------------------------------------------------------------------------------------------

        //Laplacian - General
        public static double DIFFA_PERPENDICULAR = 0.00002;
        public static double DIFFB_PERPENDICULAR = 0.00001;
        public static double DIFFA_CONVOLUTION_DELTAMEANS = 1.0;
        public static double DIFFB_CONVOLUTION_DELTAMEANS = 0.5;

        //Laplacian - Perpendicular
        public static double H1 = 2.5;
        public static double H2 = 127;
        public static double PERPENDICULAR_CONCENTRATION_MULTIPLIER = 4.0;

        //Laplacian - Convolution
        public static double CONVOLUTION_DIAGONAL_MULTIPLIER = 0.05;
        public static double CONVOLUTION_PERPENDICULAR_MULTIPLIER = 0.2;
        public static double CONVOLUTION_SELF_MULTIPLIER = -1.0;

        //---------------------------------------------------------------------------------------------
    }
}
