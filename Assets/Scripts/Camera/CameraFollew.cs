using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollew : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponentInChildren<HeroBody>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
