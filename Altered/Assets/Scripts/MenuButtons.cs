using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public void OpenNewMenu(GameObject newMenu)
    {
        newMenu.SetActive(true);
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }
    
    // To make a button change scenes.
    public void ChangeScene()
    {
        
    }
}
