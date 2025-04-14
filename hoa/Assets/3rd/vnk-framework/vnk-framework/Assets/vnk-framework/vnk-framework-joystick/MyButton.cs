
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [System.Serializable] public class OnMouseDown : UnityEvent { }
        [System.Serializable] public class OnMouseUp : UnityEvent { }
        [System.Serializable] public class OnMouseUpdating : UnityEvent { }
        [SerializeField] public OnMouseDown onMouseDown;
        [SerializeField] public OnMouseUp onMouseUp;
        [SerializeField] public OnMouseUpdating onMouseUpdating;

        public enum MyButtonState
        {
            none,
            updating
        }
        public MyButtonState myButtonState;

        private Color preColor;
        private Color curColor = Color.red;
        private Color disableColor = Color.gray;
        private Image imgButton;
        private bool isUpdate;
        private bool callUpdateOnce;
        private bool isDisable_Mana;
        private bool isDisable_CoolDown;
        private bool isButtonDown;

        public void Awake()
        {
            imgButton = GetComponent<Image>();
            preColor = imgButton.color;
            isButtonDown = false;
        }
        public void OnEnable()
        {
            if (myButtonState == MyButtonState.updating)
                MyInputManager.btnCall += OnUpdate;
        }
        public void OnDisable()
        {
            if (myButtonState == MyButtonState.updating)
                MyInputManager.btnCall -= OnUpdate;
        }
        public void OnUpdate()
        {
            if (isButtonDown)
            {
                if (!isDisable_CoolDown)
                {
                    if (!isDisable_Mana)
                    {
                        if (isUpdate)
                            onMouseUpdating.Invoke();
                    }
                    else
                    {
                        if (callUpdateOnce)
                        {
                            callUpdateOnce = false;
                            isButtonDown = false;
                            if (isUpdate)
                                onMouseUpdating.Invoke();
                        }
                    }
                }
                else
                {
                    if (callUpdateOnce)
                    {
                        callUpdateOnce = false;
                        isButtonDown = false;
                        if (isUpdate)
                            onMouseUpdating.Invoke();
                    }
                }
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!isDisable_CoolDown)
            {
                if (!isDisable_Mana)
                {
                    onMouseDown.Invoke();
                    imgButton.color = curColor;
                    isUpdate = true;
                    isButtonDown = true;
                }
            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if (isButtonDown)
            {
                isButtonDown = false;
                if (!isDisable_Mana)
                {
                    onMouseUp.Invoke();
                    imgButton.color = preColor;
                    isUpdate = false;
                }
                else
                {
                    onMouseUp.Invoke();
                    imgButton.color = disableColor;
                    isUpdate = false;
                }
            }
        }
        public void SetDisableButton_Mana(bool _value)
        {
            isDisable_Mana = _value;
            if (!isDisable_Mana)
            {
                callUpdateOnce = true;
                imgButton.color = preColor;
            }
            else
                imgButton.color = disableColor;
        }
        public void SetDisableButton_CoolDown(bool _value)
        {
            if (!isDisable_CoolDown)
            {
                callUpdateOnce = true;
            }
            isDisable_CoolDown = _value;
        }
    }

}