using System;

namespace Infrastructure
{
    public interface IFactory<ILevel>
    {
        ILevel NextLevel();
    }
}
