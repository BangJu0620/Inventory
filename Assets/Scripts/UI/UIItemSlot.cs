using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    [NonSerialized] public UIInventory inventory;

    [SerializeField] ItemData item;
    public ItemData Item { get { return item; } set { item = value; } }

    [SerializeField] Button button; // 슬롯을 눌렀을 때 작용할 버튼
    [SerializeField] Image icon;    // 아이템 아이콘
    //[SerializeField] TextMeshProUGUI quatityText;   // 추가될 수도 있는 아이템 개수
    [SerializeField] GameObject equipImage; // 장착 여부 이미지

    //int quantity;
    //public int Quantity {  get { return quantity; } set { quantity = value; } }

    private void Awake()
    {
        button.onClick.AddListener(OnClickButton);
    }

    public void Init(UIInventory inventory)
    {
        this.inventory = inventory;
    }

    public void OnClickButton()
    {
        inventory.OpenInfo(item);
    }

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.Icon;
        if(item is EquipItemData)
        {
            EquipItemData equip = item as EquipItemData;
            equipImage.SetActive(equip.isEquipped);
        }
        //quatityText.text = quantity > 1 ? quantity.ToString() : string.Empty;
    }

    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        //quatityText.text = string.Empty;
        equipImage.SetActive(false);
    }
}
