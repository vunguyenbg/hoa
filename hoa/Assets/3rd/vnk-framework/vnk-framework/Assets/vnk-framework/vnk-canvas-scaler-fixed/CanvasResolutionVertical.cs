using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Yoolax.Framework
{
    public class CanvasResolutionVertical : CanvasResolution
    {
        [Button]
        public void CreateProfile()
        {
            profiles.Clear();
            Vector2[] ScreenSizes = ScreenSizeBase.GetScreenSizeVertical();
            for (int i = 0; i < ScreenSizes.Length; i++)
            {
                Vector2 screenSize = ScreenSizes[i];
                profiles.Add(new CanvasProfileBase(screenSize, screenSize.x / screenSize.y, UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight, 0));
            }
            profiles.OrderByDescending(x=> x.aspectRatio).First();
        }
        [Button]
        void Short()
        {
            profiles.OrderByDescending(x => x.aspectRatio).First();
        }
    }

}