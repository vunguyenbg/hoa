using DG.Tweening;
using PathologicalGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Yoolax.Framework
{
    public class GoldFly : MonoBehaviour
    {
        GoldManager goldManager;
        public void Init(GoldManager _goldManager)
        {
            goldManager = _goldManager;
        }
        private void OnDisable()
        {
            Push();
        }
        public void Push()
        {
            transform.SetParent(goldManager.transform);
        }
    }

}