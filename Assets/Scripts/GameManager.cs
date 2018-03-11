using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;

    public SceneFader fader;

    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    private GameObject currentUI;

    public string mainMenuName = "LevelSelect";
    public string nextLevelName = "Level02";
    public int levelToLock = 2;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void OnEnable()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }

    public void Toggle()
    {
        currentUI.SetActive(!currentUI.activeSelf);
        Time.timeScale = currentUI.activeSelf ? 0f : 1f;
    }

    public void pause()
    {
        currentUI = pauseUI;
        Toggle();
    }

    public void GameOver()
    {
        gameIsOver = true;
        currentUI = gameOverUI;
        Toggle();
    }

    public void GameWin()
    {
        PlayerPrefs.SetInt("levelReached", levelToLock);
        gameIsOver = true;
        currentUI = gameWinUI;
        Toggle();
    }

    public void Retry()
    {
        Toggle();
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        fader.FadeTo(mainMenuName);
    }

    public void NextLevel()
    {
        Toggle();
        fader.FadeTo(nextLevelName);
    }
}
