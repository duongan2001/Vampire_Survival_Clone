using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDemo : MonoBehaviour
{
    [SerializeField]GameObject heroSpritePref;

    private void Start()
    {
        GameObject heroSprite = Instantiate(heroSpritePref, transform.position, Quaternion.identity);
        heroSprite.transform.parent = this.transform;
    }

    /*public override void Attack(Transform atkPos, GameObject attackPref)
    {
        atkCD_ing -= Time.deltaTime;

        if (atkCD_ing <= 0)
        {
            Instantiate(attackPref, new Vector3(atkPos.position.x, atkPos.position.y), Quaternion.identity);
            atkCD_ing = atkCD;
        }
    }*/

}
