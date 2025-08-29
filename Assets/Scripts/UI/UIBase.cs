using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour    // 일반적인 UI에 상속할 Base
{
    public abstract void OpenUI();  // UI 열기

    public abstract void CloseUI(); // UI 닫기

    //public abstract void GetUI();   // UI 매니저에 동적 할당
}