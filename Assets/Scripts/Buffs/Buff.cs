using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] private float dmg;

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
}
