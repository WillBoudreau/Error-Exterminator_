using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private bool GameIsPaused;
    public static int debugCount;
    private static int playerHP;
    public static int playerKills;
    public TextMeshProUGUI HpHud;
    public TextMeshProUGUI DebugCountHud;
    private string healthString;
    private string debugCountString;
    public GameObject pauseMenu;
    public GameObject HUD;
    public GameObject ControlMenu;
    public int menuSceneBuildIndex;
    public int gameSceneBuildIndex;
    private static float dashCoolDown;
    public Slider dashSlider;
    public GameObject DeathMessageObj;
    private static bool playerIsDead;
    public TextMeshProUGUI DebugCountEndText;

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
        healthString = string.Format(" Health: {0}", playerHP);
        debugCountString = string.Format("Debug Count: {0}", playerKills);
        dashSlider.value = dashCoolDown;
        HpHud.text = healthString;
        DebugCountHud.text = debugCountString;
        if(playerIsDead == true)
        {
            DeathMessage();
        }
        if(GameIsPaused == true)
        {
            Pause();
        }
    }
    public static void UpdateUI(int HP, float abilityCoolDown)
    {
        if(abilityCoolDown <= 0)
        {
            dashCoolDown = 1;
        }
        playerHP = HP;
        dashCoolDown = abilityCoolDown;
    }
    private void Pause()
    {
        GameIsPaused = true;
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void UnPause()
    {
        GameIsPaused = false;
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneBuildIndex);
    }
    public void CheckControls()
    {
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
        playerIsDead = true;
    }
    public void DeathMessage()
    {
        DeathMessageObj.SetActive(true);
        HUD.SetActive(false);
        DebugCountEndText.text = string.Format("Debug count: {0}",playerKills);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneBuildIndex);
    }
    public static void AddToKills()
    {
        playerKills++;
    }
}
