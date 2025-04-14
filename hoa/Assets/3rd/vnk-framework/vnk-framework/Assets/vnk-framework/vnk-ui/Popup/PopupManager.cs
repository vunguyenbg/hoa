using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class PopupManager : BaseManager
    {
        public static PopupManager Instance;

        [SerializeField] private Dictionary<string, GameObject> popupsDict = new Dictionary<string, GameObject>();
        private GameObject maskCloseRef;

        [Header("Sub PopupManager")]
        public GameObject subPopupManager;

        public Action<BasePopup> OnPopupChanged;
        public Action OnOtherPopupChanged;

        public override void GetAllChilds()
        {
            base.GetAllChilds();
            for (int i = gameObject.transform.childCount - 1; i >= 0; i--)
            {
                BasePopup child = gameObject.transform.GetChild(i).GetComponent<BasePopup>();
                if (child != null)
                {
                    popupsDict[child.name] = child.gameObject;
                    child.gameObject.SetActive(false);
                    child.SetSubPopup(false);
                }
            }

            //GetSubPopup
            GetSubPopupManager();
        }

        void GetSubPopupManager()
        {
            for (int i = subPopupManager.transform.childCount - 1; i >= 0; i--)
            {
                BasePopup child = subPopupManager.transform.GetChild(i).GetComponent<BasePopup>();
                if (child != null)
                {
                    popupsDict[child.name] = child.gameObject;
                    child.gameObject.SetActive(false);
                    child.SetSubPopup(true);
                }
            }
        }
        protected override void Awake()
        {
            base.Awake();
            Instance = this;
        }

        public GameObject CreatePopup(string popupName)
        {
            if (!popupsDict.ContainsKey(popupName) || popupsDict[popupName] == null)
            {
                GameObject gObj = Instantiate(Resources.Load<GameObject>(string.Format("Popups/{0}", popupName)) as GameObject, Group) as GameObject;
                popupsDict[popupName] = gObj;
                return gObj;
            }
            GameObject popup = popupsDict[popupName];
            popup.transform.SetAsLastSibling();
            return popup;
        }

        public void OnHidePopup()
        {
            SetLastMaskClose();
        }
        public void HidePopupComplete(BasePopup popup)
        {
            SetFirstMaskClose();
            popup.transform.SetAsFirstSibling();
            BasePopup curPopup = null;
            BasePopup basePopup;
            BasePopup popupOrPanel = null;
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                basePopup = transform.GetChild(i).GetComponent<BasePopup>();
                if (basePopup != null)
                {
                    if (popupOrPanel == null && basePopup.ignoreMaskClose)
                    {
                        popupOrPanel = basePopup;
                    }

                    if (!basePopup.ignoreMaskClose)
                    {
                        curPopup = basePopup;
                        break;
                    }
                }
                else
                {
                    curPopup = null;
                }
            }

            if (popupOrPanel == null || !popupOrPanel.gameObject.activeInHierarchy)
            {
                popupOrPanel = null;
                for (int i = subPopupManager.transform.childCount - 1; i >= 0; i--)
                {
                    basePopup = subPopupManager.transform.GetChild(i).GetComponent<BasePopup>();
                    if (basePopup != null)
                    {
                        if (popupOrPanel == null && basePopup.ignoreMaskClose)
                        {
                            popupOrPanel = basePopup;
                        }
                        if (!basePopup.ignoreMaskClose)
                        {
                            curPopup = basePopup;
                            break;
                        }
                    }
                    else
                    {
                        curPopup = null;
                    }
                }
            }

            if (curPopup != null)
            {
                if (!curPopup.ignoreMaskClose)
                {
                    maskCloseRef.transform.SetParent(curPopup.transform);
                    SetFirstMaskClose();
                }
            }
            // Active in hirachy
            if (popupOrPanel != null)
            {
                popupOrPanel.OnActiveInHierarchy();

                if (popupOrPanel.gameObject.activeInHierarchy)
                {
                    CallWhenActivePopup(popupOrPanel);
                }
                else
                {
                    CallWhenActivePopup(null);
                }
            }
            else
            {
                CallWhenActivePopup(null);
            }
        }

       
        //MaskClose
        public void ShowMaskClose(Transform basePopup)
        {
            CreateMaskClose(basePopup);
            maskCloseRef.transform.SetParent(basePopup);
            SetFirstMaskClose();
        }
        GameObject CreateMaskClose(Transform basePopup)
        {
            if (maskCloseRef == null)
                maskCloseRef = Instantiate(Resources.Load<GameObject>("Popups/MaskClose"), basePopup) as GameObject;
            maskCloseRef.transform.localScale = Vector3.one;
            maskCloseRef.transform.localPosition = Vector3.zero;
            return maskCloseRef;
        }
        public void DestroyPopup(GameObject popup)
        {
            GameObject obj = null;
            popupsDict.TryGetValue(popup.name, out obj);
            if (obj != null)
            {
                popupsDict.Remove(popup.name);
                Destroy(obj);
            }
        }

        public void CallWhenActivePopup(BasePopup basePopup)
        {
            OnPopupChanged?.Invoke(basePopup);
        }

        void SetFirstMaskClose()
        {
            maskCloseRef.transform.SetAsFirstSibling();
            maskCloseRef.gameObject.SetActive(false);
        }
        void SetLastMaskClose()
        {
            maskCloseRef.transform.SetAsLastSibling();
            maskCloseRef.gameObject.SetActive(true);
        }
    }
}