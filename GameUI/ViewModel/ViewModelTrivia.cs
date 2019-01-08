using AGAST2.GameUI.Model;
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
        private Boolean _correct;

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

        internal void CheckAnswer(string content)
        {
            Correct = CurrentQuestion.CheckIfCorrect(content);
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

        public bool Correct { get => _correct; set => _correct = value; }

        public ViewModelTrivia()
        {
            Factory = new Factory();
            Run();
        }

        private void Run()
        {
            do
            {
                CurrentQuestion = Factory.GetQuestion();
            } while (Correct);

        }
    }
}
