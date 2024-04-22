using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    private static bool onApplicationQuitting;

    private static object deadLock = new object();

    public static T Instance
    {
        get
        {
            object obj = deadLock;
            lock (obj)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                }
                if (instance == null)
                {
                    var gameObject = new GameObject(typeof(T).ToString());
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}