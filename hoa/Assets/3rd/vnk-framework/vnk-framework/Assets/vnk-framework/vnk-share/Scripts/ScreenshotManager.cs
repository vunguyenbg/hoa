namespace Yoolax.Framework
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.Networking;

    public class ScreenshotManager : SingletonDontDestroy<ScreenshotManager>
    {
        private const string filename = "Screenshot_invite.png";
        public string GetFullPath()
        {
#if UNITY_EDITOR
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 7);
#else
            string path = Application.persistentDataPath;
#endif
            path = path + "/" + filename;
            return path;
        }
        public void SaveTexture2D(Texture2D texture)
        {
            string path = GetFullPath();
            if (string.IsNullOrEmpty(path)) return;
            System.IO.File.WriteAllBytes(path, texture.EncodeToPNG());
        }
        public Texture2D LoadTexture2D()
        {
            string path = GetFullPath();
            if (string.IsNullOrEmpty(path)) return null;
            if (System.IO.File.Exists(path))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(bytes);
                return texture;
            }
            return null;
        }
    }
}
