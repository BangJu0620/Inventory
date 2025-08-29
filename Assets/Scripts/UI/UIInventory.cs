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

    [Header("������ ����")]
    [SerializeField] GameObject itemInfo;
    [SerializeField] Button equipButton;
    [SerializeField] Button unEquipButton;
    [SerializeField] Button closeInfoButton;    // ������ ���� �ݱ� ��ư
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemValue;
    [SerializeField] TextMeshProUGUI itemDescription;

    [Header("�κ��丮")]
    [SerializeField] TextMeshProUGUI itemCountText;
    [SerializeField] Button closeButton;

    ItemData selectedItem;

    Player player;

    private void Awake()
    {
        //Get UI();
        player = GameManager.Instance.Player;
        player.inventory = this;

        // ��ư �Ҵ�
        closeButton.onClick.AddListener(OnClickCloseButton);
        closeInfoButton.onClick.AddListener(OnClickCloseInfoButton);
        equipButton.onClick.AddListener(OnClickEquipButton);
        unEquipButton.onClick.AddListener(OnClickUnEquipButton);

        // ���� ����
        Init(); // Start�� ������ GameManager���� SetData�� ���� ����� �� ����
    }

    void OnClickCloseButton()  // �κ��丮 �ݱ� ��ư ������ ��
    {
        UIManager.Instance.CloseInventory();
    }

    void OnClickCloseInfoButton()   // ������ ����â �ݱ� ��ư ������ ��
    {
        CloseInfo();
    }

    void OnClickEquipButton()   // ������ ���� ��ư ������ ��
    {
        GameManager.Instance.Player.Equip(selectedItem as EquipItemData);
        UpdateUI();
    }

    void OnClickUnEquipButton() // ������ ���� ���� ��ư ������ ��
    {
        GameManager.Instance.Player.UnEquip();
        UpdateUI();
    }

    public override void CloseUI()  // �κ��丮 �ݱ�
    {
        selectedItem = null;
        gameObject.SetActive(false);
    }

    public override void OpenUI()   // �κ��丮 ����
    {
        gameObject.SetActive(true);
        UpdateUI();
        CloseInfo();
    }

    public void OpenInfo(ItemData item) // ������ ����â ����
    {
        if (item == null)   // ����ִ� ���� ������ ���ư���
        {
            CloseInfo();    // ������ ������ �ִ� ���Կ��� ����ִ� ������ ������ �� ����â ���ֱ�
            Debug.Log("������ ������ �����ϴ�.");
            return;
        }
        if (!itemInfo.activeSelf) itemInfo.SetActive(true); // ���������� ���ְ�, ���������� ������ �ٲ��ֱ�
        SetItem(item);
    }

    public void CloseInfo() // ����â �ݱ�
    {
        itemInfo.SetActive(false);
    }

    public void SetItem(ItemData item)  // ����â�� ������ ���� �����ϱ�
    {
        selectedItem = item;
        itemName.text = selectedItem.DisplayName;
        itemDescription.text = selectedItem.Description;
        if(selectedItem is EquipItemData)   // ��� �������� ��� ���� ǥ�����ֱ�, ���Ŀ� �Ҹ�ǰ � ���ָ� �ɵ�?
        {
            EquipItemData equip = selectedItem as EquipItemData;
            itemValue.text = $"���ݷ�\n{equip.Attack}\n����\n{equip.Deffense}\nü��\n{equip.Health}\nġ��Ÿ\n{equip.Critical}";
        }
        else    // �ƴϸ� �׳� ���� �ؽ�Ʈ ����
        {
            itemValue.text = string.Empty;
        }
    }

    public void AddItem(ItemData item)  // ������ �߰��ϱ� / ������ �׷� �� ���߿� �߰�
    {
        // ������ ���� �˻��ϰ� �߰��ϱ�
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

    void UpdateUI() // ������ ����, ������ ���� ����
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

    void Init() // ���� ����
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
