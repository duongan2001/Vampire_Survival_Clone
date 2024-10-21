using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Buff
{
    Vector2 direction;
    [SerializeField] float speed;
    Transform player;

    void Start()
    {
        SetDirection();
        Rotate();
    }

    void Update()
    {
        float moveX = transform.position.x + direction.x * speed * Time.deltaTime;
        float moveY = transform.position.y + direction.y * speed * Time.deltaTime;
        transform.position = new Vector3(moveX, moveY);
    }

    public void SetDirection()
    {
        GetArrowDirection();
    }

    public void Rotate()
    {
        if (direction.x >= 0)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 135);
        }
        else
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 135 + 90);
        }
    }

    public void GetArrowDirection()
    {
        player = GameObject.FindWithTag("Player").GetComponentInParent<Transform>();
        float xDirect = transform.position.x - player.transform.position.x;
        float yDirect = transform.position.y - player.transform.position.y;
        direction = new Vector2(xDirect, yDirect).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LimitAttack"))
        {
            Destroy(gameObject);
        }
    }
}
