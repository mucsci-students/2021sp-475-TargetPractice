using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/Primary.unity");
    }

    public void MainMenuBack()
    {
        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Assets/Scenes/HowToPlay.unity");
    }

    public void Upgrades()
    {
        SceneManager.LoadScene("Assets/Scenes/UpgradeInfo.unity");
    }

    public void VS_Mode()
    {
    	SceneManager.LoadScene(3);
    }

    public void Ricochet()
    {
        SceneManager.LoadScene(4);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
