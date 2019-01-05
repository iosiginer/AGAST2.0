using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.LevelTypes
{
    public class Question : ILevel
    {
        private string _phrase;
        private string _subject;
        private List<string> _options;
        private string _correctOption;

        public string Phrase { get => _phrase; set => _phrase = value; }
        public List<string> Options { get => _options; set => _options = value; }
        public string CorrectOption { get => _correctOption; set => _correctOption = value; }
        public string Subject { get => _subject; set => _subject = value; }


        public bool CheckIfCorrect(string chosenOption)
        {
            return chosenOption.Equals(CorrectOption);
        }

        public string AsString()
        {
            return String.Format(Phrase, Subject);
        }
    }
}
