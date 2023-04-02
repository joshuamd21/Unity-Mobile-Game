using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private float targetDistance;
    private float slack;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
        targetDistance = 7;
        slack = 0.5f;
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
        Vector2 toPlayer = (player.transform.position - transform.position).normalized;
        if (distToPlayer > targetDistance)
        {
            rB.AddForce(toPlayer * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
        }
        else if (distToPlayer < targetDistance - slack)
        {
            rB.AddForce(-toPlayer * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
        }
        transform.LookAt(player.transform, Vector3.up);
    }
}
