namespace Yoolax.Framework
{
    using UnityEngine;

    public interface IBullet
    {
        bool IsActive { get; set; }
        Transform Trans { get; }
    }

}