using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Bien singleton
    public static GameManager gameManager;
    #endregion

    #region Bien EXP
    float time;
    float minRandomExp;
    float maxRandomExp;
    [SerializeField] float maxEXP;
    float currentEXP;
    #endregion

    #region Bien HP
    float maxHP;
    float currentHP;
    #endregion

    #region Bien shield
    [SerializeField] float shieldCD;
    float shieldCD_ing;
    float maxArmor;
    float currentArmor;
    #endregion

    GameObject hero;

    public GameObject[] ExpGemPref;
    public GameObject hpDropItem;
    public GameObject coinDropItem;

    private void Awake()
    {
        if (gameManager && gameManager != this)
        {
            Debug.LogError("Loi nhieu Game Manager");
        }
        else
            gameManager = this;
    }

    void Start()
    {
        currentEXP = 0;
        hero = GameObject.FindWithTag("Player");
        maxHP = hero.GetComponentInChildren<Hero>().HP;
        currentHP = hero.GetComponentInChildren<Hero>().HP;
        shieldCD_ing = 0;

        time = 0;
        minRandomExp = 0;
        maxRandomExp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (currentHP <= 0)
        {
            currentHP = 0;
        }*/

        ShieldDamageStatus();
        GetExpGemBaseOnTime();
    }

    public float MaxEXP
    {
        get
        {
            return maxEXP;
        }
        set
        {
            maxEXP = value;
        }
    }

    public float CurrentEXP
    {
        get
        {
            return currentEXP;
        }
        set
        {
            currentEXP = value;
        }
    }

    public float MaxHP
    {
        get
        {
            return maxHP;
        }
        set
        {
            maxHP = value;
        }
    }

    public float CurrentHP
    {
        get
        {
            return currentHP;
        }
        set
        {
            currentHP = value;
        }
    }

    public float MaxArmor
    {
        get
        {
            return maxArmor;
        }
        set
        {
            maxArmor = value;
        }
    }

    public float CurrentArmor
    {
        get
        {
            return currentArmor;
        }
        set
        {
            currentArmor = value;
        }
    }

    public void HeroTakeDamage(float dmg)
    {
        if (BuffManager.armorLevel >= 1)
        {
            float remainDMG = dmg - currentArmor;
            if (remainDMG <= 0)
            {
                currentArmor = -remainDMG;
            }
            else
            {
                currentArmor = 0;
                currentHP -= remainDMG;
            }
            shieldCD_ing = shieldCD;
        }
        else
        {
            currentHP -= dmg;
            Debug.Log(dmg);
        }
    }

    public int GetExpGemID()
    {
        int expGemID = (int)Random.Range(minRandomExp, maxRandomExp);
        if (expGemID == maxRandomExp)
        {
            expGemID -= 1;
        }
        return expGemID;
    }

    public void GetExpGemBaseOnTime()
    {
        time += Time.deltaTime;
        if (time <= 180)// 180
        {
            minRandomExp = 0;
            maxRandomExp = 1;
        }
        else if (time > 180 && time <= 360)// 180 - 360
        {
            minRandomExp = 0;
            maxRandomExp = 2;
        }
        else if (time > 360 && time <= 540)// 360 - 540
        {
            minRandomExp = 0;
            maxRandomExp = 3;
        }
        else
        {
            minRandomExp = 1;
            maxRandomExp = 4;
        }
    }

    public void ShieldDamageStatus()
    {
        shieldCD_ing -= Time.deltaTime;

        if (shieldCD_ing <= 0)
        {
            currentArmor = maxArmor;
        }
    }
}
