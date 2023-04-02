using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : Enemy
{
    void Start()
    {
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
