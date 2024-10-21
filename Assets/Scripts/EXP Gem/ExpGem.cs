using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGem : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] float exp;

    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public float EXP
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }
}
