using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Object Referances")]
    public TextMeshProUGUI HpHud;
    public TextMeshProUGUI DebugCountHud;
    public GameObject pauseMenu;
    public GameObject HUD;
    public GameObject ControlMenu;
    public Slider dashSlider;
    public GameObject DeathMessageObj;
    public TextMeshProUGUI DebugCountEndText;
    [Header("HUD Variables")]
    public static int debugCount;
    private static int playerHP;
    public static int playerKills;
    private string healthString;
    private string debugCountString;
    private static float dashCoolDown;
    private static bool playerIsDead;
    public int endlessSceneBuildIndex;
    public int menuSceneBuildIndex;
    public int gameSceneBuildIndex;
    [Header("Pause Bool")]
    private bool GameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        playerIsDead = false;
        GameIsPaused = false;
        debugCount = 0;
        playerKills = 0;
        playerHP = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Pause/Unpause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused == true)
            {
                UnPause();
            }
            if(GameIsPaused == false)
            {
                Pause();
            }
        }
        // Extra space at the start of sting is for screen formating
        healthString = string.Format(" Health: {0}", playerHP); //sets health text on HUD
        debugCountString = string.Format("Debug Count: {0}", playerKills); // Sets Kill Count on HUD
        dashSlider.value = dashCoolDown; //Controls the value for cooldown slider
        HpHud.text = healthString; //Sets health text
        DebugCountHud.text = debugCountString;//Sets kill count text
        //Checks if player is dead
        if(playerIsDead == true)
        {
            DeathMessage(); //If dead play death message
        }
        if(GameIsPaused == true) //If paused, show pasue menu
        {
            Pause();
        }
    }
    public static void UpdateUI(int HP, float abilityCoolDown)
    {
        //Updates the HP and cooldown on HUD
        if(abilityCoolDown <= 0)
        {
            dashCoolDown = 1;
        }
        playerHP = HP;
        dashCoolDown = abilityCoolDown;
    }
    private void Pause()
    {
        //Pauses Game
        GameIsPaused = true;
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void UnPause()
    {
        //Un Pauses Game
        GameIsPaused = false;
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ToMenu()
    {
        //Goes back to main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneBuildIndex);
    }
    public void CheckControls()
    {
        //Opens control menu
        pauseMenu.SetActive(false);
        ControlMenu.SetActive(true);
    }
    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public static void PlayerIsDead()
    {
        //Sets player as dead. 
        playerIsDead = true;
    }
    public void DeathMessage()
    {
        //Spawns the death message
        DeathMessageObj.SetActive(true);
        HUD.SetActive(false);
        DebugCountEndText.text = string.Format("Debug count: {0}",playerKills);
    }
    public void RestartGame()
    {
        //Used by button to reset game on Debug
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneBuildIndex);
    }
    public static void AddToKills()
    {
        //adds a kill to the players HUD
        playerKills++;
    }
    public void RestartEndless()
    {
        //Used by button to reset on endless
        Time.timeScale = 1f;
        SceneManager.LoadScene(endlessSceneBuildIndex);
    }
}
