using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [field:SerializeField] public float Attack { get; protected set; }

    [field:SerializeField] public float Deffense { get; protected set; }

    [field:SerializeField] public float Health { get; protected set; }

    public float curHealth { get; protected set; }
    public float maxHealth { get; protected set; }

    [field:SerializeField] public float Critical { get; protected set; }

    [field:SerializeField] public string Name { get; protected set; }

    //public virtual void Init()
    //{
    //    maxHealth = Health;
    //    curHealth = Health;
    //}

    //public Character(int attack, int deffense, int health, int critical, int gold, int level, int maxExp, int curExp, string name)
    //{
    //    Attack.maxValue = attack;
    //    Deffense.maxValue = deffense;
    //    Health.maxValue = health;
    //    Critical.maxValue = critical;
    //    Gold = gold;
    //    Level = level;
    //    MaxExp = maxExp;
    //    CurExp = curExp;
    //    Name = name;
    //}
}
