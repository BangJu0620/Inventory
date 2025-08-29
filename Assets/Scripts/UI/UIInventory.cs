using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : UIBase
{
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Transform slotTransform;

    List<UIItemSlot> slots = new List<UIItemSlot>();
    public List<UIItemSlot> Slots { get { return slots; } set { slots = value; } }

    [SerializeField] int slotCount;
    int curItemCount;

    [SerializeField] GameObject itemInfo;
    [SerializeField] Button equipButton;
    [SerializeField] Button unEquipButton;
    [SerializeField] Button closeButton;    // 아이템 정보 닫기 버튼
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemValue;
    [SerializeField] TextMeshProUGUI itemDescription;

    [SerializeField] TextMeshProUGUI itemCountText;
    [SerializeField] Button returnButton;

    ItemData selectedItem;

    Player player;

    private void Awake()
    {
        player = GameManager.Instance.Player;
        player.inventory = this;

        returnButton.onClick.AddListener(OnClickReturnButton);
        closeButton.onClick.AddListener(OnClickCloseButton);
        equipButton.onClick.AddListener(OnClickEquipButton);
        unEquipButton.onClick.AddListener(OnClickUnEquipButton);
    }

    private void Start()
    {
        Init();
        UpdateUI();
    }

    void OnClickReturnButton()
    {
        UIManager.Instance.CloseInventory();
    }

    void OnClickCloseButton()
    {
        CloseInfo();
    }

    void OnClickEquipButton()
    {
        GameManager.Instance.Player.Equip(selectedItem as EquipItemData);
        UpdateUI();
    }

    void OnClickUnEquipButton()
    {
        GameManager.Instance.Player.UnEquip();
        UpdateUI();
    }

    public override void CloseUI()
    {
        selectedItem = null;
        gameObject.SetActive(false);
    }

    public override void OpenUI()
    {
        gameObject.SetActive(true);
        UpdateUI();
        CloseInfo();
    }

    public void OpenInfo(ItemData item)
    {
        if (item == null)
        {
            CloseInfo();
            Debug.Log("아이템 정보가 없습니다.");
            return;
        }
        if (!itemInfo.activeSelf) itemInfo.SetActive(true);
        SetItem(item);
    }

    public void CloseInfo()
    {
        itemInfo.SetActive(false);
    }

    public void SetItem(ItemData item)
    {
        selectedItem = item;
        itemName.text = selectedItem.DisplayName;
        itemDescription.text = selectedItem.Description;
        if(selectedItem is EquipItemData)
        {
            EquipItemData equip = selectedItem as EquipItemData;
            itemValue.text = $"공격력\n{equip.Attack}\n방어력\n{equip.Deffense}\n체력\n{equip.Health}\n치명타\n{equip.Critical}";
        }
        else
        {
            itemValue.text = string.Empty;
        }
    }

    public void AddItem(ItemData item)  // 개수랑 그런 건 나중에 추가
    {
        // 아이템 슬롯 검사하고 추가하기
        foreach(var slot in slots)
        {
            if(slot.Item == null)
            {
                slot.Item = item;
                break;
            }
        }
        //UpdateUI();
    }

    void UpdateUI()
    {
        curItemCount = 0;
        foreach(var slot in slots)
        {
            if(slot.Item != null)
            {
                curItemCount++;
                slot.Set();
            }
            else
            {
                slot.Clear();
            }
        }

        itemCountText.text = $"<color=orange>{curItemCount}<color=grey> / {slotCount}</color>";
    }

    void Init()
    {
        for(int i = 0; i < slotCount; i++)
        {
            GameObject GO = Instantiate(slotPrefab, slotTransform);
            if(GO.GetComponent<UIItemSlot>() == null)
            {
                Debug.Log("Null");
            }
            slots.Add(GO.GetComponent<UIItemSlot>());
            slots[i].Init(this, i);
        }
    }
}
