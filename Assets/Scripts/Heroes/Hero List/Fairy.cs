using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : Hero
{
    #region Attack Method Variable
    GameObject atkPref;
    float attackCD;
    float attackCD_ing;
    [SerializeField] private Transform atkPos;
    int atkSpawnNumber;
    #endregion

    private void Start()
    {
        atkPos = GameObject.FindWithTag("AttackPos").transform;
        attackCD = 1 / gameObject.GetComponent<Hero>().AS;
        attackCD_ing = attackCD;
        atkPref = GetComponent<Hero>().AttackPref;
        atkSpawnNumber = 0;
    }

    private void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        attackCD_ing -= Time.deltaTime;
        if (attackCD_ing <= 0)
        {
            switch(PlayerBehavior.attackLevel)
            {
                case 1:
                    Instantiate(atkPref, new Vector3(atkPos.position.x, atkPos.position.y), Quaternion.identity);
                    attackCD_ing = attackCD;
                    break;
                case 2:
                    Instantiate(atkPref, new Vector3(atkPos.position.x, atkPos.position.y), Quaternion.identity);
                    attackCD_ing = attackCD;
                    break;
                case 3:
                    if (atkSpawnNumber < 2)
                    {
                        Instantiate(atkPref, new Vector3(atkPos.position.x, atkPos.position.y), Quaternion.identity);
                        attackCD_ing = 0.2f;
                        atkSpawnNumber++;
                    }
                    else
                    {
                        attackCD_ing = attackCD;
                        atkSpawnNumber = 0;
                    }    
                    break;
                case 4:
                    if (atkSpawnNumber < 2)
                    {
                        Instantiate(atkPref, new Vector3(atkPos.position.x, atkPos.position.y), Quaternion.identity);
                        attackCD_ing = 0.2f;
                        atkSpawnNumber++;
                    }
                    else
                    {
                        attackCD_ing = attackCD;
                        atkSpawnNumber = 0;
                    }
                    break;
                case 5:
                    if (atkSpawnNumber < 3)
                    {
                        Instantiate(atkPref, new Vector3(atkPos.position.x, atkPos.position.y), Quaternion.identity);
                        attackCD_ing = 0.2f;
                        atkSpawnNumber++;
                    }
                    else
                    {
                        attackCD_ing = attackCD;
                        atkSpawnNumber = 0;
                    }
                    break;
                case 6:
                    if (atkSpawnNumber < 3)
                    {
                        Instantiate(atkPref, new Vector3(atkPos.position.x, atkPos.position.y), Quaternion.identity);
                        attackCD_ing = 0.2f;
                        atkSpawnNumber++;
                    }
                    else
                    {
                        attackCD_ing = attackCD;
                        atkSpawnNumber = 0;
                    }
                    break;
            }
        }
    }
}
