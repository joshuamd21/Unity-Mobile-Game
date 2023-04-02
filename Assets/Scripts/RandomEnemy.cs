using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : Enemy
{
    private float timeInDirection;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        rB = GetComponent<Rigidbody2D>();
        randomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    protected override void movement()
    {
        rB.AddForce(movementDirection * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("xWall"))
        {
            movementDirection.x *= -1;
        }
        else if (other.gameObject.CompareTag("yWall"))
        {
            movementDirection.y *= -1;
        }
    }
    private void randomDirection()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        movementDirection = new Vector2(x, y).normalized;
        // float degrees = Random.Range(-360, 360);
        // transform.rotation = Quaternion.Euler(0, 0, degrees);
    }
}
