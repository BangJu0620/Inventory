using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
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

    public void CloseUI()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
    }

    public void OpenUI()
    {
        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
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
