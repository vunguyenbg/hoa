
using PathologicalGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class DelayDespawn : MonoBehaviour
    {
        [SerializeField] private string poolKey;
        [SerializeField] private float duration = 2;

        private void OnEnable()
        {
            StartCoroutine(Despawn());
        }
        IEnumerator Despawn()
        {
            yield return Helper.Wait(duration);
            PoolManager.Pools[poolKey].Despawn(transform);
        }
    }

}