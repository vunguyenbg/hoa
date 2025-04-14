using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState {
    string AnimationName { set; get; }
    float Speed { set; get; }
    bool Loop { set; get; }
    float NormalizedTime { set; get; }
    bool IsTrigger { set; get; }
    void OnEnter();
    void OnUpdate(float dt);
    void OnExit();
}
