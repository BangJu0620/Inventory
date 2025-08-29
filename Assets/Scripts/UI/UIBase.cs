using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour    // �Ϲ����� UI�� ����� Base
{
    public abstract void OpenUI();  // UI ����

    public abstract void CloseUI(); // UI �ݱ�

    //public abstract void GetUI();   // UI �Ŵ����� ���� �Ҵ�
}