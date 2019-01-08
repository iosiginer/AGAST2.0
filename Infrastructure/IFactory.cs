using System;

namespace AGAST2.Infrastructure
{
    public interface IFactory<ILevel>
    {
        ILevel NextLevel();
    }
}
