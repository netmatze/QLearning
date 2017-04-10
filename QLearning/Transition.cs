using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLearning
{
    public class Transition
    {
        public int fromX;
        public int fromY;
        public int toX;
        public int toY;
        public double QValue;

        public Transition(int fromX, int fromY, int toX, int toY, double QValue)
        {
            this.fromX = fromX;
            this.fromY = fromY;
            this.toX = toX;
            this.toY = toY;
            this.QValue = QValue;
        }
    }
}
