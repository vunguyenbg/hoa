using UnityEngine;

namespace Yoolax.Framework
{
    public class SingletonDontDestroy<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject g = new GameObject(typeof(T).Name + "_Singleton");
                    instance = g.AddComponent<T>();
                    DontDestroyOnLoad(g);
                }

                return instance;
            }
        }

        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = GetComponent<T>();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    public class SingletonNormal<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = GetComponent<T>();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<T>();
                }
                return instance;
            }
        }

    }

}