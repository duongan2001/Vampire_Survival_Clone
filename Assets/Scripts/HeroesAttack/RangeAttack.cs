using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerBehavior.aimDirectionVector;
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = transform.position.x + direction.x * speed * Time.deltaTime;
        float moveY = transform.position.y + direction.y * speed * Time.deltaTime;
        transform.position = new Vector3(moveX, moveY);
    }

    public void Rotate()
    {
        if (direction.x >= 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        }
        else
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (PlayerBehavior.attackLevel <= 3)
            {
                Destroy(gameObject);
            }         
        }

        if (collision.gameObject.CompareTag("LimitAttack"))
        {
            Destroy(gameObject);
        }
    }
}
