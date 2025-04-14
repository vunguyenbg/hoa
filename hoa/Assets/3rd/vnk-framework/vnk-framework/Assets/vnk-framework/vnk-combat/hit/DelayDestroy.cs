using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class DelayDestroy : MonoBehaviour
    {
        [SerializeField] private float duration = 2;
        IEnumerator Start()
        {
            yield return Helper.Wait(duration);
            Destroy(gameObject);
        }
    }

}