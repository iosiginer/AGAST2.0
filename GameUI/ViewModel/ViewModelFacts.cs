﻿using AGAST2.GameUI.Model;
using AGAST2.Infrastructure;
using AGAST2.Infrastructure.LevelTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameUI.ViewModel
{
    class ViewModelFacts : ViewModelBase
    {
        private Factory _factory;
        private Fact _currentFact;
        private string _factAsString;
        private bool _correct;
        List<String> _input;
        private int _player1 = 0, _player2 = 0;
        private int _p1Life = 3, _p2Life = 3;
        private bool _answered;

        private List<String> Get_List()
        {
            List<String> input = new List<string>();
            input.Add("A");
            input.Add("S");
            input.Add("K");
            input.Add("L");
            return input;
        }


        public string KeyModifer {  get; set; }


        internal bool OnKeyDown(String key)
        {
            _input = Get_List();
            if(_input.Contains(key))
            {
                _answered = FirstClicker(key);
            }
            else {
                _answered = true;
            }
            return _answered;
            
        }

        private Tuple<string, string> GetClickerValues(string key)
        {
            string value;
            string player;
            switch(key)
            {
                case TriviaConstants.LEFT_TRUE_KEY: player = TriviaConstants.PLAYER1;
                                                    value = TriviaConstants.True;
                                                    break;
                case TriviaConstants.RIGHT_TRUE_KEY: player = TriviaConstants.PLAYER2;
                                                     value = TriviaConstants.True;
                                                     break;
                case TriviaConstants.LEFT_FALSE_KEY: player = TriviaConstants.PLAYER1;
                                                     value = TriviaConstants.False;
                                                     break;

                case TriviaConstants.RIGHT_FALSE_KEY: player = TriviaConstants.PLAYER2;
                                                      value = TriviaConstants.False;
                                                      break;
                default: return null;
            }
            return Tuple.Create<string, string>(player, value);
        }


        public bool FirstClicker(string key)
        {
            Tuple<string, string> playerAndValue = GetClickerValues(key);
            bool correctAnswer = CurrentFact.CheckIfCorrect(playerAndValue.Item2);
            if(correctAnswer)
            {
                if (playerAndValue.Item1.Equals("player1")) ScoreOne++;
                else ScoreTwo++;
                return true;
                
            } else {
                if (playerAndValue.Item1.Equals("player1")) LivesOne--;
                else LivesTwo--;
                if (LivesTwo == 0) return false;
                else if (LivesOne == 0) return false;
                else
                {
                    CurrentFact = Factory.GetFact();
                    return true;
                }

            }

        }

        private Factory Factory { get => _factory; set => _factory = value; }

       
        public Fact CurrentFact
        {
            get => _currentFact;
            set
            {
                if (_currentFact != value)
                {
                    _currentFact = value;
                    FactAsString = _currentFact.AsString();
                }
            }
        }

        public int ScoreOne
        {
            get => _player1;
            set
            {
                if (_player1 != value)
                {
                    _player1 = value;
                    RaisePropertyChanged("ScoreOne");
                }
            }
        }

        public int ScoreTwo
        {
            get => _player2;
            set
            {
                if (_player2 != value)
                {
                    _player2 = value;
                    RaisePropertyChanged("ScoreTwo");
                }
            }
        }

        public int LivesOne
        {
            get => _p1Life;
            set
            {
                if (_p1Life != value)
                {
                    _p1Life = value;
                    RaisePropertyChanged("LivesOne");
                }
            }
        }

        public int LivesTwo
        {
            get => _p2Life;
            set
            {
                if (_p2Life != value)
                {
                    _p2Life = value;
                    RaisePropertyChanged("LivesTwo");
                }
            }
        }


        public string FactAsString
        {
            get => _factAsString;
            set
            {
                if (_factAsString != value)
                {
                    _factAsString = value;
                    RaisePropertyChanged("QuestionAsString");
                }
            }
        }


        private void CheckAnswer(string content)
        {
            Correct = CurrentFact.CheckIfCorrect(content);
        }

        public bool Correct { get => _correct; set => _correct = value; }


        public ViewModelFacts()
        {
            
            Factory = new Factory();
            Run();
        }

        public bool Answered { get => _answered; set => _answered = value; }


        private void Run()
        {

            CurrentFact = Factory.GetFact();
            

        }
    }
}
