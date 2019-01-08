using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Infrastructure.LevelTypes
{
    public class Fact : ILevel
    {
        private string _phrase;
        private string _correctOption;

        public string Phrase { get => _phrase; set => _phrase = value; }
        public string CorrectOption { get => _correctOption; set => _correctOption = value; }

        public Fact()
        {
            Phrase = "All your base are belong to us";
            CorrectOption = TriviaConstants.True;
        }

        public string AsString()
        {
            return Phrase;
        }

        public bool CheckIfCorrect(string chosenOption)
        {
            return chosenOption.Equals(CorrectOption);
        }
    }
}
