using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
<<<<<<< Updated upstream
    public void PlayLevel1(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
=======
 public void LoadLevel1()
    {
        Application.LoadLevel("Game Level");
>>>>>>> Stashed changes
    }
}
