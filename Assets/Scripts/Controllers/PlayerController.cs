using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private List<GameObject> bullets;
    private GameObject bulletHolder;
    public GameObject bulletPooled;
    private int maxBullets = 20;
    private float maxHealth;
    private float health;
    private float damage;
    private float speed = 10;
    private float maginitude = 100;
    private float rotationSpeed = 360;
    private float radius = 1.5f;
    private Rigidbody2D rB;
    private bool allowFire = true;
    private float rateOfFire = 0.5f;
    [SerializeField]
    private HealthBarController healthbar;
    // Start is called before the first frame update
    void Start()
    {

        health = 20;
        maxHealth = 20;
        healthbar.setMaxHealth(maxHealth);
        healthbar.setHealth(health);

        rB = GetComponent<Rigidbody2D>();

        // Loop through list of pooled objects,deactivating them and adding them to the list 
        bulletHolder = GameObject.Find("BulletHolder");
        bullets = new List<GameObject>();
        for (int i = 0; i < maxBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(bulletPooled);
            obj.SetActive(false);
            bullets.Add(obj);
            obj.transform.SetParent(bulletHolder.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (allowFire && Input.GetMouseButton(0))
        {
            StartCoroutine("FireBullet");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(2);
        }
    }
    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < bullets.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    private void MovePlayer()
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
    private IEnumerator FireBullet()
    {
        allowFire = false;
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.z = 0;
        Vector3 toMouse = (worldPosition - transform.position).normalized;
        GameObject bullet = GetPooledObject();
        if (bullet is not null)
        {
            bullet.SetActive(true);
            bullet.transform.right = toMouse;
            bullet.transform.position = transform.position + toMouse * radius;
        }
        yield return new WaitForSeconds(rateOfFire);
        allowFire = true;
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        healthbar.setHealth(health);
    }
}
