using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextSpawn = Time.time + spawnRate;
        randX = Random.Range (-10.4f, 8.4f);
        whereToSpawn = new Vector2 (randX, transform.position.y);
        Instantiate (enemy, whereToSpawn, Quaternion.identity);
    }
}
