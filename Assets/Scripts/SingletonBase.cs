

using UnityEngine;


public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{

    private static object _syncobj = new object();
    private static T _instance = null;
    private static bool isAppIsClosing = false;

    public static T Instance
    {
        get
        {
            if (isAppIsClosing) return null;

            lock (_syncobj)
            {
                if (_instance == null)
                {
                    T[] objs = FindObjectsOfType<T>();

                    if (objs.Length > 0)
                    {
                        _instance = objs[0];
                    }

                    if (objs.Length > 1)
                    {
                        Debug.Log("There is more than one " + typeof(T).Name + " in the scene.");
                    }

                    if (_instance == null)
                    {
                        string goName = typeof(T).ToString();
                        GameObject go = GameObject.Find(goName);
                        if (go == null)
                        {
                            go = new GameObject(goName);
                        }
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
    }

    private void OnDestroy()
    {
        if(_instance != null)
        {
            if(_instance.gameObject)    Destroy(_instance.gameObject);
            _instance = null;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        isAppIsClosing = true;
    }
}

