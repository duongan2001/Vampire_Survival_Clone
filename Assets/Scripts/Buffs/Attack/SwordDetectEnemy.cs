using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDetectEnemy : MonoBehaviour
{
    public List<Transform> enemyList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (enemyList.Count == 5)
            {
                return;
            }
            Transform enemyPos = collision.gameObject.transform;
            enemyList.Add(enemyPos);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (enemyList.Count == 5)
            {
                return;
            }

            if (enemyList.Contains(collision.transform))
            {
                return;
            }
            else
            {
                enemyList.Add(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyList.Remove(collision.gameObject.transform);
        }     
    }
}
