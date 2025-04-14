using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class FinderNearestComponent : BaseComponent, IFinderComponent, IListener
    {
        [SerializeField] private Actor target;
        [SerializeField] private bool removeTargetWhenKilled;
        [SerializeField] private bool findWhenTargetNull;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layer = ~0;
        [SerializeField] private bool autoFindTarget;
        [SerializeField] private int maxUpdateFindTarget;
        [SerializeField] private string tag = string.Empty;
        [SerializeField] private bool drawGizmos;
        private int countUpdateFindTarget;
        public Actor Target { get => target; set => target = value; }
        public float Radius { get => radius; set => radius = value; }
        public bool AutoFindTarget { get => autoFindTarget; set => autoFindTarget = value; }

        public override void AwakeComponent(IActor actor)
        {
            base.AwakeComponent(actor);
            countUpdateFindTarget = maxUpdateFindTarget;
        }
        public void OnAddListener(IActor actor)
        {
            base.actor.ActorAction.OnFindTarget += OnFindTarget;
            base.actor.ActorAction.OnSetTarget += OnSetTarget;
        }

        public void OnRemoveListener(IActor actor)
        {
            base.actor.ActorAction.OnFindTarget -= OnFindTarget;
            base.actor.ActorAction.OnSetTarget -= OnSetTarget;
        }

        protected override void Update()
        {
            base.Update();
            if (autoFindTarget)
            {
                if (findWhenTargetNull)
                {
                    if (target == null)
                    {
                        if (countUpdateFindTarget >= 0)
                        {
                            countUpdateFindTarget--;
                        }
                        else
                        {
                            OnFindTarget();
                            countUpdateFindTarget = maxUpdateFindTarget;
                        }
                    }
                }
                else
                {
                    if (countUpdateFindTarget >= 0)
                    {
                        countUpdateFindTarget--;
                    }
                    else
                    {
                        OnFindTarget();
                        countUpdateFindTarget = maxUpdateFindTarget;
                    }
                }
            }
        }

        public void OnFindTarget(bool _force = false)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layer);
            Array.Sort(colliders, new DistanceComparer(transform));

            Actor _actor;
            foreach (Collider item in colliders)
            {
                if (item.CompareTag(tag))
                {
                    _actor = item.GetComponent<Actor>();
                    if (_actor != null)
                    {
                        SetTarget(_actor);
                        return;
                    }
                }
            }
        }
        void OnSetTarget(Actor _target)
        {
            SetTarget(_target);
        }
        void SetTarget(Actor _target)
        {
            target = _target;
            if (target != null)
            {
                target.ActorAction.OnDie += OnDie;
            }
            actor.ActorAction.OnTargetChanged?.Invoke();
        }
        void OnDie(IActor _actor)
        {
            if (removeTargetWhenKilled)
            {
                if (target == (_actor as Actor))
                {
                    target = null;
                }
            }
        }
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (drawGizmos)
            {
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }
#endif
    }

}