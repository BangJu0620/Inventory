using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                var singletonGO = new GameObject($"{typeof(UIManager)}");
                instance = singletonGO.AddComponent<UIManager>();
            }
            return instance;
        }
    }

    [SerializeField] UIMainMenu uiMainMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleStatus()
    {

    }

    public void ToggleInventory()
    {

    }
}
