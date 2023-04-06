using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected Rigidbody2D rB;
    protected float speed;
    protected float magnitude { get; } = 100;
    protected float damage;
    protected float health;
    // Start is called before the first frame update
    protected virtual void movement()
    {
        Vector2 toPlayer = (player.transform.position - transform.position).normalized;
        rB.AddForce(toPlayer * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
        transform.right = player.transform.position - transform.position;
    }
}
