using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : IState {

    [SerializeField] private string _animationName;
    [SerializeField] private float _speed = 1;
    [SerializeField] private bool _loop;
    [SerializeField] private float _normalizedTime;
    [SerializeField] private bool _isTrigger;

    public string AnimationName { get => _animationName; set => _animationName = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public bool Loop { get => _loop; set => _loop = value; }
    public float NormalizedTime { get => _normalizedTime; set => _normalizedTime = value; }
    public bool IsTrigger { get => _isTrigger; set => _isTrigger = value; }

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract void OnUpdate(float dt);
}