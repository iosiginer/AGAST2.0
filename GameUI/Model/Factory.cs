
using AGAST2.Infrastructure.LevelTypes;
using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.GameLogic.Factories
{
    public class Factory
    {
        public Fact GetFact()
        {
            //TODO implement. 
            return new Fact();
        }

        public Question GetQuestion()
        {
            //TODO implement/
            return new Question();
        }

    }
}
