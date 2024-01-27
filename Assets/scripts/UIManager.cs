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
    private static int playerKills;
    public TextMeshProUGUI HpHud;
    public TextMeshProUGUI DebugCountHud;
    private string healthString;
    private string debugCountString;
    public GameObject pauseMenu;
    public GameObject HUD;
    public GameObject ControlMenu;
    public int sceneBuildIndex;
    private static float dashCoolDown;
    public Slider dashSlider;

    // Start is called before the first frame update
    void Start()
    {
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
        if(GameIsPaused == true)
        {
            Pause();
        }
    }
    public static void UpdateUI(int HP, int Kills, float abilityCoolDown)
    {
        if(abilityCoolDown <= 0)
        {
            dashCoolDown = 1;
        }
        playerHP = HP;
        playerKills = Kills;
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
        SceneManager.LoadScene(sceneBuildIndex);
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

}
