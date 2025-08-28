using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int maxValue;

    public int curValue;

    private void Awake()
    {
        curValue = maxValue;
    }

    public void AddStat(int amount)
    {
        maxValue += amount;
    }
}
