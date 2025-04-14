using Yoolax.Framework;
using System;
using UnityEngine;

namespace Yoolax.Framework
{
    public class InputComponent : BaseComponent, IInputComponent, IUpdate
    {
        public void UpdateComponent()
        {
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.D))
            {
                actor.ActorAction.OnMove?.Invoke(Vector3.right);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                actor.ActorAction.OnMove?.Invoke(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                actor.ActorAction.OnMove?.Invoke(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                actor.ActorAction.OnMove?.Invoke(Vector3.down);
            }
#endif
        }
    }

}