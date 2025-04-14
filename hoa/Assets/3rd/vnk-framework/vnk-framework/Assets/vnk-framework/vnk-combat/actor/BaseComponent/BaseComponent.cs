using UnityEngine;

namespace Yoolax.Framework
{
    public class BaseComponent : MonoBehaviour, IBaseComponent, IAwake
    {
        protected IActor actor;
        public IActor Actor { get => actor; set => actor = value; }

        public virtual void AwakeComponent(IActor actor)
        {
            this.actor = actor;
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