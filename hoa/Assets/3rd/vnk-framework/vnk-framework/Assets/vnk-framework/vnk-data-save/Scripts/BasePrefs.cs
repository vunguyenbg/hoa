using System;

namespace Yoolax.Framework
{
    [Serializable]
    public abstract class BasePrefs
    {
        public abstract void OnLoad();
        public virtual void OnSave()
        {

        }
    }
}
