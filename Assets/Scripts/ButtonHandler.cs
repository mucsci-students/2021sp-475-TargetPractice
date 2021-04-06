using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
	private GameObject GM;
	public GameObject objToSpawn;
	public string m_Scene;
	public Button sidekick, multiplier;

	private void Start ()
	{
		GM = GameObject.Find("GameManager");
	}


	public void SetDoubScore()
	{
		GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buyDouble;
		GM.GetComponent<GameManager>().points *= 2;
		GM.GetComponent<GameManager>().buyDouble *= 2;
	}

	public void SetBulletPoints()
	{
		GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buyBullet;
		GM.GetComponent<GameManager>().headPoints++;
		GM.GetComponent<GameManager>().bodyPoints++;
		GM.GetComponent<GameManager>().buyBullet *= 2;
	}

	public void SetSideKick()
	{
		GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buySide;
		GM.GetComponent<GameManager>().sidekickOwned = true;
		print (GM.GetComponent<GameManager>().sidekickOwned);
		float zero = 0;
		float pos = 1 / zero;
		GM.GetComponent<GameManager>().buySide = (int)pos;
	}

	public void setEnemy()
	{
		GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buyEnemy;
		GM.GetComponent<GameManager>().enemyBought = true;
		float zero = 0;
		float pos = 1 / zero;
		GM.GetComponent<GameManager>().buyEnemy = (int)pos;
	}

	public void HandleBackgrounds(int whichBack)
	{
		if (whichBack == 1)
		{
			GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buyOG;
		}
		else if (whichBack == 2)
		{
			GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buyGrass;
		}
		else if (whichBack == 3)
		{
			GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buySky;
		}
		else if (whichBack == 4)
		{
			GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buyField;
		}
		else if (whichBack == 5)
		{
			GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buyDungeon;
		}
		else if (whichBack == 6)
		{
			GM.GetComponent<GameManager>().points -= GM.GetComponent<GameManager>().buySecret;
		}
	}


	public void DestroyButton(Button buttonBeGone)
	{
		Destroy(buttonBeGone);
	}

	public void FakeButtHandler(Button shushButton)
	{
		shushButton.enabled = false;
	}

	public void SetText(string text)
	{
		Text txt = transform.Find("Text").GetComponent<Text>();
		int doubleCompare = string.Compare(text, "double");
		int bulletCompare = string.Compare(text, "bullet");
		if (doubleCompare == 0)
		{
			txt.text = "Double Score (" + GM.GetComponent<GameManager>().buyDouble + ")";
		}
		else if (bulletCompare == 0)
		{
			txt.text = "Bullet Upgrade (" + GM.GetComponent<GameManager>().buyBullet + ")";
		}
	}

	private void startCoRout ()
	{
		StartCoroutine("UnlockSidekick");
	}

	private IEnumerator UnlockSidekick()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
		SceneManager.MoveGameObjectToScene(objToSpawn, SceneManager.GetSceneByName(m_Scene));
		SceneManager.UnloadSceneAsync(currentScene);
	}
}
