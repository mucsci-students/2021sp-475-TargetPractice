using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // public primitives
    public int points;
    public Button doubScoreButt, sidekickButt, bulletButt, enemyButt, fakeKickButt, fakeEnButt;
    public int headPoints;
    public int bodyPoints;
    public int buyDouble;
    public int buySide;
    public int buyBullet;
    public int buyEnemy;

    // public variables
    public GameObject Shop, SpawnArea;
    public TextMeshProUGUI score;
    public TextMeshProUGUI multi;

    // private primivites
    private int spawnBoxLimit = 5;
    private bool enemySpawned = false;

    // private variables
    private GameObject chosenEnemy; // The enemy that the player chooses from their list of enemies owned
    private GameObject target1, target2;

    // private structures
    private List<GameObject> enemiesUnowned = new List<GameObject>();
    private List<GameObject> enemiesOwned = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        if (File.Exists(SaveSystem.path))
        {
            LoadGame();
        } else {
            points = 0;
            headPoints = 2;
            bodyPoints = 1;
            buyDouble = 20;
            buySide = 100;
            buyBullet = 30;
            buyEnemy = 40;
        }
        addCurrentUnownedEnemies();
        addCurrentOwnedEnemies();
        StartCoroutine(Spawner());
        doubScoreButt.interactable = false;
        sidekickButt.interactable = false;
        bulletButt.interactable = false;
        enemyButt.interactable = false;
        fakeKickButt.interactable = false;
        fakeEnButt.interactable = false;
    }

    private void Update()
    {
        score.text = "Points: " + points;
        //multi.text = "Multiplier: " + multiplier;
        // buy score doubler
        if (points >= buyDouble)
        {
            doubScoreButt.interactable = true;
        }
        else
        {
            doubScoreButt.interactable = false;
        }
        //buy side kick
        if (points >= buySide)
        {
            sidekickButt.interactable = true;
        }
        else
        {
            sidekickButt.interactable = false;
        }
        //buy bullet upgrade
        if (points >= buyBullet)
        {
            bulletButt.interactable = true;
        }
        else
        {
            bulletButt.interactable = false;
        }
        //buyt new enemy
        if (points >= buyEnemy)
        {
            enemyButt.interactable = true;
        }
        else
        {
            enemyButt.interactable = false;
        }

    }

    public void addHeadshotPoints()
    {
        points += headPoints;
    }

    public void addBodyPoints ()
    {
        points += bodyPoints;
    }

    public bool targetIsUp()
    {
        return target1 != null | target2 != null;
    }

    public void SaveGame () 
    {
        SaveSystem.SaveGameData(this);
    }

    public void LoadGame ()
    {
        GameData data = SaveSystem.LoadGame();

        points = data.points;
        //multiplier = data.multiplier;
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            if (!enemySpawned)
            {
                target1 = Spawn();
                target2 = Spawn();
                enemySpawned = true;
                yield return new WaitWhile(targetIsUp);
                enemySpawned = false;
            }
        }
    }

    private GameObject Spawn()
    {
        float randomY = UnityEngine.Random.Range(-spawnBoxLimit, spawnBoxLimit);
        Vector3 spawnPos = SpawnArea.transform.position + new Vector3 (0, randomY, 0);
        return Instantiate (chosenEnemy, spawnPos, Quaternion.identity);
    }

    private void addCurrentUnownedEnemies()
    {
        GameObject[] enemiesArray = Resources.LoadAll<GameObject>("Unowned Enemies");
        foreach (GameObject enemy in enemiesArray)
        {
            enemiesUnowned.Add((GameObject)enemy);
        }
    }

    private void addCurrentOwnedEnemies()
    {
        GameObject[] enemiesArray = Resources.LoadAll<GameObject>("Owned Enemies");
        foreach (GameObject enemy in enemiesArray)
        {
            enemiesOwned.Add((GameObject)enemy);
        }
        chosenEnemy = enemiesOwned[0];
    }

    private void OnApplicationQuit ()
    {
        SaveGame();
    }
}
