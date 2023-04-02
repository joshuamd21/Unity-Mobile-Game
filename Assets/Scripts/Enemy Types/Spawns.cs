using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : Enemy
{
    private float aggroDistance = 12;
    private bool aggroed = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
        player = GameObject.Find("Player");
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    protected override void movement()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distToPlayer < aggroDistance)
        {
            aggroed = true;
        }
        if (aggroed)
        {
            base.movement();
        }
    }
}
