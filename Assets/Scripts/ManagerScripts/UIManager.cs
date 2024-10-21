using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider healhBarSlider;
    [SerializeField] Slider easeHealhBarSlider;
    
    [SerializeField] Slider expBarSlider;
    
    [SerializeField] Slider armorSlider;
    [SerializeField] GameObject armorSliderGO;

    float lerpSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        //HP bar
        SetHPBarValue();

        //EXP bar
        SetEXPBarValue();

        //Check armor bar
        SetArmorBarValue();

    }

    // Update is called once per frame
    void Update()
    {
        HealthStatus();
        EXPStatus();
        ArmorStatus();
    }

    public void HealthStatus()
    {
        if (healhBarSlider.value != GameManager.gameManager.CurrentHP)
        {
            healhBarSlider.value = GameManager.gameManager.CurrentHP;
        }

        if (healhBarSlider.value != easeHealhBarSlider.value)
        {
            easeHealhBarSlider.value = Mathf.Lerp(easeHealhBarSlider.value, GameManager.gameManager.CurrentHP, lerpSpeed);
        }
    }

    public void EXPStatus()
    {
        if (expBarSlider.value != GameManager.gameManager.CurrentEXP)
        {
            expBarSlider.value = GameManager.gameManager.CurrentEXP;
        }

        if (expBarSlider.maxValue != GameManager.gameManager.MaxEXP)
        {
            expBarSlider.maxValue = GameManager.gameManager.MaxEXP;
        }
    }

    public void ArmorStatus()
    {
        if (armorSlider.value != GameManager.gameManager.CurrentArmor)
        {
            armorSlider.value = GameManager.gameManager.CurrentArmor;
        }

        if (armorSlider.maxValue != GameManager.gameManager.MaxArmor)
        {
            armorSlider.maxValue = GameManager.gameManager.MaxArmor;
        }
    }

    public void SetHPBarValue()
    {
        healhBarSlider.maxValue = GameManager.gameManager.MaxHP;
        healhBarSlider.value = healhBarSlider.maxValue;
        easeHealhBarSlider.maxValue = GameManager.gameManager.MaxHP;
        easeHealhBarSlider.value = healhBarSlider.maxValue;
    }

    public void SetEXPBarValue()
    {
        expBarSlider.maxValue = GameManager.gameManager.MaxEXP;
        expBarSlider.value = 0;
    }

    public void SetArmorBarValue()
    {
        GameManager.gameManager.MaxArmor = BuffManager.buffManager.ReturnArmorValue();
        GameManager.gameManager.CurrentArmor = BuffManager.buffManager.ReturnArmorValue();

        armorSliderGO.SetActive(true);
        armorSlider.maxValue = BuffManager.buffManager.ReturnArmorValue();
        armorSlider.value = armorSlider.maxValue;
    }
}
