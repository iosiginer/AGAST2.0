using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Infrastructure.LevelTypes
{
    public class Fact : ILevel
    {
        private string _phrase;
        private bool _correctOption;

        public string Phrase { get => _phrase; set => _phrase = value; }
        public bool CorrectOption { get => _correctOption; set => _correctOption = value; }

        public Fact(string phrase, bool isCorrect)
        {
            this.Phrase = phrase;
            this.CorrectOption = isCorrect;

        }

        public string AsString()
        {
            return Phrase;
        }

        public bool CheckIfCorrect(string chosenOption)
        {
            return CorrectOption;
        }
    }
}
