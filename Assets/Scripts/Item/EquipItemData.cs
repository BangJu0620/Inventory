using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip", menuName = "Item/New Equip")]
public class EquipItemData : ItemData
{
    [field: SerializeField] public float Attack { get; protected set; }

    [field: SerializeField] public float Deffense { get; protected set; }

    [field: SerializeField] public float Health { get; protected set; }

    [field: SerializeField] public float Critical { get; protected set; }

    public bool isEquipped;
}
