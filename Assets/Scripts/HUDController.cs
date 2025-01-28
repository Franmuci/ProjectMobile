using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [Header("HUD Text")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;


    private void OnGUI()
    {
        timeText.text = ((int)(GameManager.Instance.totalTime / 60)).ToString("00") + ":" + ((int)(GameManager.Instance.totalTime % 60)).ToString("00");
        scoreText.text = GameManager.Instance.totalPoints.ToString("00");
    }
}
