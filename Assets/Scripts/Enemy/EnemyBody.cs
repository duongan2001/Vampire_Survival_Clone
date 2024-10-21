using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    float speed;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        speed = GetComponentInParent<Enemy>().Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            animator.SetBool("TakeDamage", true);
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().HP -= player.GetComponent<Hero>().DMG;
            
            if (GetComponentInParent<Enemy>().HP <= 0)
            {
                animator.SetBool("IsDead", true);
            }              
        }

        if (collision.gameObject.CompareTag("Buff"))
        {
            animator.SetBool("TakeDamage", true);
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().HP -= collision.gameObject.GetComponentInParent<Buff>().DMG;

            if (GetComponentInParent<Enemy>().HP <= 0)
            {
                animator.SetBool("IsDead", true);
            }
        }
    }

    public void EndTakeDamage()
    {
        animator.SetBool("TakeDamage", false);
        GetComponentInParent<Enemy>().Speed = speed;
    }    

    public void DesTroy()
    {
        int expGemID = GameManager.gameManager.GetExpGemID();
        Instantiate(GameManager.gameManager.ExpGemPref[expGemID], GetComponentInParent<Transform>().position, Quaternion.identity);

        //DropHpItem();
        //Drop coin: Instantiate(GameManager.gameManager.coinDropItem, GetComponentInParent<Transform>().position, Quaternion.identity);
        //EnemySpawnManager.enemySpawnManager.CurrentEnemySpawnNumber -= 1;
        Destroy(parent);
    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
        GetComponentInParent<Enemy>().Speed = speed;
    }

    public void DropHpItem()
    {
        float randomHpDrop = Random.Range(1, 101);
        if (randomHpDrop <= BuffManager.buffManager.ReturnHPDropPercentValue())
        {
            Instantiate(GameManager.gameManager.hpDropItem, GetComponentInParent<Transform>().position, Quaternion.identity);
        }
    }
}
