//
// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace  Yoolax.Framework
// {
//     public class BrainComponent : BaseComponent, IBrainComponent
//     {
//         [SerializeField] protected bool _isLocked = true;
//         [SerializeField] protected Brain _brain;
//         public bool IsLocked => _isLocked;
//
//         public override void AwakeComponent(IActor actor)
//         {
//             base.AwakeComponent(actor);
//             _brain.Init();
//         }
//         protected override void Start()
//         {
//             base.Start();
//             actor.ActorAction.OnBrainAddState?.Invoke(_brain.GetListState());
//             //OnSelectState(_brain._stateDefault);
//         }
//
//         protected override void Update()
//         {
//             base.Update();
//             if (_isLocked)
//                 return;
//
//             ExcuteTransitionState();
//         }
//         public void Lock(bool isLocked)
//         {
//             _isLocked = isLocked;
//         }
//         void ExcuteTransitionState()
//         {
//             for (int i = 0; i < _brain._transitions.Count; i++)
//             {
//                 if (CheckCondition(i))
//                 {
//                     OnSelectState(_brain._transitions[i]._state);
//                 }
//             }
//         }
//         bool CheckCondition(int stateID)
//         {
//             for (int j = 0; j < _brain._transitions[stateID]._conditions.Count; j++)
//             {
//                 if (!_brain._transitions[stateID]._conditions[j].IsCondition())
//                 {
//                     return false;
//                 }
//             }
//             return true;
//         }
//         void OnSelectState(IState state)
//         {
//             actor.ActorAction.OnBrainChangeState?.Invoke(state);
//         }
//     }
// }
