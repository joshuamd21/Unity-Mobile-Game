using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        setDefaultValues(2, 8, 20);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
