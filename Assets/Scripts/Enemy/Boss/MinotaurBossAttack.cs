using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBossAttack : BossAttack
{
    int skillID;
    float dmgSkill1, dmgSkill2;

    private void Start()
    {
        dmgSkill1 = GetComponentInParent<Enemy>().DMG * 1.2f;
        dmgSkill2 = GetComponentInParent<Enemy>().DMG * 1.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GetComponentInParent<Enemy>().skillCD_ing <= 0)
        {
            RandomSkill();
            SkillDamage();
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().skillCD_ing = GetComponentInParent<Enemy>().skillCD;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GetComponentInParent<Enemy>().skillCD_ing <= 0)
        {
            RandomSkill();
            SkillDamage();
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().skillCD_ing = GetComponentInParent<Enemy>().skillCD;
        }
    }

    public void RandomSkill()
    {
        skillID = (int)Random.Range(1, 2.99f);
        switch(skillID)
        {
            case 1:
                //Skill 1
                bossBody.GetComponent<Animator>().Play("Skill1Anim");
                bossBody.GetComponent<Animator>().SetBool("Attack", true);
                break;

            case 2:
                //Skill 2
                bossBody.GetComponent<Animator>().Play("Skill2Anim");
                bossBody.GetComponent<Animator>().SetBool("Attack", true);
                break;
        }    
    }

    public float SkillDamage()
    {
        //switch case
        switch (skillID)
        {
            case 1:
                //Skill 1
                dmg = dmgSkill1;
                break;

            case 2:
                //Skill 2
                dmg = dmgSkill2;
                break;
        }

        return dmg;
    }
}
