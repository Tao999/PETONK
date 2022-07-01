using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("terrain");
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
