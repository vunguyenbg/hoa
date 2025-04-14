using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TypeReferences;
using UnityEngine;

namespace Yoolax.Framework
{
    [System.Serializable]
    public class Transition
    {
        [SerializeField, ClassExtends(typeof(IState))]
        [FoldoutGroup("@_stateRef")] private ClassTypeReference _stateRef;
        [FoldoutGroup("@_stateRef")] public string _animationName;
        [FoldoutGroup("@_stateRef")] public float _speed = 1;
        [FoldoutGroup("@_stateRef")] public bool _loop;
        [FoldoutGroup("@_stateRef")] public float _normalizedTime;
        [SerializeField, ClassExtends(typeof(IAIBase))]
        [FoldoutGroup("@_stateRef")] private List<ClassTypeReference> _conditionsRef;


        [HideInInspector] public IState _state;
        [HideInInspector] public List<IAIBase> _conditions;

        public void Init()
        {
            _state = (IState)System.Activator.CreateInstance(_stateRef);
            _state.AnimationName = _animationName;
            _state.Speed = _speed;
            _state.Loop = _loop;
            _state.NormalizedTime = _normalizedTime;
            _conditions = new List<IAIBase>();
            for (int i = 0; i < _conditionsRef.Count; i++)
            {
                _conditions.Add((IAIBase)System.Activator.CreateInstance(_conditionsRef[i]));
            }
        }
    }
}