using UnityEngine;

namespace Yoolax.Framework
{
    public class BaseItem : MonoBehaviour
    {
        public virtual void SetDefault()
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
        }
    }
}

