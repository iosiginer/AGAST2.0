using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUI.Model
{
    public class ScoreKeeper
    {
        private string _owner;
        private int _currentScore;
        private int _maxScore;

        public ScoreKeeper(string owner, int maxScore = 500, int currentScore = 0)
        {
            Owner = owner;
            MaxScore = maxScore;
            CurrentScore = currentScore;
        }

        public event EventHandler MaxScoreReached;
        public event EventHandler ScoreUpdated;

        public int CurrentScore
        {
            get => _currentScore;
            set => _currentScore = value;

        }

        public void Add(int score)
        {
            CurrentScore += score;
            if (CurrentScore >= MaxScore)
            {
                OnMaxScoreReached(EventArgs.Empty);
            }
        }

        public void OnScoreUpdated(EventArgs args)
        {
            EventHandler handler = ScoreUpdated;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public void OnMaxScoreReached(EventArgs args)
        {
            EventHandler handler = MaxScoreReached;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public string Owner { get => _owner; set => _owner = value; }
        public int MaxScore { get => _maxScore; set => _maxScore = value; }
    }
}
