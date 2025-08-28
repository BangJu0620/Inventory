using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [Header("캐릭터")]
    [SerializeField] TextMeshProUGUI nickname;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] Image expFilled;
    //[SerializeField] Image title;

    [Header("버튼")]
    [SerializeField] Button statusButton;
    [SerializeField] Button inventoryButton;

    Player player;

    private void Awake()
    {
        //GetUI();
        player = GameManager.Instance.Player;

        statusButton.onClick.AddListener(OnClickStatus);
        inventoryButton.onClick.AddListener(OnClickInventory);
    }

    private void Start()
    {
        //player = GameManager.Instance.Player;

        //OpenUI();
    }

    void OnClickStatus()
    {
        UIManager.Instance.OpenStatus();
    }

    void OnClickInventory()
    {
        UIManager.Instance.OpenInventory();
    }

    public void UpdateMainMenu()
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
        expFilled.fillAmount = (float)player.CurExp / player.MaxExp;
        goldText.text = player.Gold.ToString("N0");
        // 칭호
    }

    public override void OpenUI()
    {
        UpdateMainMenu();

        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
    }

    public override void CloseUI()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    //public override void GetUI()
    //{
    //    UIManager.Instance.uiMainMenu = this;
    //}
}
