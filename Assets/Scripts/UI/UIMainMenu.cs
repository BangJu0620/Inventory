using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [Header("ĳ����")]
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] Image expFilled;
    //[SerializeField] Image title;

    [Header("��ư")]
    [SerializeField] Button statusButton;
    [SerializeField] Button inventoryButton;

    public override void CloseUI()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    public override void OpenUI()
    {
        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }

    protected override void Awake()
    {
        UIManager.Instance.UIMainMenu = this;
    }

    public void UpdateUI()
    {
        // ĳ���� ���� �������ֱ�
        // �̸�
        // ����
        // ����ġ
        // Īȣ
    }
}
