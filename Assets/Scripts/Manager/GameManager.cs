using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
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

    private void Start()
    {
        SetData();
    }

    void SetData()
    {
        //player = new Character(35, 40, 100, 25, 20000, 10, 12, 9, "Chad");
        // 아이템 추가
        foreach (var item in Resources.LoadAll<ItemData>("Item"))
        {
            player.GetItem(item);
        }
    }
}
