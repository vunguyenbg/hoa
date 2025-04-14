using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class Bullet_HomingMissile : MonoBehaviour
    {
         private Transform target;
        [SerializeField] private float speed = 5;
        [SerializeField] private bool isMove;
        private Vector3 direction;
        
        public void Init(Transform _target)
        {
            target = _target;
        }
        public void Move()
        {
            isMove = true;
        }
        public void Stop()
        {
            isMove = false;
        }
        private void Update()
        {
            if (isMove)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (target != null)
                {
                    direction = (target.position - transform.position).normalized;
                    var rotate = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotate, speed * Time.deltaTime);
                }
            }
        }
    }
}
