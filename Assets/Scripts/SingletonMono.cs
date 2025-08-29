using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour   // Ư������ ��� ���� ���� ���� Singleton
{
    private static T instance;

    public static T Instance 
    { 
        get
        {
            if (instance == null)   // ���ٸ� ���� ���� T Ÿ������ ������Ʈ �޾��ֱ�
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

    public virtual void Release()   // �ʿ���� �͵� ���ֱ� ���� Relaese, �� �Ѿ�� �� ���� �͵� ��
    {
        if (instance == null) return;
        if (instance.gameObject) Destroy(instance.gameObject);

        instance = null;
    }
}
