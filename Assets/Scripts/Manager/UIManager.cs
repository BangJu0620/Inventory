using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : SingletonMono<UIManager>
{
    public UIMainMenu uiMainMenu;
    public UIStatus uiStatus;
    public UIInventory uiInventory;

    // UIBase�� ���� �÷������� �����غ���
    // ����Ʈ�� ���� ��ųʸ��� ����
    // ��ųʸ��� Ű ���� �̸��� �ְ� �̸����� ã�ư��� ���� �� ���⵵ �ϰ�
    // �ƴϸ� enum���� Ÿ���� ���� Ÿ���� Ű ������ �ұ�
    // UI���� ������ �� �÷��ǿ� �����ؼ� �ڽ��� �߰��ϴ� �����ΰ�
    // �׷� �� ���� �÷��� ��ȸ�ϸ鼭 CloseUI �������ָ� �ɷ���
    // �ϳ��� �Ѿߵ� ���� ���� ���� �޼��带 �����ϰ� �ش� UI�� ���ָ�ǳ�?

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
