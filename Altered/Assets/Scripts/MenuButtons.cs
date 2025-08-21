using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    // Open a new menu panel (e.g., for sub-menus)
    public void OpenNewMenu(GameObject newMenu)
    {
        newMenu.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }

    // Load the DeckManagerScene
    public void ChangeSceneToDeckManager()
    {
        SceneManager.LoadScene("DeckManagerScene");
    }

    // Load the PlayMenuScene
    public void ChangeSceneToPlayMenu()
    {
        SceneManager.LoadScene("PlayMenuScene");
    }

    // Return to the MainMenuScene
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
