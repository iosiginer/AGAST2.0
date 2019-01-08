using AGAST2.GameUI.Model;
using AGAST2.Infrastructure.LevelTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUI.ViewModel
{
    class ViewModelFacts : ViewModelBase
    {
        private Factory _factory;
        private Fact _currentFact;
        private string _factAsString;

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

       
        


        public ViewModelFacts()
        {
            Factory = new Factory();
            Run();
        }

        private void Run()
        {
            //while(true)
            //{
            CurrentFact = Factory.GetFact();
            //}

        }
    }
}
