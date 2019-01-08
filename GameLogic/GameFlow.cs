using AGAST2.Infrastructure;
using System;

namespace AGAST2.GameLogic
{
    public class GameFlow
    {
        private IFactory<ILevel> _factory;

        public IFactory<ILevel> Factory { get => _factory; set => _factory = value; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
