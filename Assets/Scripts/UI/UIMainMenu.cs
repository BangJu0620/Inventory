using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [Header("캐릭터")]
    [SerializeField] TextMeshProUGUI nickname;  // name으로 하면 겹쳐서 nickname
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] Image expFilled;
    //[SerializeField] Image title;   // 칭호? 같은 거 이미지

    [Header("버튼")]
    [SerializeField] Button statusButton;
    [SerializeField] Button inventoryButton;

    Player player;

    private void Awake()
    {
        //GetUI();
        player = GameManager.Instance.Player;

        // 버튼 할당
        statusButton.onClick.AddListener(OnClickStatus);
        inventoryButton.onClick.AddListener(OnClickInventory);
    }

    void OnClickStatus()    // Status 버튼 눌렀을 때
    {
        UIManager.Instance.OpenStatus();
    }

    void OnClickInventory() // Inventory 버튼 눌렀을 때
    {
        UIManager.Instance.OpenInventory();
    }

    public void UpdateMainMenu()    // 캐릭터 정보 갱신
    {
        if(player == null)
        {
            Debug.Log("플레이어 데이터가 없습니다.");
            return;
        }
        // 캐릭터 정보 갱신해주기
        nickname.text = player.Name;
        level.text = $"{player.Level}";
        expText.text = $"{player.CurExp} / {player.MaxExp}";
        expFilled.fillAmount = (float)player.CurExp / player.MaxExp;    // 둘 다 int 값이라 float으로 하나는 변환해줘야 float값이 나옴
        goldText.text = player.Gold.ToString("N0"); // 3자리 마다 , 찍어주기
        // 칭호도 있으면 바꾸기
    }

    public override void OpenUI()   // 메인 메뉴 열기
    {
        UpdateMainMenu();   // 현재는 바뀔 일이 없어서 OpenUI에서 실행

        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }

    public override void CloseUI()  // 메인 메뉴 닫기
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    //public override void GetUI()
    //{

    //}
}
