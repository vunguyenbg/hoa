using UnityEngine;

namespace Yoolax.Framework
{
    public static class SupportScreenSize
    {
        //Doc
       // static readonly Vector3[] ScreenSizes_Portrait = new[]
       // {
       //     new Vector3(720, 1280, 0), new Vector3(1080, 1920, 0), new Vector3(480,  800, 0), new Vector3(480,  854, 0),
       //     new Vector3(540,  960, 0), new Vector3(600, 1024, 0), new Vector3(800,  1280, 0), new Vector3(1440, 2560, 0),
       //     new Vector3(320,  480, 0), new Vector3(1200, 1920, 0), new Vector3(768, 1024, 1),new Vector3(1440, 2960, 0)
       //     ,new Vector3(1080, 2160, 0), new Vector3(600, 1024, 1),
       //     new Vector3(800,1280, 1), 
       // };
       //// Ngang
         static readonly Vector3[] ScreenSizes_Landscape = new[]
       {
            new Vector3(1280, 720), new Vector3(1920, 1080), new Vector3(800,  480), new Vector3(854,  480),
            new Vector3(960,  540), new Vector3(1024, 600), new Vector3(1280,  800), new Vector3(2560, 1440),
            new Vector3(480,  320), new Vector3(1920, 1200), new Vector3(1024, 768),new Vector3(2960, 1440),new Vector3(2160, 1080), new Vector3(1024,600),
            new Vector3(1280,800),
        };

        public static Vector3[] GetScreenSize()
        {
            //if (Screen.width > Screen.height)
            //{
                return ScreenSizes_Landscape;
            //}
            //else
            //{
            //    return ScreenSizes_Portrait;
            //}
        }

    }
}