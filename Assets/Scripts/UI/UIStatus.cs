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

        // 버튼 할당
        closeButton.onClick.AddListener(OnClickCloseButton);
    }

    public void OnClickCloseButton()    // 닫기 버튼 눌렀을 때
    {
        UIManager.Instance.CloseStatus();
    }

    public void UpdateStatus()  // 스탯 갱신해주기
    {
        if (player == null) // 없다면 실행
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

    public override void OpenUI()   // 스탯창 열기
    {
        UpdateStatus(); // 어차피 스탯창 열면 바뀔게 없으니 열때만 갱신
        gameObject.SetActive(true);
    }

    public override void CloseUI()  // 스탯창 닫기
    {
        gameObject.SetActive(false);
    }
}
