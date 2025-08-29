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

    [SerializeField] Button button; // ������ ������ �� �ۿ��� ��ư
    [SerializeField] Image icon;    // ������ ������
    //[SerializeField] TextMeshProUGUI quatityText;   // �߰��� ���� �ִ� ������ ����
    [SerializeField] GameObject equipImage; // ���� ���� �̹���

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
