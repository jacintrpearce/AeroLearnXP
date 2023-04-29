using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AL_MainMenu : MonoBehaviour
{
    // Create public object to be defined in the Canvas GameObject (Drag the appropriate menu scene to the field)
    public GameObject MainMenu;
    public GameObject AerofoilMenu;
    public GameObject RAE2822Menu;
    public GameObject ComparativeCases;

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
        // Set the menu that is wanted to be displayed
        MainMenu.SetActive(false);
        AerofoilMenu.SetActive(false);
        RAE2822Menu.SetActive(true);
        ComparativeCases.SetActive(false);

    }
    public void AerofoilMenuButton()
    {
        MainMenu.SetActive(false);
        AerofoilMenu.SetActive(true);
        RAE2822Menu.SetActive(false);
        ComparativeCases.SetActive(false);
    }

    public void MainMenuButton()
    {
        MainMenu.SetActive(true);
        AerofoilMenu.SetActive(false);
        RAE2822Menu.SetActive(false);
        ComparativeCases.SetActive(false);
    }
    public void ComparativeButton()
    {
        MainMenu.SetActive(false);
        AerofoilMenu.SetActive(false);
        RAE2822Menu.SetActive(false);
        ComparativeCases.SetActive(true);
    }
    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}