using AGAST2.GameUI.Model;
using AGAST2.Infrastructure;
using AGAST2.Infrastructure.LevelTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUI.ViewModel
{
    class ViewModelTrivia : ViewModelBase
    {
        private Factory _factory;
        private Question _currentQuestion;
        private string _questionAsString;
        private ObservableCollection<string> _options;
        private int _lives;
        private int _points;
        private bool _answered;

        public Action CloseAction { get; set; }

        public ViewModelTrivia()
        {
            Factory = new Factory();
            Lives = TriviaConstants.InitialLives;
            PlayRound();
        }

        private Factory Factory { get => _factory; set => _factory = value; }

        public Question CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                if (_currentQuestion != value)
                {
                    _currentQuestion = value;
                    Options = new ObservableCollection<string>(_currentQuestion.Options);
                    QuestionAsString = _currentQuestion.AsString();
                }
            }
        }

        public bool SubmitAnswer(string content)
        {
            bool correctAnswer = CurrentQuestion.CheckIfCorrect(content);
            if (!correctAnswer)
            {
                Lives--;
                Points--;
            }
            else
            {
                Points += TriviaConstants.RightQuestionPoints;
            }
            if (Lives > 0)
            {
                CurrentQuestion = Factory.GetQuestion();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void EndGame()
        {
            throw new NotImplementedException();
        }

        public string QuestionAsString
        {
            get => _questionAsString;
            set
            {
                if (_questionAsString != value)
                {
                    _questionAsString = value;
                    RaisePropertyChanged("QuestionAsString");
                }
            } 
        }

        public ObservableCollection<string> Options
        {
            get => _options;
            set
            {
                if (_options != value)
                {
                    _options = value;
                    RaisePropertyChanged("Options");
                }
            } 
        }

        public int Lives
        {
            get => _lives;
            set 
            {
                if (_lives != value)
                {
                    _lives = value;
                    RaisePropertyChanged("Lives");
                }
            }
        }

        public int Points
        {
            get => _points;
            set
            {
                if (_points != value)
                {
                    _points = value;
                    RaisePropertyChanged("Points");
                }
            }
        }

        public bool Answered { get => _answered; set => _answered = value; }

        private void PlayRound()
        {
            CurrentQuestion = Factory.GetQuestion();
        }
    }
}
