using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Yoolax.Framework
{
    public class UIButton : Button
    {
        [SerializeField]
        private bool isScale = true;
        [SerializeField]
        private bool isAudio = true;

        //private Image hover;

        private Vector3 vec3Default;
        private Vector3 vec3Scale;
        private float duration = 0.1f;

        public UnityEvent onButtonDown;

        protected override void Awake()
        {
            vec3Default = transform.localScale;
            vec3Scale = new Vector3(vec3Default.x * 0.97f, vec3Default.y * 0.97f, 1);
           // hover = this.hover;
            var colors = this.colors;
            colors.pressedColor = new Color(0.57f, 0.57f, 0.57f);
            this.colors = colors;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (isScale && this.interactable)
            {
                transform.DOScale(vec3Scale, duration).SetUpdate(true);
            }
#if UNITY_AUDIO
            if (isAudio && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayAudio_Button();
            }
#endif
            ////if (DataManager.Instance.GameSettingPrefs.vibration)
            ////{
            ////    Vibration.Vibrate(10);
            ////}
            onButtonDown?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (isScale && this.interactable)
                transform.DOScale(vec3Default, duration).SetUpdate(true);
        }
    }

}