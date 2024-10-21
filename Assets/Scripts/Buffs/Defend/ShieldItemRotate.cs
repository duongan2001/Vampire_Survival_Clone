using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItemRotate : MonoBehaviour
{
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(0, 0, 0.4f);
    }
}
