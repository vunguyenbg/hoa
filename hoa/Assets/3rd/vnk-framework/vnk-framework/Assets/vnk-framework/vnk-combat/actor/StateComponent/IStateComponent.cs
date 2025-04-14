
using System;

namespace Yoolax.Framework
{
    public interface IStateComponent
    {
        void Lock(bool isLocked);
        void ChangeState(int state);
        bool IsState(int state);
    }

}