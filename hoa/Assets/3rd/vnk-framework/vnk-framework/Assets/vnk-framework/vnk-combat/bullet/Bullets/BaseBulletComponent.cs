namespace Yoolax.Framework
{
    using UnityEngine;

    public class BaseBulletComponent : MonoBehaviour, IAwakeBullet
    {
        protected IBullet _bullet;

        public virtual void AwakeComponent(IBullet bullet)
        {
            _bullet = bullet;
        }

        protected virtual void Update()
        {

        }
        protected virtual void Start()
        {

        }
        protected virtual void OnEnable()
        {

        }
        protected virtual void OnDisable()
        {

        }
        protected virtual void OnDestroy()
        {

        }
    }

}