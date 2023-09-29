using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A Class which handles scenes changing, from main menu to actual gameplay.
/// </summary>
public class ChangeScene : MonoBehaviour
{

    /// <summary>
    /// This method loads a new scene.
    /// </summary>
    /// <param name="SceneID">SceneID</param>
    public void MoveToScene(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
    }

    /// <summary>
    /// This method quits the game.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
