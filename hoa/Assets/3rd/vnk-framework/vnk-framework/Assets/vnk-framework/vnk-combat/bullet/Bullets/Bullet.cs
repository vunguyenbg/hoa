namespace Yoolax.Framework
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bullet : MonoBehaviour, IBullet
    {
        #region Variables
        protected IActor attacker;
        protected IActor defender;
        protected Vector3 targetPosition;
        protected Vector3 direction;

        protected bool isActive;
        protected Transform trans;
        protected Action onComplete;
        [SerializeField] protected float speed = 10;

        public bool IsActive { get => isActive; set => isActive = value; }
        public Transform Trans => trans;
        #endregion

        public virtual void Init(IActor attacker = null, IActor defender = null, float damage = 0)
        {
            this.attacker = attacker;
            this.defender = defender;
        }
        public virtual void Init(IActor attacker = null, IActor defender = null, Vector3 _direction = (default))
        {
            this.attacker = attacker;
            this.defender = defender;
            this.direction = _direction;
        }
        public virtual void Init(Vector3 _targetPosition)
        {
            targetPosition = _targetPosition;
        }
        public virtual void Init(Vector3 _targetPosition, Action _onComplete)
        {
            targetPosition = _targetPosition;
            onComplete = _onComplete;
        }
      

        /// <summary>
        /// Get All Component in gameobject
        /// </summary>
        protected virtual void Awake()
        {
            trans = transform;
        }
    }

}