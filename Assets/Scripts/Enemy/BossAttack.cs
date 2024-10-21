using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] protected Collider2D attackRange;
    [SerializeField] protected GameObject bossBody;
    protected float dmg;
    float speed;


    public float DMG
    {
        get
        {
            return dmg;
        }
        set
        {
            dmg = value;
        }
    }

    private void Start()
    {
        speed = GetComponentInParent<Enemy>().Speed;
        dmg = GetComponentInParent<Enemy>().DMG;
    }

    public void StopAttack()
    {
        bossBody.GetComponent<EnemyBody>().StopAttack();
    }
}
