using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Cvb;
using Emgu.CV.UI;
using Emgu.CV.Util;


namespace WindowsForms
{
    public partial class Form1 : Form
    {
        ImageViewer viewerOriginal = new ImageViewer();
        ImageViewer viewerHSV = new ImageViewer();
        ImageViewer viewerInRange = new ImageViewer();
        ImageViewer viewerContours = new ImageViewer();

        Mat frameOriginal = new Mat();
        Mat frameHSV = new Mat();
        Mat frameInRange = new Mat();
        Mat frameContours = new Mat();


        Mat erodeElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
        Mat dilateElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(8, 8), new Point(-1, -1));

        Mat hierarchy = new Mat();
        VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

        List<MCvMoments> moments = new List<MCvMoments>();

        int hMin = 0, hMax = 255,
            sMin = 0, sMax = 255,
            vMin = 0, vMax = 255;

        int ballX=100, ballY=100;
        int ballDx=10, ballDy=10;
        int ballR = 10;

        Capture capture = new Capture();

        private void ProcessFrame(object sender, EventArgs e)
        {
            frameOriginal = capture.QueryFrame();
            CvInvoke.CvtColor(frameOriginal, frameHSV, ColorConversion.Bgr2Hsv);

            CvInvoke.InRange(frameHSV,
                            new ScalarArray(new MCvScalar(hMin, sMin, vMin)),
                            new ScalarArray(new MCvScalar(hMax, sMax, vMax)),
                            frameInRange);
            
            //CvInvoke.Erode(frameInRange, frameInRange, erodeElement, new Point(-1,-1), 2, BorderType.Constant,new MCvScalar());
            //CvInvoke.Dilate(frameInRange, frameInRange, dilateElement, new Point(-1, -1), 2, BorderType.Constant, new MCvScalar());

            frameContours = frameInRange.Clone();

            CvInvoke.FindContours(frameContours, contours, hierarchy, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contours.Size; i++)
            {
                CvInvoke.DrawContours(frameContours, contours, i, new MCvScalar(200, 200, 200), 2, LineType.EightConnected, hierarchy);
            }

            if (contours.Size > 0)
            {
                MCvMoments maxMoments = CvInvoke.Moments(contours[0]);
                double maxArea = CvInvoke.ContourArea(contours[0]);
                for (int i = 0; i < contours.Size; i++)
                {
                    double currentArea = CvInvoke.ContourArea(contours[i]);
                    if (currentArea > maxArea)
                    {
                        maxArea = currentArea;
                        maxMoments = CvInvoke.Moments(contours[i]);
                    }
                }
                CvInvoke.Circle(frameOriginal, new Point((int)maxMoments.GravityCenter.X, (int)maxMoments.GravityCenter.Y), 4, new MCvScalar(0, 0, 255));
            }
            
             CvInvoke.Circle(frameOriginal, new Point(ballX, ballY), ballR, new MCvScalar(0, 255, 0),- ballR/2);

            viewerOriginal.Image = frameOriginal;
            viewerHSV.Image = frameHSV;
            viewerInRange.Image = frameInRange;
            viewerContours.Image = frameContours;
        }
        private void timerBall_Tick(object sender, EventArgs e)
        {
            ballX += ballDx;
            ballY += ballDy;

            if (ballX > viewerOriginal.Width || ballX < 0) { ballDx = -ballDx; }
            if (ballY > viewerOriginal.Height || ballY < 0) { ballDy = -ballDy; }
        }

        private void trackBarhMax_Scroll(object sender, EventArgs e)
        {
            hMax = trackBarhMax.Value;
            textBoxhMax.Text = trackBarhMax.Value.ToString();
        }

       

        private void trackBarsMin_Scroll(object sender, EventArgs e)
        {
            sMin = trackBarsMin.Value;
            textBoxsMin.Text = trackBarsMin.Value.ToString();
        }

        private void trackBarsMax_Scroll(object sender, EventArgs e)
        {
            sMax = trackBarsMax.Value;
            textBoxsMax.Text = trackBarsMax.Value.ToString();
        }

        private void trackBarvMin_Scroll(object sender, EventArgs e)
        {
            vMin = trackBarvMin.Value;
            textBoxvMin.Text = trackBarvMin.Value.ToString();
        }

        private void trackBarvMax_Scroll(object sender, EventArgs e)
        {
            vMax = trackBarvMax.Value;
            textBoxvMax.Text = trackBarvMax.Value.ToString();
        }

        private void trackBarhMin_Scroll(object sender, EventArgs e)
        {
            hMin = trackBarhMin.Value;
            textBoxhMin.Text = trackBarhMin.Value.ToString();
        }
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += ProcessFrame;
            viewerOriginal.Show();
            viewerHSV.Show();
            viewerInRange.Show();
            viewerContours.Show();
        }
    }
}
