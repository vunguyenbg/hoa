using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class CameraScaler : MonoBehaviour
    {
        [System.Serializable]
        public class CamScaler
        {
            public Vector2 ScreenSizes;
            public float orthographicSize;
            public CamScaler(Vector2 ScreenSizes, float orthographicSize)
            {
                this.ScreenSizes = ScreenSizes;
                this.orthographicSize = orthographicSize;
            }
        }
        [SerializeField]
        public CamScaler[] camScalers = new CamScaler[]
        {
        new CamScaler(new Vector2(720, 1280), 25),
        new CamScaler(new Vector2(1080, 1920), 25),
        new CamScaler(new Vector2(480,  800), 25),
        new CamScaler(new Vector2(480,  854), 25),
        new CamScaler(new Vector2(540,  960), 25),
        new CamScaler(new Vector2(600, 1024), 25),
        new CamScaler(new Vector2(800,  1280), 25),
        new CamScaler(new Vector2(1440, 2560), 25),
        new CamScaler(new Vector2(320,  480), 25),
        new CamScaler(new Vector2(1200, 1920), 25),
        new CamScaler(new Vector2(768, 1024), 25),
        new CamScaler(new Vector2(1440, 2960), 25),
        new CamScaler(new Vector2(1080, 2160), 25),
        new CamScaler(new Vector2(600, 1024), 25),
        new CamScaler(new Vector2(800,1280), 25),
        };

        private void Awake()
        {
            //orthographicSizeDefault = Camera.main.orthographicSize;
            UpdateOrthographicSize();
        }
#if UNITY_EDITOR
        private void Update()
        {
            UpdateOrthographicSize();
        }
#endif
        void UpdateOrthographicSize()
        {
            for (int i = 0; i < camScalers.Length; i++)
            {
                if (Camera.main.pixelWidth == camScalers[i].ScreenSizes.x
                    && Camera.main.pixelHeight == camScalers[i].ScreenSizes.y)
                {
                    Camera.main.orthographicSize = camScalers[i].orthographicSize;
                    break;
                }
            }

        }
    }

}