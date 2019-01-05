using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.LevelTypes
{
    public class Fact : ILevel<bool>
    {
        private string _phrase;
        private bool _correctOption;

        public string Phrase { get => _phrase; set => _phrase = value; }
        public bool CorrectOption { get => _correctOption; set => _correctOption = value; }

        public string AsString()
        {
            return Phrase;
        }

        public bool CheckIfCorrect(bool chosenOption)
        {
            return chosenOption.Equals(CorrectOption);
        }
    }
}
