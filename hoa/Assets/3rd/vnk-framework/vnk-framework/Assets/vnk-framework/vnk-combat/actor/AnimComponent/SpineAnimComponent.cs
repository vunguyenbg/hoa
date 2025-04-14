#if UNITY_SPINE
using Spine;
using Spine.Unity;
using System;
using UnityEngine;

namespace Yoolax.Framework
{
    public class SpineAnimComponent : BaseComponent, ISpineAnimComponent
    {
        [SerializeField]
        private SkeletonAnimation _anim;

        public SkeletonAnimation Anim { set => _anim = value; get => _anim; }
        private AnimationInfo _animationInfo = new AnimationInfo();
        private EventInfo _eventInfo = new EventInfo();

        public override void AwakeComponent(IActor actor)
        {
            base.AwakeComponent(actor);
            _actor.ActorAction.OnStateChanged += OnStateChanged;
        }
        protected override void Start()
        {
            base.Start();
            ListenAnimState();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            RemoveAnimState();
        }

        void OnStateChanged(IState state)
        {
            SetAnimation(state.AnimationName, state.Loop);
        }
        private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
        {
            _animationInfo.Init(trackEntry.Animation.Name);
            _eventInfo.Init(e.Data.Name);
            _actor.ActorAction.OnEvent?.Invoke(_animationInfo, _eventInfo);
        }
        private void OnAnimSpineComplete(TrackEntry trackEntry)
        {
            _animationInfo.Init(trackEntry.Animation.Name);
            _actor.ActorAction.OnComplete?.Invoke(_animationInfo);
        }
        public TrackEntry SetAnimation(string animationName, bool isLoop = false)
        {
            TrackEntry trackEntry = _anim.AnimationState.SetAnimation(0, animationName, isLoop);

            _animationInfo.Init(animationName);
            _actor.ActorAction.OnStart?.Invoke(_animationInfo);
            return trackEntry;
        }
        public void ListenAnimState()
        {
            _anim.AnimationState.Complete += OnAnimSpineComplete;
            _anim.AnimationState.Event += OnSpineEvent;
        }
        public void RemoveAnimState()
        {
            _anim.AnimationState.Complete -= OnAnimSpineComplete;
            _anim.AnimationState.Event -= OnSpineEvent;
        }
        public void FlipX(bool value)
        {
            if (value)
            {
                _actor.Trans.localScale = new Vector3(Mathf.Abs(_actor.Trans.localScale.x), _actor.Trans.localScale.y, _actor.Trans.localScale.z);
            }
            else
            {
                _actor.Trans.localScale = new Vector3(-Mathf.Abs(_actor.Trans.localScale.x), _actor.Trans.localScale.y, _actor.Trans.localScale.z);
            }
        }
    }
}
#endif
