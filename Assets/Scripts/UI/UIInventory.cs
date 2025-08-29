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
    //public List<UIItemSlot> Slots { get { return slots; } set { slots = value; } }

    [SerializeField] int slotCount;
    int curItemCount;

    [Header("아이템 정보")]
    [SerializeField] GameObject itemInfo;
    [SerializeField] Button equipButton;
    [SerializeField] Button unEquipButton;
    [SerializeField] Button closeInfoButton;    // 아이템 정보 닫기 버튼
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemValue;
    [SerializeField] TextMeshProUGUI itemDescription;

    [Header("인벤토리")]
    [SerializeField] TextMeshProUGUI itemCountText;
    [SerializeField] Button closeButton;

    ItemData selectedItem;

    Player player;

    private void Awake()
    {
        //Get UI();
        player = GameManager.Instance.Player;
        player.inventory = this;

        // 버튼 할당
        closeButton.onClick.AddListener(OnClickCloseButton);
        closeInfoButton.onClick.AddListener(OnClickCloseInfoButton);
        equipButton.onClick.AddListener(OnClickEquipButton);
        unEquipButton.onClick.AddListener(OnClickUnEquipButton);

        // 슬롯 생성
        Init(); // Start에 넣으면 GameManager에서 SetData가 먼저 실행될 수 있음
    }

    void OnClickCloseButton()  // 인벤토리 닫기 버튼 눌렀을 때
    {
        UIManager.Instance.CloseInventory();
    }

    void OnClickCloseInfoButton()   // 아이템 정보창 닫기 버튼 눌렀을 때
    {
        CloseInfo();
    }

    void OnClickEquipButton()   // 아이템 장착 버튼 눌렀을 때
    {
        GameManager.Instance.Player.Equip(selectedItem as EquipItemData);
        UpdateUI();
    }

    void OnClickUnEquipButton() // 아이템 장착 해제 버튼 눌렀을 때
    {
        GameManager.Instance.Player.UnEquip();
        UpdateUI();
    }

    public override void CloseUI()  // 인벤토리 닫기
    {
        selectedItem = null;
        gameObject.SetActive(false);
    }

    public override void OpenUI()   // 인벤토리 열기
    {
        gameObject.SetActive(true);
        UpdateUI();
        CloseInfo();
    }

    public void OpenInfo(ItemData item) // 아이템 정보창 열기
    {
        if (item == null)   // 비어있는 슬롯 누르면 돌아가기
        {
            CloseInfo();    // 아이템 정보가 있는 슬롯에서 비어있는 슬롯을 눌렀을 때 정보창 꺼주기
            Debug.Log("아이템 정보가 없습니다.");
            return;
        }
        if (!itemInfo.activeSelf) itemInfo.SetActive(true); // 꺼져있으면 켜주고, 켜져있으면 정보만 바꿔주기
        SetItem(item);
    }

    public void CloseInfo() // 정보창 닫기
    {
        itemInfo.SetActive(false);
    }

    public void SetItem(ItemData item)  // 정보창에 아이템 정보 세팅하기
    {
        selectedItem = item;
        itemName.text = selectedItem.DisplayName;
        itemDescription.text = selectedItem.Description;
        if(selectedItem is EquipItemData)   // 장비 아이템일 경우 스탯 표시해주기, 추후에 소모품 등도 해주면 될듯?
        {
            EquipItemData equip = selectedItem as EquipItemData;
            itemValue.text = $"공격력\n{equip.Attack}\n방어력\n{equip.Deffense}\n체력\n{equip.Health}\n치명타\n{equip.Critical}";
        }
        else    // 아니면 그냥 스탯 텍스트 비우기
        {
            itemValue.text = string.Empty;
        }
    }

    public void AddItem(ItemData item)  // 아이템 추가하기 / 개수랑 그런 건 나중에 추가
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

    void UpdateUI() // 아이템 슬롯, 아이템 개수 갱신
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

    void Init() // 슬롯 생성
    {
        for(int i = 0; i < slotCount; i++)
        {
            GameObject GO = Instantiate(slotPrefab, slotTransform);
            if(GO.GetComponent<UIItemSlot>() == null)
            {
                Debug.Log("Null");
            }
            slots.Add(GO.GetComponent<UIItemSlot>());
            slots[i].Init(this);
        }
    }
}
