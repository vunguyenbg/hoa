
namespace Yoolax.Framework
{
    public class NullStateComponent : BaseComponent, IStateComponent
    {
        public void Lock(bool isLocked)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeState(int state)
        {
            throw new System.NotImplementedException();
        }

        public bool IsState(int state)
        {
            throw new System.NotImplementedException();
        }
    }
}