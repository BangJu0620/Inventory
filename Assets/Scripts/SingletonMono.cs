using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour   // 특강에서 배운 내용 토대로 만들어본 Singleton
{
    private static T instance;

    public static T Instance 
    { 
        get
        {
            if (instance == null)   // 없다면 새로 만들어서 T 타입으로 컴포넌트 달아주기
            {
                var singletonGO = new GameObject($"{typeof(T)}");
                instance = singletonGO.AddComponent<T>();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }

    public virtual void Release()   // 필요없는 것들 없애기 위한 Relaese, 씬 넘어가면 안 쓰는 것들 등
    {
        if (instance == null) return;
        if (instance.gameObject) Destroy(instance.gameObject);

        instance = null;
    }
}
