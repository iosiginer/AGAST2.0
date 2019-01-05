using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Factories
{
    public class QuestionFactory
    {
        private List<string> _askedQuestions;

        public List<string> AskedQuestions { get => _askedQuestions; set => _askedQuestions = value; }
    }
}
