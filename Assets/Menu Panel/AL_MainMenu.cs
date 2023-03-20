using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AL_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject AerofoilMenu;
    public GameObject RAE2822Menu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void CfButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Skin Friction Scene");
    }
    public void VButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Velocity Scene");
    }
    public void PButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pressure Scene");
    }
    public void RAE2822MenuButton()
    {
        MainMenu.SetActive(false);
        AerofoilMenu.SetActive(false);
        RAE2822Menu.SetActive(true);

    }
    public void AerofoilMenuButton()
    {
        MainMenu.SetActive(false);
        AerofoilMenu.SetActive(true);
        RAE2822Menu.SetActive(false);
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        AerofoilMenu.SetActive(false);
        RAE2822Menu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}