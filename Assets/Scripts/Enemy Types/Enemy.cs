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
    protected HealthBarController healthBar;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.Find("Player");
        rB = GetComponent<Rigidbody2D>();
    }
    public void setUpHealthBar(GameObject healthbar)
    {
        healthBar = healthbar.GetComponent<HealthBarController>();
    }
    protected virtual void setDefaultValues(float spd, float dmg, float hp)
    {
        speed = spd;
        damage = dmg;
        health = hp;
    }
    protected virtual void movement()
    {
        Vector2 toPlayer = (player.transform.position - transform.position).normalized;
        rB.AddForce(toPlayer * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
        transform.up = player.transform.position - transform.position;
    }
    protected virtual void attack()
    {
        player.GetComponent<PlayerController>().takeDamage(damage);
    }
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            attack();
            Destroy(gameObject);
        }
    }
}
