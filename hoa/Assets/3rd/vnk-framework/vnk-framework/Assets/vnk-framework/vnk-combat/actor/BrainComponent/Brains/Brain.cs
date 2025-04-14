using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TypeReferences;
using UnityEngine;
using UnityEngine.UIElements;

namespace  Yoolax.Framework
{
    public class Brain : ScriptableObject
    {
        [SerializeField, ClassExtends(typeof(IState))]
        private ClassTypeReference _stateDefaultRef;
        public string _animationName;
        public float _speed = 1;
        public bool _loop;
        public float _normalizedTime;
        public bool _isTrigger;
        public List<Transition> _transitions;

        [HideInInspector] public IState _stateDefault;

        public void Init()
        {
            _stateDefault = (IState)System.Activator.CreateInstance(_stateDefaultRef);
            _stateDefault.AnimationName = _animationName;
            _stateDefault.Speed = _speed;
            _stateDefault.Loop = _loop;
            _stateDefault.NormalizedTime = _normalizedTime;
            _stateDefault.IsTrigger = _isTrigger;

            for (int i = 0; i < _transitions.Count; i++)
            {
                _transitions[i].Init();
            }
        }
        public List<IState> GetListState()
        {
            List<IState> states = new List<IState>();
            IState state;
            for (int i = 0; i < _transitions.Count; i++)
            {
                state = _transitions[i]._state;
                if (!states.Contains(state))
                    states.Add(state);
                state.IsTrigger = _isTrigger;
            }
            return states;
        }

    }
}
