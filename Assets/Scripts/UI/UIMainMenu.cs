using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [Header("ĳ����")]
    [SerializeField] TextMeshProUGUI nickname;  // name���� �ϸ� ���ļ� nickname
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] Image expFilled;
    //[SerializeField] Image title;   // Īȣ? ���� �� �̹���

    [Header("��ư")]
    [SerializeField] Button statusButton;
    [SerializeField] Button inventoryButton;

    Player player;

    private void Awake()
    {
        //GetUI();
        player = GameManager.Instance.Player;

        // ��ư �Ҵ�
        statusButton.onClick.AddListener(OnClickStatus);
        inventoryButton.onClick.AddListener(OnClickInventory);
    }

    void OnClickStatus()    // Status ��ư ������ ��
    {
        UIManager.Instance.OpenStatus();
    }

    void OnClickInventory() // Inventory ��ư ������ ��
    {
        UIManager.Instance.OpenInventory();
    }

    public void UpdateMainMenu()    // ĳ���� ���� ����
    {
        if(player == null)
        {
            Debug.Log("�÷��̾� �����Ͱ� �����ϴ�.");
            return;
        }
        // ĳ���� ���� �������ֱ�
        nickname.text = player.Name;
        level.text = $"{player.Level}";
        expText.text = $"{player.CurExp} / {player.MaxExp}";
        expFilled.fillAmount = (float)player.CurExp / player.MaxExp;    // �� �� int ���̶� float���� �ϳ��� ��ȯ����� float���� ����
        goldText.text = player.Gold.ToString("N0"); // 3�ڸ� ���� , ����ֱ�
        // Īȣ�� ������ �ٲٱ�
    }

    public override void OpenUI()   // ���� �޴� ����
    {
        UpdateMainMenu();   // ����� �ٲ� ���� ��� OpenUI���� ����

        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }

    public override void CloseUI()  // ���� �޴� �ݱ�
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    //public override void GetUI()
    //{

    //}
}
