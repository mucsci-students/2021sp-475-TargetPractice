using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidekickFire : MonoBehaviour
{
    private float reloadTime;
    public GameObject gunEndPointPosition;
    public GameObject GameManager;
    private Transform bulletTransform;
    [SerializeField] private Transform pfBullet;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        reloadTime = 10;
        StartCoroutine("sidekickEngine");
    }

    // Update is called once per frame
    /*private void Update()
    {
        if (!bulletIsInAir())
        {
            if(GameManager.GetComponent<GameManager>().targetIsUp())
            {
                Vector3 enemyPos = GetAnEnemyPos();
                RotateSidekick(enemyPos);
                Fire(enemyPos);  
            } 
        } 
    }*/

    private IEnumerator sidekickEngine ()
    {
        while (true)
        {
            if (!bulletIsInAir())
            {
                if(GameManager.GetComponent<GameManager>().targetIsUp())
                {
                    Vector3 enemyPos = GetAnEnemyPos();
                    RotateSidekick(enemyPos);
                    Fire(enemyPos);
                    yield return new WaitForSeconds (reloadTime);  
                } 
            }
            yield return new WaitForSeconds (.01f);
        }
    }

    private bool bulletIsInAir ()
    {
        return (bulletTransform != null);
    }

    private Vector3 GetAnEnemyPos()
    {
        GameObject enemy = GameObject.Find("Enemy 1(Clone)");
        return enemy.transform.position + new Vector3(0, Random.Range(.2f, 1.3f), 0);
    }

    private void RotateSidekick(Vector3 enemyPos)
    {
        transform.right = enemyPos - transform.position;
    }

    private void Fire(Vector3 enemyPos)
    {
        bulletTransform = Instantiate(pfBullet, gunEndPointPosition.transform.position, Quaternion.identity);
        Vector3 shootDir = (enemyPos - gunEndPointPosition.transform.position).normalized;
        bulletTransform.GetComponent<Bullet>().Setup(shootDir, 6f);
    }
}
