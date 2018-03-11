using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;

    public Button[] levelButtons;

    public string mainMenuName = "MainMenu";

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void Menu()
    {
        fader.FadeTo(mainMenuName);
    }

}
