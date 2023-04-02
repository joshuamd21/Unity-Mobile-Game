using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float health;
    private float damage;
    [SerializeField]
    private float speed = 20;
    private float maginitude = 100;
    private float rotationSpeed = 360;
    private Rigidbody2D rB;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vertic = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horiz, vertic);

        rB.AddForce(movementDirection * Time.deltaTime * maginitude * speed, ForceMode2D.Impulse);

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }
}
