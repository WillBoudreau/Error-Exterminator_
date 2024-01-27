using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int sceneBuildIndex;
    void Start()
    {
        Time.timeScale = 1f;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }
    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
