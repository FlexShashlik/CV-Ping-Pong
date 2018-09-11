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
using Emgu.CV.UI;
using Emgu.CV.Util;
using System.Threading;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        Capture camera = new Capture();

        ImageViewer viewerOriginal = new ImageViewer();

        ImageViewer viewerHSV1 = new ImageViewer();
        ImageViewer viewerInRange1 = new ImageViewer();
        ImageViewer viewerContours1 = new ImageViewer();

        ImageViewer viewerHSV2 = new ImageViewer();
        ImageViewer viewerInRange2 = new ImageViewer();
        ImageViewer viewerContours2 = new ImageViewer();

        static Mat frameOriginal = new Mat();

        Mat frameHSV1 = new Mat();
        Mat frameInRange1 = new Mat();
        Mat frameContours1 = new Mat();

        Mat frameHSV2 = new Mat();
        Mat frameInRange2 = new Mat();
        Mat frameContours2 = new Mat();

        int playerOneScore = 0, playerTwoScore = 0;

        int hMin1 = 60, hMax1 = 86,
            sMin1 = 146, sMax1 = 255,
            vMin1 = 7, vMax1 = 255;

        int hMin2 = 17, hMax2 = 69,
            sMin2 = 177, sMax2 = 255,
            vMin2 = 58, vMax2 = 215;

        Mat hierarchy1 = new Mat();
        VectorOfVectorOfPoint contours1 = new VectorOfVectorOfPoint();

        Mat hierarchy2 = new Mat();
        VectorOfVectorOfPoint contours2 = new VectorOfVectorOfPoint();

        static int ballX= frameOriginal.Width / 2 - ballR, ballY= frameOriginal.Height / 2 - ballR, ballR=10;
        int ballDx=10, ballDy=10;

        MCvMoments rocket1 = new MCvMoments(),
                   rocket2 = new MCvMoments();

        Rectangle boundingContour2 = new Rectangle(),
                  boundingContour1 = new Rectangle();

        private void buttonReset_Click(object sender, EventArgs e)
        {
            BallReset();
            playerOneScore = 0;
            playerTwoScore = 0;
        }

        #region trackbar

        private void trackBarhMin2_Scroll(object sender, EventArgs e)
        {
            hMin2 = trackBarhMin2.Value;
            textBoxhMin2.Text = trackBarhMin2.Value.ToString();
        }

        private void trackBarhMax2_Scroll(object sender, EventArgs e)
        {
            hMax2 = trackBarhMax2.Value;
            textBoxhMax2.Text = trackBarhMax2.Value.ToString();
        }

        private void trackBarsMin2_Scroll(object sender, EventArgs e)
        {
            sMin2 = trackBarsMin2.Value;
            textBoxsMin2.Text = trackBarsMin2.Value.ToString();
        }

        private void trackBarsMax2_Scroll(object sender, EventArgs e)
        {
            sMax2 = trackBarsMax2.Value;
            textBoxsMax2.Text = trackBarsMax2.Value.ToString();
        }

        private void trackBarvMin2_Scroll(object sender, EventArgs e)
        {
            vMin2 = trackBarvMin2.Value;
            textBoxvMin2.Text = trackBarvMin2.Value.ToString();
        }

        private void trackBarvMax2_Scroll(object sender, EventArgs e)
        {
            vMax2 = trackBarvMax2.Value;
            textBoxvMax2.Text = trackBarvMax2.Value.ToString();
        }

        private void trackBarhMin_Scroll(object sender, EventArgs e)
        {
            hMin1 = trackBarhMin.Value;
            textBoxhMin.Text = trackBarhMin.Value.ToString();
        }

        private void trackBarhMax_Scroll(object sender, EventArgs e)
        {
            hMax1 = trackBarhMax.Value;
            textBoxhMax.Text = trackBarhMax.Value.ToString();
        }

        private void trackBarsMin_Scroll(object sender, EventArgs e)
        {
            sMin1 = trackBarsMin.Value;
            textBoxsMin.Text = trackBarsMin.Value.ToString();
        }

        private void trackBarsMax_Scroll(object sender, EventArgs e)
        {
            sMax1 = trackBarsMax.Value;
            textBoxsMax.Text = trackBarsMax.Value.ToString();
        }
        

        private void trackBarvMin_Scroll(object sender, EventArgs e)
        {
            vMin1 = trackBarvMin.Value;
            textBoxvMin.Text = trackBarvMin.Value.ToString();
        }

        private void trackBarvMax_Scroll(object sender, EventArgs e)
        {
            vMax1 = trackBarvMax.Value;
            textBoxvMax.Text = trackBarvMax.Value.ToString();
        }
        #endregion

        private void BallReset()
        {
            ballX = frameOriginal.Width/2-ballR*2;
            ballY = frameOriginal.Height/2-ballR;

            ballDx = 10;
            ballDy = 10;
        }

        void ProcessFrame(object sender, EventArgs e)
        {
            frameOriginal = camera.QueryFrame();

            CvInvoke.Flip(frameOriginal, frameOriginal, FlipType.Horizontal);

            CvInvoke.CvtColor(frameOriginal, frameHSV1, ColorConversion.Bgr2Hsv);
            CvInvoke.CvtColor(frameOriginal, frameHSV2, ColorConversion.Bgr2Hsv);

            CvInvoke.InRange(frameHSV1,
                        new ScalarArray(new MCvScalar(hMin1, sMin1, vMin1)),
                        new ScalarArray(new MCvScalar(hMax1, sMax1, vMax1)),
                        frameInRange1);

            CvInvoke.InRange(frameHSV2,
                        new ScalarArray(new MCvScalar(hMin2, sMin2, vMin2)),
                        new ScalarArray(new MCvScalar(hMax2, sMax2, vMax2)),
                        frameInRange2);


            frameContours1 = frameInRange1.Clone();
            CvInvoke.FindContours(frameContours1, contours1, hierarchy1, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);

            if (contours1.Size > 0)
            {
                MCvMoments maxMoment = CvInvoke.Moments(contours1[0]);
                double maxArea = CvInvoke.ContourArea(contours1[0]);
                VectorOfPoint contour1 = contours1[0];

                for (int i = 0; i < contours1.Size; i++)
                {
                    CvInvoke.DrawContours(frameContours1, contours1, i, new MCvScalar(255, 255, 255), 1, LineType.EightConnected, hierarchy1);

                    if (CvInvoke.ContourArea(contours1[i]) > maxArea)
                    {
                        maxArea = CvInvoke.ContourArea(contours1[i]);
                        maxMoment = CvInvoke.Moments(contours1[i]);
                        contour1 = contours1[i];
                    }
                }
                rocket1 = maxMoment;
                CvInvoke.Circle(frameOriginal, new Point((int)maxMoment.GravityCenter.X, (int)maxMoment.GravityCenter.Y), 4, new MCvScalar(0, 0, 255));

                boundingContour1 = CvInvoke.BoundingRectangle(contour1);
                CvInvoke.Rectangle(frameOriginal, boundingContour1, new MCvScalar(0, 0, 255));
            }

            frameContours2 = frameInRange2.Clone();
            CvInvoke.FindContours(frameContours2, contours2, hierarchy2, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);

            if (contours2.Size > 0)
            {
                MCvMoments maxMoment = CvInvoke.Moments(contours2[0]);
                double maxArea = CvInvoke.ContourArea(contours2[0]);
                VectorOfPoint contour2 = contours2[0];

                for (int i = 0; i < contours2.Size; i++)
                {
                    CvInvoke.DrawContours(frameContours2, contours2, i, new MCvScalar(255, 255, 255), 1, LineType.EightConnected, hierarchy2);

                    if (CvInvoke.ContourArea(contours2[i]) > maxArea)
                    {
                        maxArea = CvInvoke.ContourArea(contours2[i]);
                        maxMoment = CvInvoke.Moments(contours2[i]);
                        contour2 = contours2[i];
                    }
                }
                rocket2 = maxMoment;

                string putText = String.Format("{1}:{0}", playerOneScore, playerTwoScore);
                
                CvInvoke.Circle(frameOriginal, new Point((int)maxMoment.GravityCenter.X, (int)maxMoment.GravityCenter.Y), 4, new MCvScalar(255, 0, 0));
                //CvInvoke.PutText(frameOriginal, putText, new Point(frameOriginal.Width / 2 - putText.Length * 10, frameOriginal.Height/2), FontFace.HersheyPlain, 1, new MCvScalar(22, 130, 26));
                boundingContour2 = CvInvoke.BoundingRectangle(contour2);
                CvInvoke.Rectangle(frameOriginal, boundingContour2, new MCvScalar(255, 0, 0));
            }

            CvInvoke.Circle(frameOriginal, new Point(ballX, ballY), ballR, new MCvScalar(0, 255, 0), -ballR);
            ballX += ballDx;
            ballY += ballDy;
            
            if(ballX < boundingContour1.Left)
            {
                playerOneScore++;
                BallReset();
            }

            if(ballX > boundingContour2.Right)
            {
                playerTwoScore++;
                BallReset();
            }

            if (boundingContour1.Contains(ballX, ballY)==true)
            {
                ballX = boundingContour1.Right + ballR;
                ballDx = -ballDx;
            }
            if (boundingContour2.Contains(ballX, ballY)==true)
            {
                ballX = boundingContour2.Left - ballR;
                ballDx = -ballDx;
            }

            if (ballX > viewerOriginal.ClientSize.Width)
            {
                ballDx = -ballDx;
                playerOneScore++;
            }

            if(ballX < 0)
            {
                ballDx = -ballDx;
                playerTwoScore++;
            }

            if (ballY > viewerOriginal.ClientSize.Height || ballY < 0) { ballDy = -ballDy; }

            viewerOriginal.Image = frameOriginal;

            //viewerHSV1.Image = frameHSV1;
            //viewerInRange1.Image = frameInRange1;
            viewerContours1.Image = frameContours1;

            //viewerHSV2.Image = frameHSV2;
            //viewerInRange2.Image = frameInRange2;
            viewerContours2.Image = frameContours2;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewerOriginal.KeyDown += ViewerOriginal_KeyDown;

            Application.Idle += ProcessFrame;

            //viewerOriginal.FormBorderStyle = FormBorderStyle.None;
            //viewerOriginal.WindowState = FormWindowState.Maximized;
          
            viewerOriginal.Show();

            //viewerHSV1.AutoSize = true;
            //viewerHSV1.Show();

            //viewerInRange1.AutoSize = true;
            //viewerInRange1.Show();

            viewerContours1.AutoSize = true;
            viewerContours1.Show();

            //viewerHSV2.AutoSize = true;
            //viewerHSV2.Show();

            //viewerInRange2.AutoSize = true;
            //viewerInRange2.Show();

            viewerContours2.AutoSize = true;
            viewerContours2.Show();
        }

        private void ViewerOriginal_KeyDown(object sender, KeyEventArgs e)
        {
            viewerOriginal.Text = e.KeyData.ToString();
        }
    }
}
