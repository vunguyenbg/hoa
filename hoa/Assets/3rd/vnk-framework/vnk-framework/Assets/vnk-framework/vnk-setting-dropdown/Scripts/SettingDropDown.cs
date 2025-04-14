using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Yoolax.Framework
{
    public class SettingDropDown : MonoBehaviour
    {
        private bool isOn;
        private bool acceptUpdate;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private SwapSprite swapSpriteButtonSetting;
        [SerializeField] private ObjAwakePosition[] objButtonChildrens;
 
        private void OnEnable()
        {
            isOn = false;
            acceptUpdate = false;
            UpdateUI();
            acceptUpdate = true;
        }

        public void ButtonSetting()
        {
            isOn = !isOn;
            UpdateUI();
        }

        void UpdateUI() 
        {
            swapSpriteButtonSetting.ChangeSprite(isOn);

            if (isOn)
            {
                DOTween.KillAll();
                for (int i = 0; i < objButtonChildrens.Length; i++)
                {
                    ObjAwakePosition objAwakePosition = objButtonChildrens[i];
                    objAwakePosition.gameObject.SetActive(true);
                    objAwakePosition.transform.localPosition = swapSpriteButtonSetting.transform.localPosition;
                     objAwakePosition.transform.DOLocalMove(objAwakePosition.awakeLocalPosition, duration).SetUpdate(true);
                }
            }
            else
            {
                DOTween.KillAll();
                for (int i = 0; i < objButtonChildrens.Length; i++)
                {
                    ObjAwakePosition objAwakePosition = objButtonChildrens[i];

                    if (acceptUpdate)
                    {
                        objAwakePosition.transform.DOLocalMove(swapSpriteButtonSetting.transform.localPosition, duration).SetUpdate(true).OnComplete(()=>
                        {
                            objAwakePosition.gameObject.SetActive(false);
                        });
                    }
                    else
                    {
                        objAwakePosition.gameObject.SetActive(false);
                    }
                }
            }
        }

    }
}