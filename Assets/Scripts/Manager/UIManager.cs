using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>
{
    //Dictionary<string, GameObject> uiPrefabs;
    GameObject[] uiPrefabs;

    UIMainMenu uiMainMenu;
    public UIMainMenu UIMainMenu { get { return uiMainMenu; } set { uiMainMenu = value; } }

    protected override void Awake()
    {
        base.Awake();

        //uiPrefabs = Resources.LoadAll<GameObject>("UI").ToDictionary(prefab => prefab.name, prefab => prefab);
        uiPrefabs = Resources.LoadAll<GameObject>("UI");

        InitMainUI();
    }

    void InitMainUI()
    {
        foreach(var uiPrefab in uiPrefabs)
        {
            Instantiate(uiPrefab, transform);
        }
    }

    public void ToggleStatus()
    {

    }

    public void ToggleInventory()
    {

    }
}
