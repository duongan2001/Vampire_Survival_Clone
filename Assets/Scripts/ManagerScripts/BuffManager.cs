using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager buffManager;

    [SerializeField] GameObject player;

    #region Defend buff variable
    public static int shieldLevel;
    public static int armorLevel;
    public static int bloodStealLevel;
    public static int hpDropLevel;
    public static int speedupLevel;
    public static int maxHPupLevel;

    [Header("Shield variable")]
    int numberofShield = 0;
    [SerializeField] GameObject shieldGroupPref;
    int numberofShieldGroup = 0;
    [Space(10)]
    #endregion

    #region Attack buff variable
    public static int axeLevel;
    public static int arrowLevel;
    public static int swordLevel;
    public static int boomerangLevel;
    public static int potionLevel;
    public static int shurikenLevel;

    [Header("Axe variable")]
    [SerializeField] GameObject axePref;
    [SerializeField] float axeCD;
    float axeCD_ing;
    public static int numberofAxe;
    [Space(10)]

    [Header("Arrow variable")]
    [SerializeField] GameObject arrowPref;
    [SerializeField] float arrowCD;
    float arrowCD_ing;
    int currentArrowNumber;
    [SerializeField] GameObject arrowControllerGameObject;    
    [SerializeField] Transform[] spawnArrowPos;
    public static int numberofArrow;
    [Space(10)]

    [Header("Sword variable")]
    [SerializeField] GameObject swordPref;
    [SerializeField] float swordCD;
    float swordCD_ing;
    [SerializeField] GameObject swordEnemyDetectGameObject;
    public static int numberofSword;
    public int currentSwordNumber;

    /*
    [Header("Boomerang variable")]
    [Header("Potion variable")]
    [Header("Shuriken variable")]
    */
    #endregion

    private void Awake()
    {
        if (buffManager && buffManager != this)
        {
            Debug.LogError("Loi nhieu Buff Manager");
        }
        else
            buffManager = this;

        SetDefendStartStat();
        SetAttackStartStat();
    }

    private void Start()
    {
        ReturnArrowDmg();

    }

    private void Update()
    {
        if (shieldLevel >= 1)
        {
            SpawnShieldGroup();
        }

        if (axeLevel >= 1)
        {
            ThrowAxe();
        }

        if (arrowLevel >= 1)
        {
            SpawnArrows();
            RotateArrowDirect();
        }

        if (swordLevel >= 1)
        {
            //SpawnSwords();
        }

    }

    public void SetDefendStartStat()
    {
        shieldLevel = 4;
        armorLevel = 1;
        bloodStealLevel = 0;
        hpDropLevel = 0;
        speedupLevel = 0;
        maxHPupLevel = 0;
    }

    public void SetAttackStartStat()
    {
        axeLevel = 3;
        axeCD_ing = 0;
        numberofAxe = 0;

        arrowLevel = 5;
        arrowCD_ing = 0;
        currentArrowNumber = 0;
        ReturnArrowDmg();

        swordLevel = 3;
        swordCD_ing = 2;
        currentSwordNumber = 0;
        ReturnSwordDmg();

        boomerangLevel = 0;
        potionLevel = 0;
        shurikenLevel = 0;
    }

    public void UpBuffLevel(int buffNameLevel)
    {
        buffNameLevel += 1;
    }

    public float ReturnBasicAttackValue()
    {
        float basicAttackDmg = player.GetComponentInChildren<Hero>().DMG;
        basicAttackDmg += basicAttackDmg * 0.1f;
        return LamTronSo(basicAttackDmg);
    }

    public int ReturnShieldNumber()
    {
        int shieldLevel = BuffManager.shieldLevel;
        switch (shieldLevel)
        {
            case 0:
                numberofShield = 0;
                break;

            case 1:
                numberofShield = 1;
                break;

            case 2:
                numberofShield = 2;
                break;

            case 3:
                numberofShield = 3;
                break;

            case 4:
                numberofShield = 4;
                break;

            case 5:
                numberofShield = 5;
                break;

            case 6:
                numberofShield = 6;
                break;
        }
        return numberofShield;
    }

    public void SpawnShieldGroup()
    {
        if (numberofShieldGroup == 0)
        {
            Instantiate(shieldGroupPref, transform.position, Quaternion.identity);
            numberofShieldGroup++;
        }       
    }

    public float ReturnArmorValue()
    {
        float armorValue = 0;
        switch (armorLevel)
        {
            case 0:
                armorValue = 0;
                break;

            case 1:
                armorValue = GameManager.gameManager.MaxHP * 0.15f;
                break;

            case 2:
                armorValue = GameManager.gameManager.MaxHP * 0.3f;
                break;

            case 3:
                armorValue = GameManager.gameManager.MaxHP * 0.45f;
                break;

            case 4:
                armorValue = GameManager.gameManager.MaxHP * 0.6f;
                break;

            case 5:
                armorValue = GameManager.gameManager.MaxHP * 0.75f;
                break;

            case 6:
                armorValue = GameManager.gameManager.MaxHP;
                break;
        }
        return LamTronSo(armorValue);
    }

    public float ReturnBloodStealValue()
    {
        float dmg = player.GetComponentInChildren<Hero>().DMG;
        float bloodStealValue = 0;
        switch (bloodStealLevel)
        {
            case 0:
                bloodStealValue = 0;
                break;

            case 1:
                bloodStealValue = dmg * 0.05f;
                break;

            case 2:
                bloodStealValue = dmg * 0.01f;
                break;

            case 3:
                bloodStealValue = dmg * 0.15f;
                break;

            case 4:
                bloodStealValue = dmg * 0.2f;
                break;

            case 5:
                bloodStealValue = dmg * 0.25f;
                break;

            case 6:
                bloodStealValue = dmg * 0.3f;
                break;
        }
        return LamTronSo(bloodStealValue);
    }

    public float ReturnHPDropPercentValue()
    {
        float hpDropPercent = 0;
        switch (bloodStealLevel)
        {
            case 0:
                hpDropPercent = 0;
                break;

            case 1:
                hpDropPercent = 8;
                break;

            case 2:
                hpDropPercent = 16;
                break;

            case 3:
                hpDropPercent = 16;
                break;

            case 4:
                hpDropPercent = 24;
                break;

            case 5:
                hpDropPercent = 24;
                break;

            case 6:
                hpDropPercent = 32;
                break;
        }
        return hpDropPercent;
    }

    public float ReturnHPRecoverValue()
    {
        float maxHP = GameManager.gameManager.MaxHP;
        float hpRecoverValue = 0;
        switch (bloodStealLevel)
        {
            case 0:
                hpRecoverValue = 0;
                break;

            case 1:
                hpRecoverValue = maxHP * 0.06f;
                break;

            case 2:
                hpRecoverValue = maxHP * 0.06f;
                break;

            case 3:
                hpRecoverValue = maxHP * 0.12f;
                break;

            case 4:
                hpRecoverValue = maxHP * 0.12f;
                break;

            case 5:
                hpRecoverValue = maxHP * 0.18f;
                break;

            case 6:
                hpRecoverValue = maxHP * 0.24f;
                break;
        }
        return LamTronSo(hpRecoverValue);
    }

    public float ReturnSpeedupValue()
    {
        float speedupValue = 0;
        switch (speedupLevel)
        {
            case 0:
                speedupValue = 0;
                break;

            case 1:
                speedupValue = 0.05f;
                break;

            case 2:
                speedupValue = 0.01f;
                break;

            case 3:
                speedupValue = 0.15f;
                break;

            case 4:
                speedupValue = 0.2f;
                break;

            case 5:
                speedupValue = 0.25f;
                break;

            case 6:
                speedupValue = 0.3f;
                break;
        }
        return speedupValue;
    }

    public float ReturnMaxHpValue()
    {
        float maxHPValue = GameManager.gameManager.MaxHP;
        maxHPValue += maxHPValue * 0.1f;
        return LamTronSo(maxHPValue);
    }

    public float ReturnAxeDmg()
    {
        float axeDmg = 0;
        switch(axeLevel)
        {
            case 0:
                axeDmg = 0;
                break;

            case 1:
                axeDmg = 40;
                break;

            case 2:
                axeDmg = 60;
                break;

            case 3:
                axeDmg = 60;
                break;

            case 4:
                axeDmg = 80;
                break;

            case 5:
                axeDmg = 80;
                break;

            case 6:
                axeDmg = 100;
                break;
        }
        return axeDmg;
    }

    public void ThrowAxe()
    {
        if (axeCD_ing > 0)
        {
            axeCD_ing -= Time.deltaTime;
            return;
        }
        else
        {
            if (axeLevel >= 3)
            {
                if (axeLevel >= 5)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        GameObject axe = Instantiate(axePref, player.transform.position, Quaternion.identity);
                        axe.GetComponentInChildren<Axe>().GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(axePref, player.transform.position, Quaternion.identity);
                    }
                }
            }
            else
            {
                Instantiate(axePref, Vector3.zero, Quaternion.identity);
            }
            axeCD_ing = axeCD;
        }
             
    }

    public float ReturnArrowDmg()
    {
        if (arrowLevel == 0)
        {
            return 0;
        }

        arrowControllerGameObject.SetActive(true);
        float arrowDmg = 0;
        switch (arrowLevel)
        {
            case 0:
                arrowDmg = 0;
                numberofArrow = 0;
                break;

            case 1:
                arrowDmg = 40;
                numberofArrow = 1;
                break;

            case 2:
                arrowDmg = 60;
                break;

            case 3:
                arrowDmg = 60;
                numberofArrow = 3;
                break;

            case 4:
                arrowDmg = 80;
                break;

            case 5:
                arrowDmg = 80;
                numberofArrow = 5;
                break;

            case 6:
                arrowDmg = 100;
                break;
        }
        return arrowDmg;
    }

    public void SpawnArrows()
    {
        if (arrowCD_ing > 0)
        {
            arrowCD_ing -= Time.deltaTime;
            return;
        }
        else
        {
            Instantiate(arrowPref, spawnArrowPos[currentArrowNumber].transform.position, Quaternion.identity);
            currentArrowNumber++;
            if (currentArrowNumber == numberofArrow)
            {
                arrowCD_ing = arrowCD;
                currentArrowNumber = 0;
            }
            else
            {
                arrowCD_ing = 0;
            }    
        }
    }

    public void RotateArrowDirect()
    {
        arrowControllerGameObject.transform.position = player.transform.position;
        float angle = Vector2.Angle(new Vector2(0.75f, 0), PlayerBehavior.aimDirectionVector);
        if (PlayerBehavior.aimDirectionVector.y >= 0)
        {
            arrowControllerGameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            arrowControllerGameObject.transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
        
    }

    public float LamTronSo(float input)
    {
        float du = input * 10 - (int)(input * 10);
        if (du < 0.5f)
        {
            du /= 10;
            input -= du;
        }
        else
        {
            du /= 10;
            input = input - du + 0.1f;
        }
        return input;
    }

    public float ReturnSwordDmg()
    {
        if (swordLevel == 0)
        {
            return 0;
        }

        swordEnemyDetectGameObject.SetActive(true);
        float swordDmg = 0;
        switch (swordLevel)
        {
            case 0:
                swordDmg = 0;
                numberofSword = 0;
                break;

            case 1:
                swordDmg = 40;
                numberofSword = 1;
                break;

            case 2:
                swordDmg = 60;
                break;

            case 3:
                swordDmg = 60;
                numberofSword = 3;
                break;

            case 4:
                swordDmg = 80;
                break;

            case 5:
                swordDmg = 80;
                numberofSword = 5;
                break;

            case 6:
                swordDmg = 100;
                break;
        }
        return swordDmg;
    }

    public void SpawnSwords()
    {
        if (swordCD_ing > 0)
        {
            swordCD_ing -= Time.deltaTime;
            return;
        }
        else
        {
            if (currentSwordNumber == swordEnemyDetectGameObject.GetComponent<SwordDetectEnemy>().enemyList.Count)
            {
                Debug.Log("Reset 0 - 1");
                swordCD_ing = swordCD;
                currentSwordNumber = 0;
                return;
            }

            Vector2 spawnSwordPos;

            spawnSwordPos.x = swordEnemyDetectGameObject.GetComponent<SwordDetectEnemy>().enemyList[currentSwordNumber].GetComponentInParent<Transform>().position.x;
            spawnSwordPos.y = player.transform.position.y + 5.5f;
            Instantiate(swordPref, spawnSwordPos, Quaternion.Euler(0, 0, 135));
            currentSwordNumber++;

            if (currentSwordNumber == numberofSword)
            {
                Debug.Log("Reset 0 - 2");
                swordCD_ing = swordCD;
                currentSwordNumber = 0;
            }
            else
            {
                swordCD_ing = 0.5f;
            }
        }
    }
}
