using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenSizeBase
{
    public static readonly Vector2[] ScreenSizes = new[]
    {
         new Vector2(720, 1280), new Vector2(1080, 1920), new Vector2(480,  800), new Vector2(480,  854),
         new Vector2(540,  960), new Vector2(600, 1024), new Vector2(800,  1280), new Vector2(1440, 2560),
         new Vector2(320,  480), new Vector2(1200, 1920), new Vector2(768, 1024),new Vector2(1440, 2960)
         ,new Vector2(1080, 2160), new Vector2(600, 1024),
     };

    public static Vector2[] GetScreenSizeVertical()
    {
        return ScreenSizes;
    }
    public static Vector2[] GetScreenSizeHorizontal()
    {
        Vector2[] screenSizes = new Vector2[ScreenSizes.Length];
        Vector2 size;
        for (int i = 0; i < ScreenSizes.Length; i++)
        {
            size = ScreenSizes[i];
            screenSizes[i] = new Vector2(size.y, size.x);
        }
        return screenSizes;
    }

}
