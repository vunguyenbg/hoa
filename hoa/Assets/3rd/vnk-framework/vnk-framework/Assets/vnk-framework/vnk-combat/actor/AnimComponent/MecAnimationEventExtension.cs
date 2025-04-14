namespace Yoolax.Framework
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class MecAnimationEventExtension
    {
       public static void AddAnimationEvent(this AnimationClip clip, float time, string functionName, string stringParameter)
        {
            float clipDuration = clip.length;
            if (time < 0f)
            {
                Debug.LogError("Event time must be greater >= than 0.0f seconds");
            }
            else if (time > clipDuration)
            {
                Debug.LogError("Event time must be less <= than the clip duration: " + clipDuration + "f seconds");
            }

            AnimationEvent animationEvent = new AnimationEvent
            {
                time = time,
                functionName = functionName,
                stringParameter = stringParameter
            };
            clip.AddEvent(animationEvent);
        }
        public static void RemoveAnimationEvent(this AnimationClip clip, string functionName)
        {
            for (int i = clip.events.Length - 1; i >= 0 ; i--)
            {
                if (clip.events[i].functionName.Equals(functionName))
                {
                    clip.events.ToList().RemoveAt(i);
                }
            }
        }
    }

}