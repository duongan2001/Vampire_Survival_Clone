using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringerBossAttack : BossAttack
{
    int skillID;
    float dmgSkill1, dmgSkill2;
    bool skill2;
    [SerializeField]GameObject skill2Pref;
    Transform playerPos;

    private void Start()
    {
        dmgSkill1 = GetComponentInParent<Enemy>().DMG * 1.2f;
        dmgSkill2 = GetComponentInParent<Enemy>().DMG * 1.5f;
        playerPos = GameObject.FindWithTag("Player").GetComponentInParent<Transform>();
        skill2 = true;
    }

    private void Update()
    {
        if (GetComponentInParent<Enemy>().skillCD_ing <= 0 && skill2)
        {
            Skill2();
            SkillDamage();
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().skillCD_ing = GetComponentInParent<Enemy>().skillCD;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponentInParent<Enemy>().skillCD_ing <= 0 && collision.gameObject.CompareTag("Player"))
        {
            skill2 = false;
            Skill1();
            SkillDamage();
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().skillCD_ing = GetComponentInParent<Enemy>().skillCD;
            skill2 = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GetComponentInParent<Enemy>().skillCD_ing <= 0 && collision.gameObject.CompareTag("Player"))
        {
            skill2 = false;
            Skill1();
            SkillDamage();
            GetComponentInParent<Enemy>().Speed = 0;
            GetComponentInParent<Enemy>().skillCD_ing = GetComponentInParent<Enemy>().skillCD;
            skill2 = true;
        }
    }

    public void Skill1()
    {
        skillID = 1;
        bossBody.GetComponent<Animator>().Play("Skill1Anim");
        bossBody.GetComponent<Animator>().SetBool("Attack", true);
    }

    public void Skill2()
    {
        skillID = 2;
        bossBody.GetComponent<Animator>().Play("Skill2Anim");
        bossBody.GetComponent<Animator>().SetBool("Attack", true);

        GameObject skill2 = Instantiate(skill2Pref, new Vector2(playerPos.position.x + 0.1f, playerPos.position.y + 0.3f), Quaternion.identity);
        skill2.transform.parent = bossBody.transform;
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
