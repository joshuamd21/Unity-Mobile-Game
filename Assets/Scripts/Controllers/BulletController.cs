using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rB;
    private float magnitude = 100;
    private float radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = 3;
        speed = 12;
        rB = GetComponent<Rigidbody2D>();
    }

    public float getRadius()
    {
        return radius;
    }

    // Update is called once per frame
    void Update()
    {
        rB.AddRelativeForce(Vector2.up * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
    }
}
