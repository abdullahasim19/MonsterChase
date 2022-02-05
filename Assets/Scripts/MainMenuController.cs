using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
       string clickedObj= UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        int selectedPlayer = int.Parse(clickedObj);
        GamePlayManager.instance.characterIndex = selectedPlayer;
        SceneManager.LoadScene("GamePlay");
    }
   
}
