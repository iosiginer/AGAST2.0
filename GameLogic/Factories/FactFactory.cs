
using AGAST2.LevelTypes;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Factories
{
    public class FactFactory : IFactory<Fact>
    {
        private List<string> _askedFacts;

        public List<string> AskedFacts { get => _askedFacts; set => _askedFacts = value; }

        public Fact NextLevel()
        {
            throw new NotImplementedException();
        }

    }
}
