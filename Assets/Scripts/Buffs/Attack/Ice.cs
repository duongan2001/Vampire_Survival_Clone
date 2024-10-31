using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Buff
{
    Vector2 direction;
    [SerializeField] float speed;
    [SerializeField] GameObject parent;
    Transform player;

    void Start()
    {
        DMG = BuffManager.buffManager.ReturnIceDmg();
        SetDirection();
        Rotate();
    }

    void Update()
    {
        float moveX = parent.transform.position.x + direction.x * speed * Time.deltaTime;
        float moveY = parent.transform.position.y + direction.y * speed * Time.deltaTime;
        parent.transform.position = new Vector3(moveX, moveY);
    }

    public void SetDirection()
    {
        GetIceDirection();
    }

    public void Rotate()
    {
        if (direction.x >= 0)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot +180);
        }
        else
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
            float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        }
    }

    public void GetIceDirection()
    {
        player = GameObject.FindWithTag("Player").GetComponentInParent<Transform>();
        float xDirect = transform.position.x - player.transform.position.x;
        float yDirect = transform.position.y - player.transform.position.y;
        direction = new Vector2(xDirect, yDirect).normalized;
        Debug.Log(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitAttack"))
        {
            Destroy(parent);
        }
    }
}
