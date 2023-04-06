using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private float targetDistance;
    private float slack;
    private bool allowFire = true;
    private float rateOfFire = 1;
    [SerializeField]
    private GameObject bulletPooled;
    private List<GameObject> bullets;
    private GameObject bulletHolder;
    private int maxBullets = 5;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
        targetDistance = 7;
        slack = 0.5f;
        player = GameObject.Find("Player");
        rB = GetComponent<Rigidbody2D>();

        bulletHolder = new GameObject(gameObject.name + "Holder");
        // Loop through list of pooled objects,deactivating them and adding them to the list 
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
        movement();
        float playerDistance = Vector2.Distance(player.transform.position, transform.position);
        if (allowFire && playerDistance <= targetDistance + slack)
        {
            StartCoroutine("attack");
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

    private IEnumerator attack()
    {
        allowFire = false;
        Vector3 toPlayer = (player.transform.position - transform.position).normalized;
        GameObject bullet = GetPooledObject();
        if (bullet is not null)
        {
            bullet.SetActive(true);
            bullet.transform.right = toPlayer;
            bullet.transform.position = transform.position + toPlayer;
        }
        yield return new WaitForSeconds(rateOfFire);
        allowFire = true;
    }
    protected override void movement()
    {
        transform.right = player.transform.position - transform.position;
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        Vector2 toPlayer = (player.transform.position - transform.position).normalized;
        if (distToPlayer > targetDistance)
        {
            rB.AddForce(toPlayer * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
        }
        else if (distToPlayer < targetDistance - slack)
        {
            rB.AddForce(-toPlayer * Time.deltaTime * speed * magnitude, ForceMode2D.Impulse);
        }
    }
}
