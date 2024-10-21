using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBossAttack : BossAttack
{
    float dmgSkill;

    private void Start()
    {
        dmgSkill = GetComponentInParent<Enemy>().DMG * 1.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GetComponentInParent<Enemy>().skillCD_ing <= 0)
        {
            bossBody.GetComponent<Animator>().SetBool("Attack", true);
            SkillDamage();
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().skillCD_ing = GetComponentInParent<Enemy>().skillCD;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GetComponentInParent<Enemy>().skillCD_ing <= 0)
        {
            bossBody.GetComponent<Animator>().SetBool("Attack", true);
            SkillDamage();
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().skillCD_ing = GetComponentInParent<Enemy>().skillCD;
        }
    }

    public float SkillDamage()
    {
        //switch case
        dmg = dmgSkill;

        return dmg;
    }
}
