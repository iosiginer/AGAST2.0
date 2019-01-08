﻿using AGAST2.GameUI.Model;
using AGAST2.Infrastructure.LevelTypes;
using System;
using System.Collections.Generic;
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
        private List<string> _options;

        private Factory Factory { get => _factory; set => _factory = value; }

        public Question CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                if (_currentQuestion != value)
                {
                    _currentQuestion = value;
                    Options = _currentQuestion.Options;
                    QuestionAsString = _currentQuestion.AsString();
                }
            }
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

        public List<string> Options
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


        public ViewModelTrivia()
        {
            Factory = new Factory();
            Run();
        }

        private void Run()
        {
            //while(true)
            //{
                CurrentQuestion = Factory.GetQuestion();
            //}

        }
    }
}
