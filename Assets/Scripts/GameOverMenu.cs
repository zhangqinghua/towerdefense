using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public GameObject ui;
    public Text RoundsText;

    public void Toggle()
    {
        // RoundsText.text = PlayerStats.rounds.ToString();
        
        ui.SetActive(!ui.activeSelf);
  
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
