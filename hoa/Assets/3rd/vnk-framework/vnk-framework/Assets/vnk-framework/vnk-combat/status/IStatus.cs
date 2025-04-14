

namespace Yoolax.Framework
{
    public interface IStatus
    {
        void Init(IActor actor);
        void Apply();
        void End();
    }
}
