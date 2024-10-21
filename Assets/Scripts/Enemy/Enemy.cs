using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Stat variable
    [SerializeField] private int id;
    [SerializeField] private float hp;
    [SerializeField] private float dmg;
    [SerializeField] private float speed;
    #endregion

    public float damageCD_ing = 0;
    public float skillDamageCD_ing = 0;
    public float skillCD;
    public float skillCD_ing;

    [SerializeField] GameObject player;
    int facing;
    float scaleX;

    private void Start()
    {
        skillCD_ing = 0;
        scaleX = transform.localScale.x;
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        Facing();
        FindingPlayer();
        damageCD_ing -= Time.deltaTime;
        skillDamageCD_ing -= Time.deltaTime;
        skillCD_ing -= Time.deltaTime;
    }

    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

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

    public void FindingPlayer()
    {
        /*float directionX = player.transform.position.x - transform.position.x;
        float directionY = player.transform.position.y - transform.position.y;
        Vector3 direction = new Vector3(directionX, directionY).normalized;
        float moveX = transform.position.x + direction.x * speed * Time.deltaTime;
        float moveY = transform.position.y + direction.y * speed * Time.deltaTime;
        transform.position = new Vector3(moveX, moveY);*/

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed * Time.deltaTime);
    }

    public void Facing()
    {
        float distanceX = Mathf.Abs(player.transform.position.x - this.transform.position.x);

        if (transform.position.x < player.transform.position.x && distanceX >= 0.05f)
        {
            facing = 1;
        }
        else if (transform.position.x > player.transform.position.x && distanceX >= 0.05f)
        {
            facing = -1;
        }
        transform.localScale = new Vector3(scaleX * facing, transform.localScale.y, transform.localScale.z);
    }
}
