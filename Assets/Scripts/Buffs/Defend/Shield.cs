using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Buff
{
    [SerializeField] Transform player;
    [SerializeField] GameObject shieldPref;
    [Range(1, 2f)]
    [SerializeField] float radius;
    [SerializeField] Transform originPoint;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        SpawnShield(BuffManager.buffManager.ReturnShieldNumber());
    }

    private void Update()
    {
        ShieldPosition();
        RotateShield();
    }

    public void SpawnShield(int nunberofShield)
    {
        int numberofShield = BuffManager.buffManager.ReturnShieldNumber();
        for (int i = 0; i < numberofShield; i++)
        {
            float segment = 2 * Mathf.PI * i / numberofShield;
            float horizontalValue = Mathf.Cos(segment);
            float verticalValue = Mathf.Sin(segment);
            Vector2 dirValue = new Vector2(horizontalValue, verticalValue);
            Vector2 worldPos = (Vector2)originPoint.transform.position + dirValue * radius;
            GameObject shield = Instantiate(shieldPref, worldPos, Quaternion.identity);
            shield.transform.parent = originPoint.transform;
        }
    }

    public void RotateShield()
    {
        transform.Rotate(0, 0, -0.4f);
    }

    public void ShieldPosition()
    {
        transform.position = player.transform.position;
    }
}
