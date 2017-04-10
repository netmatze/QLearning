using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLearning
{
    public partial class frmQLearning : Form
    {
        public int[,] terrain = new int[4, 3];
        QLearning qLearning;
        public frmQLearning()
        {
            InitializeComponent();
            terrain[0, 2] = 4;
            terrain[1, 1] = 3;            
            terrain[3, 0] = 2;
            terrain[3, 1] = 1;
            pictureBox.Image = imageList.Images["Red"];
        }

        private void Paint()
        {
            Pen pen = new Pen(Color.Black, 1);
            Graphics g = this.panel1.CreateGraphics();
            SolidBrush fillBrush = new SolidBrush(this.panel1.BackColor);
            g.FillRectangle(fillBrush, this.panel1.Location.X - 12, this.panel1.Location.Y - 12,
                this.panel1.Location.X + this.panel1.Width, this.panel1.Location.Y + this.panel1.Height);
            var width = panel1.Width;
            var height = panel1.Height;
            var xCalculator = width / terrain.GetLength(0);
            var yCalculator = height / terrain.GetLength(1);
            for (int y = 0; y <= terrain.GetLength(1); y++)
            {
                var yCoordinate = y * yCalculator;
                g.DrawLine(pen, 0, yCoordinate, width, yCoordinate);
            }
            for (int x = 0; x <= terrain.GetLength(0); x++)
            {
                var xCoordinate = x * xCalculator;
                g.DrawLine(pen, xCoordinate, 0, xCoordinate, width);
            }
            for (int y = 0; y < terrain.GetLength(1); y++)
            {
                var yCoordinate = y * yCalculator;
                for (int x = 0; x < terrain.GetLength(0); x++)
                {
                    var xCoordinate = x * xCalculator;
                    var value = terrain[x, y];
                    if (value == 4)
                    {
                        Pen startPen = new Pen(Color.Orange, 5);
                        g.DrawRectangle(startPen, xCoordinate, yCoordinate, xCalculator, yCalculator);
                    }
                    else if (value == 3)
                    {
                        SolidBrush drawBrush = new SolidBrush(Color.DarkBlue);
                        g.FillRectangle(drawBrush, xCoordinate, yCoordinate, xCalculator, yCalculator);
                    }
                    else if (value == 1)
                    {
                        Pen startPen = new Pen(Color.Red, 5);
                        g.DrawRectangle(startPen, xCoordinate, yCoordinate, xCalculator, yCalculator);
                    }
                    else if (value == 2)
                    {
                        Pen endPen = new Pen(Color.Green, 5);
                        g.DrawRectangle(endPen, xCoordinate, yCoordinate, xCalculator, yCalculator);
                    }
                    if (qLearning != null)
                    {
                        if (x == qLearning.State.Item1 && y == qLearning.State.Item2)
                        {
                            SolidBrush drawBrush = new SolidBrush(Color.Orange);
                            g.FillRectangle(drawBrush, xCoordinate + 50, yCoordinate + 50, xCalculator - 100, yCalculator - 100);
                        }
                        var qValue = 0.0;
                        foreach (var item in
                            qLearning.QValues[x.ToString() + y.ToString()])
                        {
                            var font = new Font("Arial", 18, FontStyle.Bold);
                            if (item.fromX < item.toX)
                            {
                                qValue = Math.Round(item.QValue, 3);
                                g.DrawString(qValue.ToString(), font, Brushes.Black, xCoordinate + 150, yCoordinate + 100);
                            }
                            if (item.fromX > item.toX)
                            {
                                qValue = Math.Round(item.QValue, 3);
                                g.DrawString(qValue.ToString(), font, Brushes.Black, xCoordinate + 50, yCoordinate + 100);
                            }
                            if (item.fromY < item.toY)
                            {
                                qValue = Math.Round(item.QValue, 3);
                                g.DrawString(qValue.ToString(), font, Brushes.Black, xCoordinate + 100, yCoordinate + 150);
                            }
                            if (item.fromY > item.toY)
                            {
                                qValue = Math.Round(item.QValue, 3);
                                g.DrawString(qValue.ToString(), font, Brushes.Black, xCoordinate + 100, yCoordinate + 50);
                            }
                        }
                    }
                }
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Paint();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ConfigureQLearning();
            qLearning.Stopped = false;
            qLearning.Explore();
        }

        private void ConfigureQLearning()
        {
            var alpha = Convert.ToDouble(txtLearningRate.Text);
            var gamma = Convert.ToDouble(txtDiscountFactor.Text);
            if (qLearning == null)
                qLearning = new QLearning(terrain);
            qLearning.Alpha = alpha;
            qLearning.Gamma = gamma;
            qLearning.OnNewState += QLearning_OnNewState;
            qLearning.HasConverged += QLearning_HasConverged;
        }

        private void QLearning_HasConverged(object sender, EventArgs e)
        {
            pictureBox.Image = imageList.Images["Green"];
            pictureBox.Invalidate();
        }

        private void QLearning_OnNewState(Tuple<int, int> oldState, Tuple<int, int> newState)
        {
            Paint();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            qLearning.Stopped = true;
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            ConfigureQLearning();
            qLearning.ExploreStep();
        }
    }
}
