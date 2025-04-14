using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleSheetsToUnity.ThirdPary;
using Sirenix.OdinInspector;
using UnityEngine;
namespace Yoolax.Framework
{
    public class DB_Base : SerializedScriptableObject
    {
        public virtual IEnumerator PullDatabase()
        {
            yield return null;
        }

        public virtual bool CheckDatabase()
        {
            return false;
        }

#if UNITY_EDITOR
        [Button("Pull Data")]
        public void PullEditor()
        {
            EditorCoroutineRunner.StartCoroutine(PullDatabase());
        }
#endif
    }
}
