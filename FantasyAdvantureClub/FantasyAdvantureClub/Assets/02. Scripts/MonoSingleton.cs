using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static T Inst
    {
        get
        {
            if (null == instance)
            {
                instance = UnityEngine.Object.FindObjectOfType(typeof(T)) as T;
                if (null == instance)
                {
                    var go = new GameObject(typeof(T).ToString() + "_Single");
                    DontDestroyOnLoad(go);
                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public static bool IsNull { get { return null == instance; } }


    private void Awake()
    {
        if (null != instance && this != instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);

            DoAwake();
        }
    }

    private void OnDestroy()
    {
        if (false == IsNull) { instance = null; }
    }

    protected virtual void DoAwake() { /* do nothing */ }
}
