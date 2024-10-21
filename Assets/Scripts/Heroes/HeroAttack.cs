using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroAttack : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerBehavior.aimDirectionVector;
        Rotate();
        Debug.Log(direction.x);
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

    public abstract void Attack();
}
