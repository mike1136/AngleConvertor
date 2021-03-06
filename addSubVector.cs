﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class addSubVector : Form
    {
        #region Variables
        string inputAx, inputAy, inputAz, inputBx, inputBy, inputBz;
        double Ax = 0, Ay = 0, Az = 0, Bx = 0, By = 0, Bz = 0, Rx = 0, Ry = 0, Rz = 0, Magnitude = 0, Theta = 0, Alpha = 0;
        #endregion

     

        public addSubVector()
        {
            InitializeComponent();
        }

        private void addSubVector_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            double[] resultR = new double[3];

            inputAx = txtAx.Text;
            inputAy = txtAy.Text;
            inputAz = txtAz.Text;

            inputBx = txtBx.Text;
            inputBy = txtBy.Text;
            inputBz = txtBz.Text;

            if( CheckForNumber(inputAx))
            {
                Ax = ConvertToDouble(inputAx);
            }

            if ( CheckForNumber(inputAy))
            {
                Ay = ConvertToDouble(inputAy);
            }

            if (CheckForNumber(inputAz))
            {
                Az = ConvertToDouble(inputAz);
            }

            if ( CheckForNumber(inputBx))
            {
                Bx = ConvertToDouble(inputBx);
            }

            if ( CheckForNumber(inputBy))
            {
                By = ConvertToDouble(inputBy);
            }

            if (CheckForNumber(inputBz))
            {
                Bz = ConvertToDouble(inputBz);
            }

            resultR = AddVectors(Ax, Ay, Az, Bx, By, Bz);

            lblRX.Text = resultR[0].ToString() + "î";
            lblRY.Text = resultR[1].ToString() + "ĵ";
            lblRZ.Text = resultR[2].ToString() + "k";

            Rx = resultR[0];
            Ry = resultR[1];
            Rz = resultR[2];

            Magnitude = GetMag(Rx, Ry, Rz);
            lblMagRes.Text = "Sqrt(" + Rx + "² + " + Ry + "² + " + Rz + "²) = " + Magnitude.ToString();

            Theta = GetTheta(Rx, Ry);
            lblThetaRes.Text = "Atan(" + Ry + "/" + Rx + ") = " + Theta.ToString() + "°";

            if(Rz < 0 || Rz > 0)
            {
                Alpha = GetAlpha(Rx, Ry, Rz);
                lblAlphaRes.Text = Alpha.ToString() + "°";
            }
            else
            {
                lblAlphaRes.Text = Alpha.ToString();
            }


        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            double[] resultR = new double[3];

            inputAx = txtAx.Text;
            inputAy = txtAy.Text;
            inputAz = txtAz.Text;

            inputBx = txtBx.Text;
            inputBy = txtBy.Text;
            inputBz = txtBz.Text;
            /********************************************************
             *                                                      *
             *                 Checks for Numbers                   *
             *                                                      *
             ********************************************************/
            #region CheckForNumbers
            if (CheckForNumber(inputAx))
            {
                Ax = ConvertToDouble(inputAx);
            }

            if (CheckForNumber(inputAy))
            {
                Ay = ConvertToDouble(inputAy);
            }

            if ( CheckForNumber(inputAz))
            {
                Az = ConvertToDouble(inputAz);
            }

            if ( CheckForNumber(inputBx))
            {
                Bx = ConvertToDouble(inputBx);
            }

            if (CheckForNumber(inputBy))
            {
                By = ConvertToDouble(inputBy);
            }

            if ( CheckForNumber(inputBz))
            {
                Bz = ConvertToDouble(inputBz);
            }
            #endregion

            resultR = SubVectors(Ax, Ay, Az, Bx, By, Bz);

            lblRX.Text = resultR[0].ToString() + "î";
            lblRY.Text = resultR[1].ToString() + "ĵ";
            lblRZ.Text = resultR[2].ToString() + "k";

            Rx = resultR[0];
            Ry = resultR[1];
            Rz = resultR[2];

            Magnitude = GetMag(Rx, Ry, Rz);
            lblMagRes.Text = "Sqrt(" + Rx + "² + " + Ry + "² + " + Rz + "²) = " + Magnitude.ToString();

            Theta = GetTheta(Rx, Ry);
            lblThetaRes.Text = "Atan(" + Ry + "/" + Rx + ") = " + Theta.ToString() + "°";

            if (Rz < 0 || Rz > 0)
            {
                Alpha = GetAlpha(Rx, Ry, Rz);
                lblAlphaRes.Text = Alpha.ToString() + "°";
            }
            else
            {
                lblAlphaRes.Text = Alpha.ToString();
            }

        }

        /********************************************************
         *                                                      *
         *                 Other Funtions                       *
         *                                                      *
         ********************************************************/
        #region Other Funtions
        public double[] AddVectors(double Ax, double Ay, double Az, double Bx, double By, double Bz)
        {
            double[] result = new double[3];

            result[0] = Math.Round(Ax + Bx, 2);
            result[1] = Math.Round(Ay + By, 2);
            result[2] = Math.Round(Az + Bz, 2);

            return result; 
        }

        public double[] SubVectors(double Ax, double Ay, double Az, double Bx, double By, double Bz)
        {
            double[] result = new double[3];

            result[0] = Math.Round(Ax - Bx, 2);
            result[1] = Math.Round(Ay - By, 2);
            result[2] = Math.Round(Az - Bz, 2);

            return result;
        }

        public double GetMag(double Rx, double Ry, double Rz)
        {
            return Math.Round(Math.Sqrt(Math.Pow(Rx, 2) + Math.Pow(Ry, 2) + Math.Pow(Rz, 2)));
        }

        public double GetTheta(double Rx, double Ry)
        {
            double Theta;
            if (Rx == 0)
            {
                return 0;
            }
            Theta = Math.Atan(Ry / Rx);
            Theta = ConvertToDegree(Theta);
            Theta = CheckQuadrant(Theta, Rx, Ry);

            return Theta;
        }

        public double GetAlpha(double Rx, double Ry, double Rz)
        {
            if (Rz == 0)
            {
                return 0;
            }

            return Math.Round(ConvertToDegree(Math.Atan((Math.Sqrt(Math.Pow(Rx, 2) + Math.Pow(Ry, 2)) / Rz))));
        }

        public double CheckQuadrant(double Theta, double Rx, double Ry)
        {
            if (Theta < 0 && Rx > 0 && Ry > 0)
            {
                Math.Abs(Theta);
            }
            else if (Rx < 0 && Ry > 0)
            {
                Theta += 180;
            }
            else if (Rx < 0 && Ry < 0)
            {
                Theta += 180;
            }
            else if (Theta < 0 && Rx > 0 && Ry < 0)
            {
                Theta += 360;
            }
            else if (Theta > 0 && Rx > 0 && Ry < 0)
            {
                Theta = 360 - Theta;
            }

            return Theta;
        }

        public double ConvertToDegree(double radiant)
        {
            return radiant * (180 / Math.PI);
        }
        public double ConvertToRadiant(double degree)//Converts from degree to radiants
        {
            return (Math.PI / 180) * degree;
        }

        public bool CheckForNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("The Input can't be Empty","Error Found!");
                ;
                return false;
            }

            else

                foreach (char c in input)
                {
                    if (c < '0' || c > '9')
                        if (c != '.' && c != '-')
                        {
                            return false;
                        }



                }
            return true;
        }

        public double ConvertToDouble(string input)
        {
            return Convert.ToDouble(input);
        }
        #endregion Other Funtions
    }
}
