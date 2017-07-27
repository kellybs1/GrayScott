using System;
using System.Drawing;

/*
 * FileManager Class 
 * Author: Brendan Kelly
 * Date: 24 April 2017
 * Description: Class for generating and saving bitmap image files
 */

namespace ReactionAssignment
{
    public class FileManager
    {
        public FileManager()
        {
        }


        public void SaveImage(Bitmap image, double feedA, double killB, String shaderName, String LaplacianName, String seedName)
        {
            String fileName = generateFileName(feedA, killB, shaderName, LaplacianName, seedName);
            image.Save(fileName);
        }


        //generates a filename based on time, date, and program variables
        private String generateFileName(double feedA, double killB, String shaderName, String laplacianName, String seedName)
        {
            String fileName = "";
            //build time string
            DateTime date = DateTime.Now;
            String timeStr = date.ToString("HH:mm:ss.fff");
            String dateStr = date.ToString("MM/dd/yyyy");
            //remove characters filenames don't like
            timeStr = timeStr.Replace(':', '_');
            dateStr = dateStr.Replace('/', '_');
            //build string
            fileName += dateStr;
            fileName += "_";
            fileName += timeStr;
            fileName += "_FA-";
            fileName += String.Format("{0:0.000}", feedA);
            fileName += "_KB-";
            fileName += String.Format("{0:0.000}", killB);
            fileName += "_";
            fileName += shaderName;
            fileName += "_";
            fileName += laplacianName;
            fileName += "_";
            fileName += seedName;
            fileName += ".bmp";

            ///no spaces
            fileName = fileName.Replace(" ", "_");

            return fileName;
        }
    }
}
