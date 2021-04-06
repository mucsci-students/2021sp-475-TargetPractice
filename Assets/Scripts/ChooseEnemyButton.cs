using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemyButton : MonoBehaviour
{
    private GameObject GM;

    private void Start ()
    {
        GM = GameObject.Find("GameManager");
    }

    public void selectBlue()
    {
        GM.GetComponent<GameManager>().selectedEnemy = 0;
        GM.GetComponent<GameManager>().swapEnemy();
    }

    public void selectGreen()
    {
        GM.GetComponent<GameManager>().selectedEnemy = 1;
        GM.GetComponent<GameManager>().swapEnemy();
    }
}
