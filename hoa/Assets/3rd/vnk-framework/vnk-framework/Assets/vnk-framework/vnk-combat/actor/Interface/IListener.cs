namespace Yoolax.Framework
{
    public interface IListener
    {
        void OnAddListener(IActor actor);
        void OnRemoveListener(IActor actor);
    }
}


