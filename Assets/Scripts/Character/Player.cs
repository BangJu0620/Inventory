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

    public void AddItem()
    {
        
    }

    public void Equip(EquipItemData equip)
    {
        if (equip != null)
        {
            UnEquip();
        }
        this.equip = equip;
        AddStatus(equip);
    }

    public void UnEquip()
    {
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
