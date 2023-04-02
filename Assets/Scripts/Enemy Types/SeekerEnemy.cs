using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : Enemy
{
    void Start()
    {
        speed = 5;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    protected override void movement()
    {
        transform.LookAt(player.transform, Vector3.up);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
}
