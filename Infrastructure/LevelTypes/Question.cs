﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Infrastructure.LevelTypes
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

        /**
         * Default constructor. Returns dummy question.
         */
        public Question(string phrase)
        {
            Phrase = "Which of the following sharks says {0}";
            Options = new List<string> { "Babyshark", "Mommyshark", "Daddyshark", "Wireshark" };
            Subject = "Doo doo doo-doo doo";
            CorrectOption = "Wireshark";
        }

        public Question(string phrase, List<string> options, string correctOption, string subject)
        {
            Phrase = phrase;
            Options = options;
            Shuffle(Options);
            Options.Add("Other");
            CorrectOption = correctOption;
            Subject = subject;
        }

        private void Shuffle(List<string> options)
        {
            int n = options.Count;
            Random random = new Random();
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = options[k];
                options[k] = options[n];
                options[n] = value;
            }
        }

        public bool CheckIfCorrect(string chosenOption)
        {
            return chosenOption.Equals(CorrectOption);
        }

        public string AsString()
        {
            return String.Format(Phrase, Subject as string);
        }


    }
}
