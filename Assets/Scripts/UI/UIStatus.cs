using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : UIBase
{
    [SerializeField] Button returnButton;

    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI deffenseText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI criticalText;

    Character player;

    private void Awake()
    {
        player = GameManager.Instance.Player;

        returnButton.onClick.AddListener(OnClickCloseButton);
    }

    private void Start()
    {
        //player = GameManager.Instance.Player;

        //returnButton.onClick.AddListener(OnClickCloseButton);
    }

    //public void OpenStatus()
    //{
    //    UpdateStatus();
    //    gameObject.SetActive(true);
    //}

    //public void CloseStatus()
    //{
    //    gameObject.SetActive(false);
    //}

    public void OnClickCloseButton()
    {
        UIManager.Instance.CloseStatus();
    }

    public void UpdateStatus()
    {
        if (player == null)
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

    public override void OpenUI()
    {
        UpdateStatus();
        gameObject.SetActive(true);
    }

    public override void CloseUI()
    {
        gameObject.SetActive(false);
    }

    public override void GetUI()
    {
        UIManager.Instance.uiStatus = this;
    }
}
