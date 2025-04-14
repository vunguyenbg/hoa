
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Yoolax.Framework
{
    public class ShareManager : SingletonDontDestroy<ShareManager>
    {

        public void ShareText(string text)
        {
#if NativeShare
            NativeShare share = new NativeShare();
            share.SetText(text);
            share.Share();
#endif
        }

        public void SharePicture(string text, string path)
        {
#if NativeShare
        NativeShare share = new NativeShare();
        share.AddFile(path);
        share.SetText(text);
        share.Share();
#endif
        }
    }
}
