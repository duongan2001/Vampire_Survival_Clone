using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Buff
{   
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    GameObject detectEnemyGameObject;
    Vector2 enemyPos;

    private void Awake()
    {
        Debug.Log("Current sword: " + (BuffManager.buffManager.currentSwordNumber));
        detectEnemyGameObject = GameObject.FindWithTag("Detect Enemy Area");
        enemyPos = detectEnemyGameObject.GetComponent<SwordDetectEnemy>().enemyList[BuffManager.buffManager.currentSwordNumber].GetComponentInParent<Transform>().position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyPos, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, enemyPos) <= 0.05f)
        {
            animator.SetBool("Destroy", true);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
