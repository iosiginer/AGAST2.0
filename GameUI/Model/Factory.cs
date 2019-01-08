
using AGAST2.Infrastructure.LevelTypes;
using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.GameLogic.Factories
{
    public static class Factory
    {
        public static Fact GetFact()
        {
            //TODO implement. 
            return new Fact();
        }

        public static Question GetQuestion()
        {
            //TODO implement/
            return new Question();
        }

    }
}
