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

    EquipItemData equip;    // ���� �����ϰ� �ִ� ������ ����
    // �������� ���� �����ϰ� �ҷ��� � ������ �����ؾ� ����?
    // ��� Ÿ�Ժ��� ������ Ÿ�Ժ��� �� ���� ���� �����ϰ� �ؾߵǳ�?
    // �����ۿ� �������� Ÿ������ ���� ��ó�� ������ �ɷ���
    // ��ű����� ������ ���� ������ ��������?
    // �÷������� ��Ƽ� �����ؾ� �ǳ�?

    [NonSerialized] public UIInventory inventory;

    public void GetItem(ItemData item)  // ������ ȹ��
    {
        inventory.AddItem(item);
    }

    public void Equip(EquipItemData equip)  // ������ ����
    {
        if (this.equip != null) // �̹� �����ϰ� �ִ� �������� �ִٸ� ���� ����
        {
            UnEquip(this.equip);
        }
        this.equip = equip;
        this.equip.isEquipped = true;
        AddStatus(this.equip);
    }

    public void UnEquip(EquipItemData equipItem)   // ������ ���� ����
    {
        if (equip != equipItem)
        {
            Debug.Log("�������� �ٸ��ϴ�");
            return;
        }
        equip.isEquipped = false;
        RemoveStatus(equip);
        equip = null;
    }

    public void AddStatus(EquipItemData equip)  // ���� �߰�
    {
        Attack += equip.Attack;
        Deffense += equip.Deffense;
        Health += equip.Health;
        Critical += equip.Critical;
    }

    public void RemoveStatus(EquipItemData equip)   // ���� ����
    {
        Attack -= equip.Attack;
        Deffense -= equip.Deffense;
        Health -= equip.Health;
        Critical -= equip.Critical;
    }
}
