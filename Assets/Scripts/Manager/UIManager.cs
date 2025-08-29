using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>
{
    public UIMainMenu uiMainMenu;
    public UIStatus uiStatus;
    public UIInventory uiInventory;

    // UIBase를 모은 컬렉션으로 관리해보기
    // 리스트가 좋나 딕셔너리가 좋나
    // 딕셔너리의 키 값에 이름을 넣고 이름으로 찾아가면 좋을 거 같기도 하고
    // 아니면 enum으로 타입을 만들어서 타입을 키 값으로 할까
    // UI들이 생성될 때 컬렉션에 접근해서 자신을 추가하는 느낌인가
    // 그럼 다 끌때 컬렉션 순회하면서 CloseUI 실행해주면 될려나
    // 하나만 켜야될 때는 위에 끄는 메서드를 실행하고 해당 UI만 켜주면되나?

    private void Start()
    {
        uiMainMenu.OpenUI();
        uiStatus.CloseUI();
        uiInventory.CloseUI();
    }

    public void OpenStatus()
    {
        uiMainMenu.CloseUI();
        uiStatus.OpenUI();
    }

    public void CloseStatus()
    {
        uiMainMenu.OpenUI();
        uiStatus.CloseUI();
    }

    public void OpenInventory()
    {
        uiMainMenu.CloseUI();
        uiInventory.OpenUI();
    }

    public void CloseInventory()
    {
        uiMainMenu.OpenUI();
        uiInventory.CloseUI();
    }
}
