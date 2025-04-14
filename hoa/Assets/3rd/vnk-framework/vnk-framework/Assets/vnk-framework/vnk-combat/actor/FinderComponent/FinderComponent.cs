using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class FinderComponent : BaseComponent, IFinderComponent
    {
        [SerializeField] private Actor target;
        [SerializeField] private bool removeTargetWhenKilled;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask layer = ~0;
        [SerializeField] private string tag = string.Empty;
        [SerializeField] private bool autoFindTarget;
        [SerializeField] private int maxUpdateFindTarget;
        private int countUpdateFindTarget;
        [SerializeField] private bool changeTargetWhenTooFar;
        [SerializeField] private bool drawGizmos;
        public Actor Target { get => target; set => target = value; }
        public float Radius { get => radius; set => radius = value; }
        public LayerMask LayerMask { get => layer; set => layer = value; }
        public bool AutoFindTarget { get => autoFindTarget; set => autoFindTarget = value; }

        public override void AwakeComponent(IActor actor)
        {
            base.AwakeComponent(actor);
            base.actor.ActorAction.OnFindTarget += OnFindTarget;
            base.actor.ActorAction.OnSetTarget += OnSetTarget;
            countUpdateFindTarget = maxUpdateFindTarget;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            actor.ActorAction.OnFindTarget -= OnFindTarget;
            actor.ActorAction.OnSetTarget -= OnSetTarget;
        }
        protected override void Update()
        {
            base.Update();
            if (autoFindTarget)
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
                else
                {
                    if (changeTargetWhenTooFar)
                    {
                        if (countUpdateFindTarget >= 0)
                        {
                            countUpdateFindTarget--;
                        }
                        else
                        {
                            ChangeTargetWhenTooFar();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_force">Force Find Target</param>
        public void OnFindTarget(bool _force = false)
        {
            if (!_force && target != null)
            {
                return;
            }

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
        void ChangeTargetWhenTooFar()
        {
            if (target != null)
            {
                if (Vector3.Distance(actor.Trans.position, target.Trans.position) > radius)
                {
                    SetTarget(null);
                }
            }
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
        void OnSetTarget(Actor _target)
        {
            SetTarget(_target);
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