using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>
{
    //private static UIManager instance;

    //public static UIManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            var singletonGO = new GameObject($"{typeof(UIManager)}");
    //            instance = singletonGO.AddComponent<UIManager>();
    //        }
    //        return instance;
    //    }
    //}

    public UIMainMenu uiMainMenu;
    public UIStatus uiStatus;
    public UIInventory uiInventory;

    protected override void Awake()
    {
        base.Awake();
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Start()
    {
        uiMainMenu.OpenUI();
        uiStatus.CloseUI();
        uiInventory.CloseUI();
    }

    void GetUI()
    {
        //uiStatus = uiStatus.GetUI();
    }

    public void OpenStatus()
    {
        uiMainMenu.CloseUI();
        uiStatus.OpenUI();
    }

    public void CloseStatus()
    {
        uiMainMenu.OpenUI();
        uiStatus.CloseUI();
    }

    public void OpenInventory()
    {
        uiMainMenu.CloseUI();
        uiInventory.OpenUI();
    }

    public void CloseInventory()
    {
        uiMainMenu.OpenUI();
        uiInventory.CloseUI();
    }
}
