using UnityEngine;
using Sirenix.OdinInspector;

namespace Yoolax.Framework
{
    public class Status : MonoBehaviour, IStatus
    {
        protected IActor actor;
        [SerializeField] protected Modifier modifier;
        [SerializeField] protected StatsType statsType;

        [SerializeField] protected bool disableTime;
        [SerializeField] protected bool applyAfterInterval;
        [SerializeField, ShowIf("applyAfterInterval", true)] protected float interval = 1;
        protected float duration;
        protected float nextTime = 0;


        public virtual void Init(IActor _actor)
        {
            actor = _actor;
            transform.SetParent(actor.Trans);
            transform.localPosition = Vector3.zero;

            duration = modifier.duration;
            nextTime = duration;
            Apply();
        }

        public virtual void Apply()
        {

        }

        public virtual void End()
        {
          
        }
        void Update()
        {
            if (disableTime)
            {
                return;
            }

            if (applyAfterInterval)
            {
                if (duration < nextTime)
                {
                    nextTime -= interval;
                    Apply();
                }
            }
            duration -= Time.deltaTime;

            if (duration <= 0)
            {
                End();
            }
        }
    }
}
