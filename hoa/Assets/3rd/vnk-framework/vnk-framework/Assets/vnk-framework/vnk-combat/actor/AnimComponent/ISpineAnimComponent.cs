#if UNITY_SPINE
using Spine;
using Spine.Unity;

namespace Yoolax.Framework
{
    public interface ISpineAnimComponent : IAnimComponent
    {
        SkeletonAnimation Anim { get; set; }
        Spine.TrackEntry SetAnimation(string animationName, bool isLoop = false);
        void FlipX(bool value);
    }

}
#endif