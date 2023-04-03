using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rB;
    private float magnitude = 100;
    // Start is called before the first frame update
    void Start()
    {
        speed = 12;
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rB.AddRelativeForce(Vector2.right * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("bullet collided");
        gameObject.SetActive(false);
    }
}