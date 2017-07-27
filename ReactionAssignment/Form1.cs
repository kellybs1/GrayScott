using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactionAssignment
{
    public partial class Form1 : Form
    {
        private Graphics mainCanvas;
        private Bitmap offScreenBitmap;
        private Graphics offScreenCanvas;
        private GridDisplayManager displayManager;
        private SimulationManager simManager;
        private EShadingAlgorithmType chosenShader;
        private LaplacationFunction.ELaplacianType chosenLapFunction;
        private ESeedingAlgorithmType chosenSeed;
        private double chosenFeedA;
        private double chosenKillB;
        private double chosenFeedAStart;
        private double chosenFeedAEnd;
        private double chosenKillBStart;
        private double chosenKillBEnd;
        private int iterationCount;
        private int nLoops;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            formInit();                         
        }


        //initliases required form settings
        private void formInit()
        {
            buttonPause.Enabled = false;
            iterationCount = 0;
            //force picturebox to constant size - just in case
            panelGridDisplay.Width = Constants.GRID_PANEL_SIZE;
            panelGridDisplay.Height = Constants.GRID_PANEL_SIZE;

            //buffer graphics stuff
            offScreenBitmap = new Bitmap(panelGridDisplay.Width, panelGridDisplay.Height);
            offScreenCanvas = Graphics.FromImage(offScreenBitmap); 
            mainCanvas = panelGridDisplay.CreateGraphics();

            //comboboxes
            comboBoxLaplacian.DataSource = Enum.GetValues(typeof(LaplacationFunction.ELaplacianType));
            comboBoxShader.DataSource = Enum.GetValues(typeof(EShadingAlgorithmType));
            comboBoxSeed.DataSource = Enum.GetValues(typeof(ESeedingAlgorithmType));
        }


        //sets creation values from current form control selections
        private void setValuesFromForm()
        {
            //main
            chosenShader = (EShadingAlgorithmType)comboBoxShader.SelectedItem;
            chosenLapFunction = (LaplacationFunction.ELaplacianType)comboBoxLaplacian.SelectedItem;
            chosenSeed = (ESeedingAlgorithmType)comboBoxSeed.SelectedItem;
            //observable
            chosenFeedA = Convert.ToDouble(numericUpDownFeedA.Value);
            chosenKillB = Convert.ToDouble(numericUpDownKillB.Value);
            //batch
            nLoops = Convert.ToInt32(numericUpDownNLoops.Value);
            chosenFeedAStart = Convert.ToDouble(numericUpDownFeedABatchStart.Value);
            chosenFeedAEnd = Convert.ToDouble(numericUpDownFeedABatchEnd.Value);
            chosenKillBStart = Convert.ToDouble(numericUpDownKillBBatchStart.Value);
            chosenKillBEnd = Convert.ToDouble(numericUpDownKillBBatchEnd.Value);
        }


        //generates managing objects - must be run after setValuesFromForm
        private void generateManagers()
        {
            displayManager = new GridDisplayManager(offScreenBitmap, offScreenCanvas, mainCanvas);
            simManager = new SimulationManager(chosenFeedA, chosenKillB, chosenShader, chosenLapFunction, displayManager, chosenSeed);
        }

 
        //Go button click handler
        private void button1_Click(object sender, EventArgs e)
        {
            disableBatchControls();
            setValuesFromForm();
            generateManagers();
            iterationCount = 0;
            buttonPause.Enabled = true;
            timer1.Enabled = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            simManager.SimulationCycle();
            iterationCount++;
            labelIteration.Text = "Iteration " + iterationCount;
        }


        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            simManager.SaveImage();
        }


        //runs a batch process
        private void buttonBatch_Click(object sender, EventArgs e)
        {
            disableObservableControls();
            setValuesFromForm();
            generateManagers();
            simManager.BatchSimulation(nLoops, chosenFeedAStart, chosenFeedAEnd, chosenKillBStart, chosenKillBEnd);
        }


        //disables the form controls for observable simulation
        private void disableObservableControls()
        {
            timer1.Enabled = false;
            buttonGo.Enabled = false;
            buttonPause.Enabled = false;
            buttonSaveImage.Enabled = false;
            numericUpDownFeedA.Enabled = false;
            numericUpDownKillB.Enabled = false;
        }


        //enables the form controls for observable simulation
        private void enableObservableControls()
        {
            //not the timer
            buttonGo.Enabled = true;
            buttonPause.Enabled = true;
            buttonSaveImage.Enabled = true;
            numericUpDownFeedA.Enabled = true;
            numericUpDownKillB.Enabled = true;
        }


        //disables batch simulation controls
        private void disableBatchControls()
        {
            buttonBatch.Enabled = false;
            numericUpDownFeedABatchEnd.Enabled = false;
            numericUpDownFeedABatchStart.Enabled = false;
            numericUpDownKillBBatchEnd.Enabled = false;
            numericUpDownKillBBatchStart.Enabled = false;
            numericUpDownNLoops.Enabled = false;
        }


        //enables batch simulation controls
        private void enableBatchControls()
        {
            buttonBatch.Enabled = true;
            numericUpDownFeedABatchEnd.Enabled = true;
            numericUpDownFeedABatchStart.Enabled = true;
            numericUpDownKillBBatchEnd.Enabled = true;
            numericUpDownKillBBatchStart.Enabled = true;
            numericUpDownNLoops.Enabled = true;
        }


        //toggles timer
        private void buttonPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled ^= true;
        }


        //resets the program
        private void buttonReset_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;           
            formInit();
            enableBatchControls();
            enableObservableControls();
        }
    }
}
