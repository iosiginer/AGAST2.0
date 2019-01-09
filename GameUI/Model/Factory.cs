
using AGAST2.Infrastructure.LevelTypes;
using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.GameUI.Model
{
    public class Factory
    {
        bool first;

        public Factory()
        {
            //TODO implement.
        }

        public Fact GetFact()
        {
            //TODO implement. 
            return new Fact();
        }

        public Question GetQuestion()
        {
            if (!first)
            {
                first = true;
                return new Question();
            }
            return new Question("Who is {0}", new List<string>() { "carlos", "pepe", "jose" }, "carlos", "this");
        }


    }
}
