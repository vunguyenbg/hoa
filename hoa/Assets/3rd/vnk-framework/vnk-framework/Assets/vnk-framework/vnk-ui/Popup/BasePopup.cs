using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;
using Sirenix.OdinInspector;

namespace Yoolax.Framework
{
    public class BasePopup : MonoBehaviour
    {
        public bool isSubPopup;
        public bool ignoreMaskClose;

        [Header("Intro")]
        public bool isIntro;
        [ShowIf("isIntro", true)][SerializeField] private UIAnimationConfig[] Intro_DOTweenAnimations;

        [Header("Outro")]
        public bool isOutro;
        [ShowIf("isOutro", true)][SerializeField] private float outroDuration = 0.7f;
        [ShowIf("isOutro", true)][SerializeField] private UIAnimationConfig[] Outro_DOTweenAnimations;

        [Header("BG Effect")]
        [SerializeField] private bool isScaleBG;
        [ShowIf("isScaleBG", true)][SerializeField] protected Transform bgScale = null;
        [ShowIf("isScaleBG", true)][SerializeField] protected Ease animShow = Ease.Linear;
        [ShowIf("isScaleBG", true)][SerializeField] protected Ease animHide = Ease.Linear;
        [ShowIf("isScaleBG", true)][SerializeField] protected float animDuration = 0.75f;


        [Header("Properties")]
        protected Vector3 customScale = new Vector3(0.25f, 0.25f, 0.25f);
        protected CanvasGroup canvasGroup;
        private Tween tween;



        public virtual void Init()
        {
            KillAllDoTweenAnimation();
            DoTween_IntroAnimation();
            PopupScaleShow();
            CallWhenActivePopup();
        }

        public virtual void Awake()
        {
            if (!isScaleBG)
            {
                bgScale = null;
            }

            if (bgScale != null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }

        public virtual void Start()
        {
            AddListener();
        }
        public virtual void OnDestroy()
        {
            RemoveListener();
        }

        public void CallWhenActivePopup()
        {
            PopupManager.Instance.OnPopupChanged?.Invoke(this);
        }

        public virtual void AddListener()
        {

        }
        public virtual void RemoveListener()
        {
        }

        public virtual void OnActiveInHierarchy()
        {
        }

        protected virtual void OnEnable()
        {
            if (!ignoreMaskClose)
            {
                PopupManager.Instance.ShowMaskClose(transform);
            }

        }
        protected virtual void OnDisable()
        {

        }
        public virtual void Hide()
        {
            DoTween_OutroAnimation();
            PopupScaleHide();
        }
        public virtual void PopupScaleShow()
        {
            if (bgScale != null)
            {
                bgScale.localScale = customScale;
                if (tween != null)
                {
                    tween.Kill();
                }
                tween = bgScale.DOScale(1f, animDuration).SetEase(animShow).SetUpdate(true);
                ShowAlpha();
            }
        }
        public virtual void PopupScaleHide()
        {
            if (bgScale != null)
            {
                if (tween != null)
                {
                    tween.Kill();
                }
                PopupManager.Instance.OnHidePopup();
                tween = bgScale.DOScale(0f, animDuration).SetEase(animHide).SetUpdate(true).OnComplete(() =>
                {
                    this.gameObject.SetActive(false);
                    PopupManager.Instance.HidePopupComplete(this);
                });
                HideAlpha();
            }
            else
            {
                if (isOutro)
                {
                    if (tween != null)
                    {
                        tween.Kill();
                    }
                    PopupManager.Instance.OnHidePopup();
                    float time = 0;
                    tween = DOTween.To(() => time, (val) => { }, 1f, outroDuration).SetUpdate(true).OnComplete(() =>
                    {
                        PopupManager.Instance.HidePopupComplete(this);
                        this.gameObject.SetActive(false);
                    });
                }
                else
                {
                    PopupManager.Instance.HidePopupComplete(this);
                    this.gameObject.SetActive(false);
                }
            }
        }

        public void SetSubPopup(bool value)
        {
            isSubPopup = value;
        }

        void ShowAlpha()
        {
            if (canvasGroup == null)
                return;
            canvasGroup.alpha = 0;
            DOTween.To(() => AlphaValue, x => AlphaValue = x, 1f, animDuration).SetEase(animShow).SetUpdate(true);
        }
        void HideAlpha()
        {
            if (canvasGroup == null)
                return;
            canvasGroup.alpha = 1f;
            DOTween.To(() => AlphaValue, x => AlphaValue = x, 0f, animDuration).SetEase(animShow).SetUpdate(true);
        }


        float alphaValue;
        float AlphaValue
        {
            set
            {
                alphaValue = value;
                canvasGroup.alpha = alphaValue;
            }
            get
            {
                return alphaValue;
            }
        }


        protected IEnumerator DelayCallback(float time, Action callback)
        {
            yield return Helper.Wait(time);
            callback?.Invoke();
        }
        protected IEnumerator DelayCallbackRealTime(float time, Action callback)
        {
            yield return Helper.WaitRealTime(time);
            callback?.Invoke();
        }
        protected IEnumerator DelayCallbackEndOfFrame(Action callback)
        {
            yield return new WaitForEndOfFrame();
            callback?.Invoke();
        }

        void KillAllDoTweenAnimation()
        {
            if (tween != null)
            {
                tween.Kill();
            }
        }

        void DoTween_IntroAnimation()
        {
            if (isIntro)
            {
                for (int i = 0; i < Intro_DOTweenAnimations.Length; i++)
                {
                    if (Intro_DOTweenAnimations[i] != null && Intro_DOTweenAnimations[i].tweenAnimation != null)
                    {
                        Intro_DOTweenAnimations[i].tweenAnimation.DORestart();
                    }
                }
            }
        }
        void DoTween_OutroAnimation()
        {
            if (isOutro)
            {
                for (int i = 0; i < Outro_DOTweenAnimations.Length; i++)
                {
                    UIAnimationConfig uiAnimationConfig = Outro_DOTweenAnimations[i];

                    if (uiAnimationConfig != null && uiAnimationConfig.tweenAnimation != null)
                    {
                        if (uiAnimationConfig.isPlayBackwards)
                        {
                            float timeDelayPlayBackWards;
                            if (uiAnimationConfig.outro_TimeDelay <= 0)
                            {
                                timeDelayPlayBackWards = uiAnimationConfig.tweenAnimation.delay;
                            }
                            else
                            {
                                timeDelayPlayBackWards = uiAnimationConfig.outro_TimeDelay;
                            }
                            DOTween.Sequence()
                            .AppendInterval(timeDelayPlayBackWards)
                            .AppendCallback(() =>
                            {
                                uiAnimationConfig.tweenAnimation.DOPlayBackwards();
                            });
                        }
                        else
                        {
                            uiAnimationConfig.tweenAnimation.DORestart();
                        }
                    }
                }
            }
        }
    }

}
