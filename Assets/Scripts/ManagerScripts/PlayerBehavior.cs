using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Joystick attackDirectionJoystick;
    public static int attackLevel;

    #region Move Method Variable
    [SerializeField] private float speed;
    Vector2 moveDirect;
    #endregion

    #region Dash Method Variable
    [SerializeField] private float dashCD = 2;
    private float dashCD_ing;
    private float dashTime = 0.2f;
    private float dashTimeRemaining;
    #endregion

    #region Aim Method Variable
    [SerializeField] private Transform atkPos;
    public static Vector2 aimDirectionVector;
    [SerializeField] Vector2 aimDirect;
    #endregion

    #region Facing Method Variable
    int facing;
    #endregion

    #region Spawn Hero
    [SerializeField]GameObject heroPref;
    GameObject hero;
    #endregion

    float currentDMG; 

    private void Awake()
    {
        hero = Instantiate(heroPref, transform.position, Quaternion.identity);
        hero.transform.parent = transform;

        atkPos.transform.position = new Vector2(0.75f, 0);
        aimDirectionVector = new Vector2(1, 0).normalized * 0.75f;
        speed = GetComponentInChildren<Hero>().Speed;
        dashCD_ing = dashCD;
        dashTimeRemaining = dashTime;
        facing = 1;
        currentDMG = hero.GetComponent<Hero>().DMG;
        attackLevel = 1;

        Debug.Log(attackLevel);
    }

    void Update()
    {
        DashSpeedControl();
        Dash();
        Facing();
        Move();
        Aim();
    }

    public void Move()
    {
        moveDirect = new Vector2(joystick.Direction.x, joystick.Direction.y).normalized;

        float moveX = transform.position.x + moveDirect.x * speed * Time.deltaTime;
        float moveY = transform.position.y + moveDirect.y * speed * Time.deltaTime;
        transform.position = new Vector3(moveX, moveY);

        Transform heroBody = GetComponentInChildren<HeroBody>().transform;
        heroBody.transform.position = transform.position;
    }

    public void Aim()
    {
        aimDirect = new Vector2(attackDirectionJoystick.Direction.x, attackDirectionJoystick.Direction.y).normalized;

        if (aimDirect.x != 0 || aimDirect.y != 0)
        {
            float aimX = transform.position.x + aimDirect.normalized.x * 0.75f;
            float aimY = transform.position.y + aimDirect.normalized.y * 0.75f;
            atkPos.transform.position = new Vector3(aimX, aimY);
            
            //Tinh vector aim static
            float aimDirectionX = aimX - transform.position.x;
            float aimDirectionY = aimY - transform.position.y;
            aimDirectionVector = new Vector2(aimDirectionX, aimDirectionY).normalized;
        }
        else if(aimDirect.x == 0 && aimDirect.y == 0)
        {
            //Di chuyen atkPos
            float posX = atkPos.transform.position.x + moveDirect.x * speed * Time.deltaTime;
            float posY = atkPos.transform.position.y + moveDirect.y * speed * Time.deltaTime;
            atkPos.transform.position = new Vector3(posX, posY);
            
            /*//Lay vector Aim
            float xDirect = atkPos.transform.position.x - transform.position.x;
            float yDirect = atkPos.transform.position.y - transform.position.y;
            aimDirect = new Vector2(xDirect, yDirect).normalized;*/

            //Lay vector Aim static
            float aimDirectionX = atkPos.position.x - transform.position.x;
            float aimDirectionY = atkPos.position.y - transform.position.y;
            aimDirectionVector = new Vector2(aimDirectionX, aimDirectionY).normalized;
        }
    }

    public void DashSpeedControl()
    {
        dashTimeRemaining -= Time.deltaTime;
        if (dashTimeRemaining <= 0)
        {
            speed = GetComponentInChildren<Hero>().Speed;
        }
    }

    public void Dash()
    {
        dashCD_ing -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dashCD_ing <= 0)
            {
                dashTimeRemaining = dashTime;
                dashCD_ing = dashCD;
                if (dashTimeRemaining >= 0)
                {
                    speed *= 2;
                }
            }
        }
    }

    public void Facing()
    {
        if (attackDirectionJoystick.Horizontal > 0)
        {
            facing = 1;
        }
        else if (attackDirectionJoystick.Horizontal < 0)
        {
            facing = -1;
        }
        transform.localScale = new Vector3(facing, transform.localScale.y, transform.localScale.z);
    }

    public void UpLevelAttack()
    {
        switch (attackLevel)
        {
            case 1:
                currentDMG += currentDMG * 0.1f;
                attackLevel++;
                break;
            case 2:

                attackLevel++;
                break;
            case 3:
                currentDMG += currentDMG * 0.1f;
                attackLevel++;
                break;
            case 4:

                attackLevel++;
                break;
            case 5:
                currentDMG += currentDMG * 0.1f;
                attackLevel++;
                break;
            case 6:
                break;
        }
    }

    public int AttackLevel()
    {
        return attackLevel;
    }
}
