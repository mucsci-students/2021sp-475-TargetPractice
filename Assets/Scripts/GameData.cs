using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int points, headPoints, bodyPoints;
    public int buyDouble, buySide, buyBullet, buyEnemy;
    public int selectedEnemy;
    public bool sidekickOwned, enemyBought;
    public int buyOG, buyGrass, buySky, buyField, buyDungeon, buySecret;

    public GameData (GameManager GM)
    {
        points = GM.points;
        headPoints = GM.headPoints;
        bodyPoints = GM.bodyPoints;
        buyDouble = GM.buyDouble;
        buySide = GM.buySide;
        buyBullet = GM.buyBullet;
        buyEnemy = GM.buyEnemy;
        sidekickOwned = GM.sidekickOwned;
        selectedEnemy = GM.selectedEnemy;
        enemyBought = GM.enemyBought;
        buyOG = GM.buyOG;
        buyGrass = GM.buyGrass;
        buySky = GM.buySky;
        buyField = GM.buyField;
        buyDungeon = GM.buyDungeon;
        buySecret = GM.buySecret;

        //multiplier = GM.multiplier;
    }
}
