using UnityEngine;

namespace Yoolax.Framework
{
    public class BaseManager : MonoBehaviour
    {
        [HideInInspector]
        public Transform Group;

        protected virtual void Awake()
        {
            if (Group == null)
                Group = gameObject.transform;
            GetAllChilds();
        }

        public virtual void GetAllChilds()
        {
        }
    }

}