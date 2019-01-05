using System;

namespace Infrastructure
{
    public interface IFactory<T>
    {
        ILevel<T> NextLevel();
    }
}
