using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    [RequireComponent(typeof(SphereCollider))]
    public class Gravity : MonoBehaviour
    {
        [SerializeField] protected float GRAVITY_PULL = .78f;
        [SerializeField] protected float gravityRadius = 1f;
        [SerializeField] protected bool stop;
        private SphereCollider sphere;
        Vector3 tempVelocity;
        public bool Stop => stop;

        private void Awake()
        {
            sphere = GetComponent<SphereCollider>();
            gravityRadius = sphere.radius;
        }
        public void DisableSphere()
        {
            sphere.enabled = false;
        }
        public void EnableSphere()
        {
            sphere.enabled = true;
        }
        public void AddGravity(Collider other, Vector3 target, float speed)
        {
            if (other.attachedRigidbody)
            {
                StartCoroutine(DelayAddGravity(other, target, speed, other.attachedRigidbody));
            }
        }
        IEnumerator DelayAddGravity(Collider other, Vector3 target, float speed, Rigidbody rigidbody)
        {
            yield return null;
            Vector3 vector3 = (target - other.transform.position).normalized * speed;
            tempVelocity = vector3;
            rigidbody.velocity = tempVelocity;
        }
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, gravityRadius);
        }
#endif
    }
}