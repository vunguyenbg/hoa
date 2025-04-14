using System;
using System.Collections.Generic;

namespace Yoolax.Framework
{
    [Serializable]
    public class GameDataFileStream
    {
        public void LoadData()
        {
            OnLoad();
        }
        public virtual void OnLoad()
        {
           
        }
        public virtual void OnSave()
        {
            
        }
    }

}