using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [field:SerializeField] public int Gold { get; private set; }
    [field:SerializeField] public int Level { get; private set; }
    [field:SerializeField] public int MaxExp { get; private set; }
    [field:SerializeField] public int CurExp { get; private set; }

    public EquipItemData equip;

    public UIInventory inventory;

    private void Start()
    {
        
    }
    //public void Init()
    //{
    //    Health = 100;
    //    maxHealth = Health;
    //    curHealth = Health;
    //    Attack = 35;
    //    Deffense = 40;
    //    Critical = 25;
    //    Name = "Chad";
    //    Gold = 20000;
    //    Level = 10;
    //    MaxExp = 12;
    //    CurExp = 9;
    //}

    public void AddItem(ItemData item)
    {
        Debug.Log("AddItem");
        // 인벤토리에 아이템 추가하기
        //foreach(var slot in inventory.Slots)
        //{
        //    if(slot.Item == null)
        //    {
        //        slot.Item = item;
        //        break;
        //    }
        //}
        inventory.AddItem(item);
    }

    public void Equip(EquipItemData equip)
    {
        if (this.equip != null)
        {
            UnEquip();
        }
        this.equip = equip;
        this.equip.isEquipped = true;
        AddStatus(this.equip);
    }

    public void UnEquip()
    {
        equip.isEquipped = false;
        RemoveStatus(equip);
        equip = null;
    }

    public void AddStatus(EquipItemData equip)
    {
        Attack += equip.Attack;
        Deffense += equip.Deffense;
        Health += equip.Health;
        Critical += equip.Critical;
    }

    public void RemoveStatus(EquipItemData equip)
    {
        Attack -= equip.Attack;
        Deffense -= equip.Deffense;
        Health -= equip.Health;
        Critical -= equip.Critical;
    }
}
