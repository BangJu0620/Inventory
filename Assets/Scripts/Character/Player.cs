using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [field:SerializeField] public int Gold { get; private set; }
    [field:SerializeField] public int Level { get; private set; }
    [field:SerializeField] public int MaxExp { get; private set; }
    [field:SerializeField] public int CurExp { get; private set; }

    EquipItemData equip;    // 현재 장착하고 있는 아이템 정보
    // 부위별로 장착 가능하게 할려면 어떤 식으로 접근해야 좋지?
    // 장비를 타입별로 나누고 타입별로 한 개씩 장착 가능하게 해야되나?
    // 아이템에 장착가능 타입으로 나눈 것처럼 나누면 될려나
    // 장신구같이 여러개 장착 가능한 아이템은?
    // 컬렉션으로 모아서 관리해야 되나?

    [NonSerialized] public UIInventory inventory;

    public void GetItem(ItemData item)  // 아이템 획득
    {
        inventory.AddItem(item);
    }

    public void Equip(EquipItemData equip)  // 아이템 장착
    {
        if (this.equip != null) // 이미 장착하고 있는 아이템이 있다면 장착 해제
        {
            UnEquip(this.equip);
        }
        this.equip = equip;
        this.equip.isEquipped = true;
        AddStatus(this.equip);
    }

    public void UnEquip(EquipItemData equipItem)   // 아이템 장착 해제
    {
        if (equip != equipItem)
        {
            Debug.Log("아이템이 다릅니다");
            return;
        }
        equip.isEquipped = false;
        RemoveStatus(equip);
        equip = null;
    }

    public void AddStatus(EquipItemData equip)  // 스탯 추가
    {
        Attack += equip.Attack;
        Deffense += equip.Deffense;
        Health += equip.Health;
        Critical += equip.Critical;
    }

    public void RemoveStatus(EquipItemData equip)   // 스탯 감소
    {
        Attack -= equip.Attack;
        Deffense -= equip.Deffense;
        Health -= equip.Health;
        Critical -= equip.Critical;
    }
}
