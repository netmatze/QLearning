using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QLearning
{
    public class QLearning
    {
        public delegate void NewStateCalculated(Tuple<int, int> oldState, Tuple<int, int> newState);
        public event NewStateCalculated OnNewState;
        public event EventHandler HasConverged;
        public double[,] Q = new double[4, 3];
        public Dictionary<string, List<Transition>> QValues = 
            new Dictionary<string, List<Transition>>();
        public double[,] R = new double[4, 3];
        public int[,] terrain;
        public double Gamma = 0.4;
        public double Alpha = 0.8;
        public Tuple<int, int> State = new Tuple<int, int>(0,2);
        public Tuple<int, int> OldState = new Tuple<int, int>(0, 2);
        public bool Stopped;
        public int Episodes;

        public QLearning(int[,] terrain)
        {
            this.terrain = terrain;
            R = new double[4, 3] {
                { -0.04, -0.04, -0.04 },
                { -0.04, -0.04, -0.04 },
                { -0.08, -0.08, -0.08 },
                { 1, -1, -0.04 }
            };
            for(int i = 0; i <= terrain.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= terrain.GetUpperBound(1); j++)
                {
                    var list = new List<Transition>();
                    CalculateTransitions(i, j, list, terrain);
                    QValues.Add(i.ToString() + j.ToString(), list);
                }
            }
        }

        public void CalculateTransitions(int x, int y, List<Transition> list, int[,] terrain)
        {
            if (x - 1 >= 0)
            {
                if (terrain[x - 1, y] != 3)
                {
                    var tuple = new Transition(x, y, x - 1, y, 0);
                    list.Add(tuple);
                }
            }
            if(x + 1 <= terrain.GetUpperBound(0))
            {
                if (terrain[x + 1, y] != 3)
                {
                    var tuple = new Transition(x, y, x + 1, y, 0);
                    list.Add(tuple);
                }
            }
            if (y - 1 >= 0)
            {
                if (terrain[x, y - 1] != 3)
                {
                    var tuple = new Transition(x, y, x, y - 1, 0);
                    list.Add(tuple);
                }
            }
            if (y + 1 <= terrain.GetUpperBound(1))
            {
                if (terrain[x, y + 1] != 3)
                {
                    var tuple = new Transition(x, y, x, y + 1, 0);
                    list.Add(tuple);
                }
            }
        }

        public void Explore()
        {
            while (Episodes < 1000)
            {
                ExploreStep();
                if (Stopped)
                    break;
                Episodes++;
            }
        }

        public void ExploreStep()
        {
            var possibleStates = CalculatePossibleStates(State);
            double maxValue = double.MinValue;
            var newState = new Tuple<int, int>(State.Item1, State.Item2);
            foreach (var item in possibleStates)
            {
                if (maxValue <= item.QValue)
                {
                    maxValue = item.QValue;
                    newState = new Tuple<int, int>(item.toX, item.toY);
                }
            }
            var qValueIdentifier = State.Item1.ToString() + State.Item2.ToString();
            var changeCheck = false;
            foreach (var item in QValues[qValueIdentifier])
            {
                if (item.toX == newState.Item1 && item.toY == newState.Item2)
                {
                    var maxFutureRevard = CalculateMaxFutureReward(newState);
                    var qValueChange = Alpha * (R[newState.Item1, newState.Item2] + Gamma * (maxFutureRevard) - item.QValue);
                    item.QValue +=
                        qValueChange;
                    if (qValueChange == 0)
                        changeCheck = true;
                    else
                        changeCheck = false;
                }
            }
            if (changeCheck)
            {
                HasConverged?.Invoke(this, null);
                Stopped = true;
            }
            OnNewState(State, newState);
            Thread.Sleep(100);
            OldState = State;
            State = newState;
            if (State.Item1 == 3 && State.Item2 == 1 || State.Item1 == 3 && State.Item2 == 0)
            {
                OldState = State;
                State = new Tuple<int, int>(0, 2);
            }
        }
        public double CalculateMaxFutureReward(Tuple<int, int> newState)
        {
            var qValueIdentifier = newState.Item1.ToString() + newState.Item2.ToString();
            var maxValue = double.MinValue;
            foreach (var item in QValues[qValueIdentifier])
            {
                if (maxValue <= item.QValue)
                {
                    maxValue = item.QValue;
                }
            }
            return maxValue;
        }

        public List<Transition> CalculatePossibleStates(Tuple<int, int> state)
        {
            var list = new List<Transition>();
            var x = state.Item1;
            var y = state.Item2;
            foreach(var newState in QValues[x.ToString() + y.ToString()])
            {
                Debug.WriteLine(state.Item1 + " " + state.Item2 + " -> " + 
                    newState.toX + " " + newState.toY + " Q: " + newState.QValue);
                list.Add(newState);
            }
            return list;
        }
    }
}
