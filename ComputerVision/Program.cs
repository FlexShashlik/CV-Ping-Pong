using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.CV.UI;
using Emgu.CV.Util;

namespace ComputerVision
{
    class Program
    {
        static void Main(string[] args)
        {
           int hMin = 60, hMax =240,
               sMin = 50, sMax = 255,
               vMin = 50, vMax = 255;

            string windowName = "tester";
            string hsvWindowName = "hsv";
            string filteredWindowName = "filtered";
            string finishedWindowName = "finished";


            CvInvoke.NamedWindow(windowName);
            CvInvoke.NamedWindow(hsvWindowName);
            CvInvoke.NamedWindow(filteredWindowName);
            CvInvoke.NamedWindow(finishedWindowName);


            Capture camera = new Capture();

            while (true)
            {
                Mat frame = camera.QueryFrame();
                Mat hsvframe = new Mat();
                Mat filteredframe = new Mat();
                Mat finishedframe = new Mat();

                CvInvoke.CvtColor(frame, hsvframe, ColorConversion.Bgr2Hsv);

                CvInvoke.InRange(hsvframe, 
                    new ScalarArray(new MCvScalar(hMin, sMin, vMin)), 
                    new ScalarArray(new MCvScalar(hMax, sMax, vMax)),
                    filteredframe);

                finishedframe = filteredframe.Clone();

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hierarchy = new Mat();

                CvInvoke.FindContours(finishedframe, contours, hierarchy, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);

                for (int i = 0; i < contours.Size; i++)
                {
                    CvInvoke.DrawContours(finishedframe, contours, i,new MCvScalar(200, 200, 200),2,LineType.EightConnected,hierarchy);
                }
                
                CvInvoke.Imshow(windowName, frame);
                CvInvoke.Imshow(hsvWindowName, hsvframe);
                CvInvoke.Imshow(filteredWindowName, filteredframe);
                CvInvoke.Imshow(finishedWindowName, finishedframe);


                int key = CvInvoke.WaitKey(33);
                if (key == 27) { break; }
            }
        }
    }
}
