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
    public Button doubScoreButt, sidekickButt, bulletButt, enemyButt, fakeKickButt, fakeEnButt,
            ogBackButt, skyBackButt, grassBackButt, fieldBackButt, dungeonBackButt, secretBackButt,
            fakeOgButt, fakeSkyButt, fakeGrassButt, fakeFieldButt, fakeDungeonButt, fakeSecretButt,
            lidlGreen, lidlBlue;
    [HideInInspector]
    public int headPoints,buyBullet, buySide, buyDouble, bodyPoints, buyEnemy, selectedEnemy;
    [HideInInspector]
    public bool sidekickOwned, enemyBought;
    public int buyOG, buyGrass, buySky, buyField, buyDungeon, buySecret;


    // public variables
    public GameObject Shop, SpawnArea, sidekick;
    public TextMeshProUGUI score;
    public TextMeshProUGUI multi;

    // private primivites
    private int spawnBoxLimit = 5;
    private bool enemySpawned = false;

    // private variables
    private GameObject chosenEnemy; // The enemy that the player chooses from their list of enemies owned
    private GameObject target1, target2;

    // private structures
    private List<GameObject> enemies = new List<GameObject>();

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
            buyDouble = 50;
            buySide = 500;
            buyBullet = 20;
            buyEnemy = 200;
            buyOG = 100;
            buySky = 300;
            buyGrass = 200;
            buyField = 400;
            buyDungeon = 500;
            buySecret = 1000;
            sidekickOwned = false;
            enemyBought = false;
            selectedEnemy = 0;
        }
        determineEnemyButtonsActive();
        addCurrentOwnedEnemies();
        StartCoroutine(Spawner());
        //doubScoreButt.interactable = false;
        //sidekickButt.interactable = false;
        //bulletButt.interactable = false;
        //enemyButt.interactable = false;
        fakeKickButt.interactable = false;
        fakeEnButt.interactable = false;
        ogBackButt.interactable = false;
        grassBackButt.interactable = false;
        skyBackButt.interactable = false;
        fieldBackButt.interactable = false;
        dungeonBackButt.interactable = false;
        secretBackButt.interactable = false;
        fakeOgButt.interactable = false;
        fakeGrassButt.interactable = false;
        fakeSkyButt.interactable = false;
        fakeFieldButt.interactable = false;
        fakeDungeonButt.interactable = false;
        fakeSecretButt.interactable = false;

    }

    private void Update()
    {
        if (Input.GetKey ("escape"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
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

        //background purchasing, origina
        if (points >= buyOG)
        {
            ogBackButt.interactable = true;
        }
        else
        {
            ogBackButt.interactable = false;
        }
        //sky background
        if (points >= buySky)
        {
            skyBackButt.interactable = true;
        }
        else
        {
            skyBackButt.interactable = false;
        }
        //grass background
        if (points >= buyGrass)
        {
            grassBackButt.interactable = true;
        }
        else
        {
            grassBackButt.interactable = false;
        }
        //field background
        if (points >= buyField)
        {
            fieldBackButt.interactable = true;
        }
        else
        {
            fieldBackButt.interactable = false;
        }
        //dungeon background
        if (points >= buyDungeon)
        {
            dungeonBackButt.interactable = true;
        }
        else
        {
            dungeonBackButt.interactable = false;
        }
        //secret background
        if (points >= buySecret)
        {
            secretBackButt.interactable = true;
        }
        else
        {
            secretBackButt.interactable = false;
        }
        determineEnemyButtonsActive();
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
        buyDouble = data.buyDouble;
        buySide = data.buySide;
        buyBullet = data.buyBullet;
        buyEnemy = data.buyEnemy;
        headPoints = data.headPoints;
        bodyPoints = data.bodyPoints;
        buyOG = data.buyOG;
        buyGrass = data.buyGrass;
        buySky = data.buySky;
        buyField = data.buyField;
        buyDungeon = data.buyDungeon;
        buySecret = data.buySecret;

        doubScoreButt.GetComponentInChildren<Text>().text = "Double Score (" + buyDouble + ")";
        bulletButt.GetComponentInChildren<Text>().text = "Bullet Upgrade (" + buyBullet + ")";

        sidekickOwned = data.sidekickOwned;
        if (sidekickOwned == true)
        {
            activateSidekick();
        }
        points = data.points;
        selectedEnemy = data.selectedEnemy;
        if (selectedEnemy == 0)
        {
            lidlBlue.Select();
        } else if (selectedEnemy == 1)
        {
            lidlGreen.Select();
        }
        enemyBought = data.enemyBought;

        if (points >= buyDouble)
        {
            doubScoreButt.interactable = true;
        }
        else
        {
            doubScoreButt.interactable = false;
        }
        if (points >= buySide)
        {
            sidekickButt.interactable = true;
        }
        else
        {
            sidekickButt.interactable = false;
        }
        if (points >= buyBullet)
        {
            bulletButt.interactable = true;
        }
        else
        {
            bulletButt.interactable = false;
        }
        if (enemyBought)
        {
            enemyButt.gameObject.SetActive(false);
            fakeEnButt.gameObject.SetActive(true);
        }
        else if (data.points >= buyEnemy)
        {
            enemyButt.interactable = true;
        }
        else
        {
            enemyButt.interactable = false;
        }

        //background purchasing, origina
        if (points >= buyOG)
        {
            ogBackButt.interactable = true;
        }
        else
        {
            ogBackButt.interactable = false;
        }
        //sky background
        if (points >= buySky)
        {
            skyBackButt.interactable = true;
        }
        else
        {
            skyBackButt.interactable = false;
        }
        //grass background
        if (points >= buyGrass)
        {
            grassBackButt.interactable = true;
        }
        else
        {
            grassBackButt.interactable = false;
        }
        //field background
        if (points >= buyField)
        {
            fieldBackButt.interactable = true;
        }
        else
        {
            fieldBackButt.interactable = false;
        }
        //dungeon background
        if (points >= buyDungeon)
        {
            dungeonBackButt.interactable = true;
        }
        else
        {
            dungeonBackButt.interactable = false;
        }
        //secret background
        if (points >= buySecret)
        {
            secretBackButt.interactable = true;
        }
        else
        {
            secretBackButt.interactable = false;
        }
        if (sidekickOwned)
        {
            sidekickButt.gameObject.SetActive(false);
            fakeKickButt.gameObject.SetActive(true);
        }
        else if (data.points >= buySide)
        {
            sidekickButt.interactable = true;
        }
        else
        {
            sidekickButt.interactable = false;
        }
        //multiplier = data.multiplier;
    }

    public void activateSidekick()
    {
        Instantiate(sidekick, sidekick.transform.position, Quaternion.identity);
    }

    public void swapEnemy()
    {
        chosenEnemy = enemies[selectedEnemy];
    }

    private void determineEnemyButtonsActive()
    {
        if (enemyBought == false)
        {
            lidlGreen.interactable = false;
        } else {
            lidlGreen.interactable = true;
        }
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

    private void addCurrentOwnedEnemies()
    {
        GameObject[] enemiesArray = Resources.LoadAll<GameObject>("Enemies");
        foreach (GameObject enemy in enemiesArray)
        {
            enemies.Add((GameObject)enemy);
        }
        chosenEnemy = enemies[selectedEnemy];
    }

    private void OnApplicationQuit ()
    {
        SaveGame();
    }
}
