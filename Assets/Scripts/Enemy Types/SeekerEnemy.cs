using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
        setDefaultValues(4, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
