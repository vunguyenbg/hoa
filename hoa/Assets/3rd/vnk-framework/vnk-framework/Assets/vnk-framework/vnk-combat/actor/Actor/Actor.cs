
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace Yoolax.Framework
{
    public class Actor : MonoBehaviour, IActor
    {
        #region Variables
        private IAwake[] AwakeComponents;
        private IEnable[] EnableComponents;
        private IStart[] StartComponents;
        private IUpdate[] UpdateComponents;
        private IDisable[] DisableComponents;
        private IDestroy[] DestroyComponents;
        private IListener[] ListenerComponents;
        protected Transform trans;
        protected ActorAction _actorAction;

        private IMovementComponent movementComponent;
        private IStateComponent stateComponent;
        private IStatsComponent statsComponent;
        private IHealthComponent healthComponent;
        private IManaComponent manaComponent;
        private IAnimComponent animComponent;
        private ISkillComponent skillComponent;
        public IMovementComponent MovementComponent => movementComponent;
        public IStateComponent StateComponent => stateComponent;
        public IStatsComponent StatsComponent => statsComponent;
        public IHealthComponent HealthComponent => healthComponent;
        public IManaComponent ManaComponent => manaComponent;
        public IAnimComponent AnimComponent => animComponent;
        public ISkillComponent SkillComponent => skillComponent;

        public Transform Trans => trans;

        private bool isDie;
        public bool IsDie { get => isDie; set => isDie = value; }
        public ActorAction ActorAction 
        {
            get 
            {
                if (_actorAction == null)
                {
                    _actorAction = new ActorAction();
                }
                return _actorAction;
            } 
            set => _actorAction = value; 
        }


        #endregion

        #region Method
        /// <summary>
        /// Get All Component in gameobject
        /// </summary>
        protected virtual void Awake()
        {
            trans = transform;
            if (_actorAction == null)
            {
                _actorAction = new ActorAction();
            }

            GetComponent();
            FindAllComponent();
            //Awake
            foreach (var component in AwakeComponents)
            {
                component.AwakeComponent(this);
            }
            foreach (var component in ListenerComponents)
            {
                component.OnAddListener(this);
            }
        }
        void FindAllComponent()
        { //IAwakeComponent
            AwakeComponents = GetComponents<IAwake>();
            //IEnableComponent
            EnableComponents = GetComponents<IEnable>();
            //IStartComponent
            StartComponents = GetComponents<IStart>();
            //IUpdateComponent
            UpdateComponents = GetComponents<IUpdate>();
            //IDisableComponent
            DisableComponents = GetComponents<IDisable>();
            //IDestroyComponent
            DestroyComponents = GetComponents<IDestroy>();
            //ListenerComponents
            ListenerComponents = GetComponents<IListener>();
        }
        void GetComponent()
        {
            movementComponent = GetComponent<IMovementComponent>();
            if (movementComponent == null)  movementComponent = gameObject.AddComponent<NullMovementComponent>();

            stateComponent = GetComponent<IStateComponent>();
            if (stateComponent == null) stateComponent = gameObject.AddComponent<NullStateComponent>();

            statsComponent = GetComponent<IStatsComponent>();
            if (statsComponent == null) statsComponent = gameObject.AddComponent<NullStatsComponent>();

            healthComponent = GetComponent<IHealthComponent>();
            if (healthComponent == null) healthComponent = gameObject.AddComponent<NullHealthComponent>();

            manaComponent = GetComponent<IManaComponent>();
            if (manaComponent == null) manaComponent = gameObject.AddComponent<NullManaComponent>();

            animComponent = GetComponent<IAnimComponent>();
            if (animComponent == null) animComponent = gameObject.AddComponent<NullAnimComponent>();

            skillComponent = GetComponent<ISkillComponent>();
            if (skillComponent == null) skillComponent = gameObject.AddComponent<NullSkillComponent>();

        }

        /// <summary>
        /// enable Component
        /// </summary>
        protected virtual void OnEnable()
        {
            if (EnableComponents == null)
                return;
            foreach (var component in EnableComponents)
            {
                component.EnableComponent(this);
            }
        }
        /// <summary>
        /// Init Component
        /// </summary>
        protected virtual void Start()
        {
            if (StartComponents == null)
                return;
            foreach (var component in StartComponents)
            {
                component.StartComponent(this);
            }
        }
        /// <summary>
        /// Init Component
        /// </summary>
        protected virtual void Update()
        {
            if (UpdateComponents == null)
                return;
            foreach (var component in UpdateComponents)
            {
                component.UpdateComponent();
            }
        }

        /// <summary>
        /// Disable Component
        /// </summary>
        protected virtual void OnDisable()
        {
            if (DisableComponents == null)
                return;
            foreach (var component in DisableComponents)
            {
                component.DisableComponent(this);
            }
        }

        /// <summary>
        /// Destroy Component
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (ListenerComponents != null)
            {
                foreach (var component in ListenerComponents)
                {
                    component.OnRemoveListener(this);
                }
            }
            if (DestroyComponents == null)
                return;
            foreach (var component in DestroyComponents)
            {
                component.DestroyComponent(this);
            }
        }
#endregion

    }
}
