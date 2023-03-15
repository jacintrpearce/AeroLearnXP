using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AL_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject AerofoilMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("RAE2822 Level");
    }

    public void AerofoilMenuButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        AerofoilMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        AerofoilMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}