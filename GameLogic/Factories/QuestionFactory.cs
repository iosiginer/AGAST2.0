using AGAST2.Infrastructure;
using AGAST2.Infrastructure.LevelTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.GameLogic.Factories
{
    public class QuestionFactory : IFactory<Question>
    {
        private List<string> _askedQuestions;

        public List<string> AskedQuestions { get => _askedQuestions; set => _askedQuestions = value; }

        public Question NextLevel()
        {
            throw new NotImplementedException();
        }
    }
}
