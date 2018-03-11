using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthUI : MonoBehaviour
{

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = PlayerStats.Lives + " Lives";
    }
}
