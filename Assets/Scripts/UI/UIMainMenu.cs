using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [Header("캐릭터")]
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] Image expFilled;
    //[SerializeField] Image title;

    [Header("버튼")]
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
        // 캐릭터 정보 갱신해주기
        // 이름
        // 레벨
        // 경험치
        // 칭호
    }
}
