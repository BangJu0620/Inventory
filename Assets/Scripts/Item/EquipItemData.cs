using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip", menuName = "Item/New Equip")]
public class EquipItemData : ItemData   // 장비 가능 아이템
{
    // Stat이라는 클래스를 따로 만들어서 현재 수치, 최대 수치 감소 로직등을 만들면 좋을 것 같은데
    // 그 스탯들을 모아서 컬렉션으로 만들면 관리하기 편할려나
    // 딕셔너리로 만들어서 해당 스탯에 접근하기 편하게 만드는 게 좋나?

    [field: SerializeField] public float Attack { get; protected set; }

    [field: SerializeField] public float Deffense { get; protected set; }

    [field: SerializeField] public float Health { get; protected set; }

    [field: SerializeField] public float Critical { get; protected set; }

    public bool isEquipped; // 장착 했는지 확인용 bool 값
}
