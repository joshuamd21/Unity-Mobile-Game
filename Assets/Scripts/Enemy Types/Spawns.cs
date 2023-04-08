using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : Enemy
{
    private float aggroDistance = 12;
    private bool aggroed = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        setDefaultValues(6, 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attack();
            gameObject.SetActive(false);
        }
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
