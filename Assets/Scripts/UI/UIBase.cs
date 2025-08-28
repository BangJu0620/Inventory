using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public abstract void OpenUI();

    public abstract void CloseUI();

    public abstract void GetUI();

    protected virtual void Awake()
    {
        // UIManager에 할당하기
    }
}