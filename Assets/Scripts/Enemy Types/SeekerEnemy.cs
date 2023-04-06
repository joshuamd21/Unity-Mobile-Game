using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : Enemy
{
    void Start()
    {
        damage = 5;
        health = 10;
        speed = 4;
        player = GameObject.Find("Player");
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
