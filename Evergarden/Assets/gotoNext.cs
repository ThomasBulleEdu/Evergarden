using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gotoNext : MonoBehaviour
{
    public string levelName;

    public void loadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    public void quit()
    {
        Application.Quit();
    }

}
