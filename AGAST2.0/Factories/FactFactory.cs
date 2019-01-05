
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Factories
{
    public class FactFactory : IFactory<bool>
    {
        private List<string> _askedFacts;

        public List<string> AskedFacts { get => _askedFacts; set => _askedFacts = value; }

        public ILevel<bool> NextLevel()
        {
            throw new NotImplementedException();
        }
    }
}
