using System;
using System.Drawing;
using System.Windows.Forms;

/*
 * SimulationManager Class 
 * Author: Brendan Kelly
 * Date: 19 April 2017
 * Description: Overall class for managing simulation cycle and interaction between form controls and simualtion objects
 */

namespace ReactionAssignment
{
    public class SimulationManager
    {
        private GridDisplayManager displayManager;
        private LaplacationFunction currentLaplacianFunction;
        private LaplacianFunctionFactory laplacianFactory;
        private IShadingAlgorithm currentShadingAlgorithm;
        private ShadingAlgorithmFactory shadingFactory;
        private SeedFactory seedFactory;
        private CellGrid currentCellGrid;
        private FileManager fileMan;
        private ISeeder currentSeedAlgorithm;
        private double feedA;
        private double killB;

        public SimulationManager(double inFeedA, double inKillB, EShadingAlgorithmType chosenShader, 
            LaplacationFunction.ELaplacianType chosenlapFunction, GridDisplayManager inDisplayManager, ESeedingAlgorithmType chosenSeeder)
        {          
            fileMan = new FileManager();
            laplacianFactory = new LaplacianFunctionFactory();
            shadingFactory = new ShadingAlgorithmFactory();
            seedFactory = new SeedFactory();
            feedA = inFeedA;
            killB = inKillB;
            currentSeedAlgorithm = seedFactory.GenerateSeedAlgorithm(chosenSeeder);
            currentLaplacianFunction = laplacianFactory.GenerateLaplacianFunction(chosenlapFunction);
            currentShadingAlgorithm = shadingFactory.GenerateShadingAlgorithm(chosenShader);
            currentCellGrid = new CellGrid(feedA, killB, currentLaplacianFunction, currentSeedAlgorithm);
            displayManager = inDisplayManager;
        }


        //runs through cycle of method calls required for each cycle of simulation
        public void SimulationCycle()
        {
            currentCellGrid.ComputeAllNextConcentrations();
            currentCellGrid.UpdateAllCells();
            displayManager.ShadeGrid(currentCellGrid.Cells, currentShadingAlgorithm);
            displayManager.DrawToScreen();
        }


        //runs through cycle of method calls required for each cycle of simulation without drawing anything to screen
        public void SimulationCycleNoDraw()
        {
            currentCellGrid.ComputeAllNextConcentrations();
            currentCellGrid.UpdateAllCells();
        }


        //saves image file
        public void SaveImage()
        {
            Bitmap currentImage = displayManager.OffScreenBitmap;
            string lap = currentLaplacianFunction.ToString();
            string shader = currentShadingAlgorithm.ToString();
            string seed = currentSeedAlgorithm.ToString();
            fileMan.SaveImage(currentImage, feedA, killB, shader, lap, seed);
        }


        //runs batch processed simulation
        public void BatchSimulation(int nLoops, double feedAStart, double feedAEnd, double killBStart, double killBEnd)
        {
            //translate feed and kill to loop counters
            int outerStart = Convert.ToInt32(feedAStart * 1000);
            int outerEnd = Convert.ToInt32(feedAEnd * 1000);
            int innerStart = Convert.ToInt32(killBStart * 1000);
            int innerEnd = Convert.ToInt32(killBEnd * 1000);

            //start loops
            //for each value from start feeda to finish feeda
            for (int fA = outerStart; fA <= outerEnd; fA++)
            {
                double currentFeedA = (double)fA / 1000;
                feedA = currentFeedA;
                //for each value from start killb to finish killb
                for (int kB = innerStart; kB <= innerEnd; kB++)
                {
                    double currentKillB = (double)kB / 1000;
                    killB = currentKillB;
                    //make a new cell grid with these values
                    currentCellGrid = new CellGrid(currentFeedA, currentKillB, currentLaplacianFunction, currentSeedAlgorithm);
                    for (int iter = 0; iter < nLoops; iter++)
                    {
                        //run through the simulation cycle 
                        SimulationCycleNoDraw();
                    }
                    //finshed loops so shade and save image
                    displayManager.ShadeGrid(currentCellGrid.Cells, currentShadingAlgorithm);
                    displayManager.DrawToScreen();
                    SaveImage();
                }
            }
            MessageBox.Show("Batch Simulation complete");
        }
    }
}
