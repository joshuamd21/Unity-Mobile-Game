using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float health;
    private float damage;
    private float speed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vertic = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horiz);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertic);
    }
}
