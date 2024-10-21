using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Buff
{
    Transform player;
    Vector2 direction;
    [SerializeField] Vector2 turnBackPos;
    [SerializeField] Vector2 endPos;
    [SerializeField] GameObject parent;
    [SerializeField] float speed;
    bool isTurnBack;

    void Awake()
    {      
        player = GameObject.FindWithTag("Player").GetComponentInParent<Transform>();
        SetPosition();
        DMG = BuffManager.buffManager.ReturnAxeDmg();
        isTurnBack = false;
    }

    void FixedUpdate()
    {
        Forward();
        TurnBack();
    }

    public void Forward()
    {
        if (!isTurnBack)
        {
            transform.Rotate(0, 0, -15f);

            transform.position = Vector3.MoveTowards(transform.position, turnBackPos, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, turnBackPos) <= 0.05f)
            {
                isTurnBack = true;
            }
        }
    }

    public void TurnBack()
    {
        if (isTurnBack)
        {
            transform.Rotate(0, 0, 15f);
            endPos = player.GetComponentInParent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, endPos) <= 0.05f)
            {
                Destroy(parent);
            }
        }
    }

    public void SetPosition()
    {
        direction = PlayerBehavior.aimDirectionVector;
        if (BuffManager.axeLevel >= 3)
        {
            if (BuffManager.numberofAxe == 0)
            {
                endPos = Vector3.zero;
                turnBackPos.x = player.GetComponentInParent<Transform>().position.x + direction.normalized.x * 4;
                turnBackPos.y = player.GetComponentInParent<Transform>().position.y + direction.normalized.y * 4;
                Debug.Log("1_x: " + turnBackPos.x + "/y: " + turnBackPos.y);

                BuffManager.numberofAxe++;
            }
            else if (BuffManager.numberofAxe == 1)
            {
                endPos = Vector3.zero;
                turnBackPos.x = player.GetComponentInParent<Transform>().position.x - direction.normalized.x * 4;
                turnBackPos.y = player.GetComponentInParent<Transform>().position.y - direction.normalized.y * 4;
                Debug.Log("2_x: " + turnBackPos.x + "/y: " + turnBackPos.y);
                BuffManager.numberofAxe = 0;
            }
        }
        else
        {
            endPos = Vector3.zero;
            turnBackPos = direction.normalized * 4;            
        }        
    }
}
