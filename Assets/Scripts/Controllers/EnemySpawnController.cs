using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private enum enemyTypes { RANDOM, RANGED, SEEKER, TANK, SPAWNER }
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private GameObject EnemyHealthBars;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 1.5f, 0);
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemies[((int)enemyTypes.RANDOM)]);
        GameObject health = Instantiate(healthBar);
        health.GetComponent<HealthBarController>().setTarget(enemy.transform, offset);
        health.transform.SetParent(EnemyHealthBars.transform, false);
        enemy.GetComponent<Enemy>().setUpHealthBar(health);
    }

}
