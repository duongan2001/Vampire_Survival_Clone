using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    #region Stat variable
    [SerializeField] private int id;
    [SerializeField] private float hp;
    [SerializeField] private float dmg;
    [SerializeField] private float atkSpeed;
    [SerializeField] private float speed;
    [SerializeField] GameObject attackPref;
    #endregion

    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public float DMG
    {
        get
        {
            return dmg;
        }
        set
        {
            dmg = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public GameObject AttackPref
    {
        get
        {
            return attackPref;
        }
        set
        {
            attackPref = value;
        }
    }

    public float AS
    {
        get
        {
            return atkSpeed;
        }
        set
        {
            atkSpeed = value;
        }
    }

    public abstract void Attack();
}
