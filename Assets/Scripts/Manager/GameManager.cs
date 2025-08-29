using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
    //private static GameManager instance;

    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new GameObject("GameManager").AddComponent<GameManager>();
    //        }
    //        return instance;
    //    }
    //}

    Player player;
    public Player Player 
    { 
        get 
        {
            if (player == null)
            {
                player = Resources.Load<GameObject>("Character/Player").GetComponent<Player>();
            }
            return player;
        } 
    }

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
        SetData();
    }

    void SetData()
    {
        //player = new Character(35, 40, 100, 25, 20000, 10, 12, 9, "Chad");
        // 아이템도 추가
        foreach (var item in Resources.LoadAll<ItemData>("Item"))
        {
            player.AddItem(item);
        }
    }
}
