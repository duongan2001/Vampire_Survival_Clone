using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVaCham : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
