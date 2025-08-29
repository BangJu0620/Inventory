using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIBase
{
    [SerializeField] Button closeButton;

    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI deffenseText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI criticalText;

    Player player;

    private void Awake()
    {
        player = GameManager.Instance.Player;

        // ��ư �Ҵ�
        closeButton.onClick.AddListener(OnClickCloseButton);
    }

    public void OnClickCloseButton()    // �ݱ� ��ư ������ ��
    {
        UIManager.Instance.CloseStatus();
    }

    public void UpdateStatus()  // ���� �������ֱ�
    {
        if (player == null) // ���ٸ� ����
        {
            Debug.Log("�÷��̾� �����Ͱ� �����ϴ�.");
            return; 
        }
        // ĳ���� ���� �������ֱ�
        attackText.text = $"���ݷ�\n{player.Attack}";
        deffenseText.text = $"����\n{player.Deffense}";
        healthText.text = $"ü��\n{player.Health}";
        criticalText.text = $"ġ��Ÿ\n{player.Critical}";
    }

    public override void OpenUI()   // ����â ����
    {
        UpdateStatus(); // ������ ����â ���� �ٲ�� ������ ������ ����
        gameObject.SetActive(true);
    }

    public override void CloseUI()  // ����â �ݱ�
    {
        gameObject.SetActive(false);
    }
}
