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
            Debug.Log("플레이어 데이터가 없습니다.");
            return; 
        }
        // 캐릭터 정보 갱신해주기
        attackText.text = $"공격력\n{player.Attack}";
        deffenseText.text = $"방어력\n{player.Deffense}";
        healthText.text = $"체력\n{player.Health}";
        criticalText.text = $"치명타\n{player.Critical}";
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
