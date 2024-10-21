using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBody : MonoBehaviour
{
    [SerializeField]Hero hero;

    private void Start()
    {
        //hero = gameObject.GetComponentInParent<Hero>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponentInParent<Enemy>().damageCD_ing <= 0)
            {
                GameManager.gameManager.HeroTakeDamage(collision.gameObject.GetComponentInParent<Enemy>().DMG);
                collision.gameObject.GetComponentInParent<Enemy>().damageCD_ing = 2;
            }
        }

        if (collision.gameObject.CompareTag("BossAttack"))
        {
            if (collision.gameObject.GetComponentInParent<Enemy>().skillDamageCD_ing <= 0)
            {
                GameManager.gameManager.HeroTakeDamage(collision.gameObject.GetComponentInParent<Enemy>().GetComponentInChildren<BossAttack>().DMG);
                collision.gameObject.GetComponentInParent<Enemy>().skillDamageCD_ing = collision.gameObject.GetComponentInParent<Enemy>().skillCD;
            }
        }

        if (collision.gameObject.CompareTag("EXPGem"))
        {
            GameManager.gameManager.CurrentEXP += collision.gameObject.GetComponent<ExpGem>().EXP;
            Destroy(collision.gameObject);

            if (GameManager.gameManager.CurrentEXP >= GameManager.gameManager.MaxEXP)
            {
                GameManager.gameManager.CurrentEXP -= GameManager.gameManager.MaxEXP;
                GameManager.gameManager.MaxEXP += GameManager.gameManager.MaxEXP * 0.5f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponentInParent<Enemy>().damageCD_ing <= 0)
            {
                GameManager.gameManager.HeroTakeDamage(collision.gameObject.GetComponentInParent<Enemy>().DMG);
                collision.gameObject.GetComponentInParent<Enemy>().damageCD_ing = 2;
            }
        }

        if (collision.gameObject.CompareTag("BossAttack"))
        {
            if (collision.gameObject.GetComponentInParent<Enemy>().skillCD_ing <= 0)
            {
                GameManager.gameManager.HeroTakeDamage(collision.gameObject.GetComponentInParent<Enemy>().GetComponentInChildren<BossAttack>().DMG);
            }

        }
    }
}
