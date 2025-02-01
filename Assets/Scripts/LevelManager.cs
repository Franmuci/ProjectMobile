using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] GameObject firstWave;
    [SerializeField] GameObject secondWave;

    bool isSecondWave;

    bool canAdd;

    [SerializeField] GameObject panelEnd;
    [SerializeField] SavePoints scriptableSavePoints;
    [SerializeField] GameObject leaderboardPanel;
    [SerializeField] GameObject submitLeaderPanel;
    [SerializeField] GameObject boardPanel;
    [SerializeField] GameObject buttonAgain;
    [SerializeField] TMP_InputField inputText;



    private void Start()
    {
        SaveManager.Instance.ReadFileOverwrite();
        InvokeRepeating(nameof(Spawner), 3f, 3f);
        ActualizarLeaderboard();
        panelEnd.SetActive(false);
        submitLeaderPanel.SetActive(false);



    }

    private void Spawner()
    {
        if (isSecondWave)
        {
            Instantiate(secondWave);
            isSecondWave = false;
        }
        else
        {
            Instantiate(firstWave);
            isSecondWave = true;
        }
    }

    public void AddLeaderboard()
    {
        scriptableSavePoints.leaderBoard.Add(new LeaderBoard(inputText.text, GameManager.Instance.totalPoints));
        submitLeaderPanel.SetActive(false);
        ActualizarLeaderboard();
    }

    public void AnadirListener()
    {
        if (!canAdd)
        {
            canAdd = true;
            buttonAgain.GetComponent<Button>().onClick.AddListener(() => FindAnyObjectByType<TransitionManager>().LoadScene("Level1"));

            //Destroy(gameObject);
        }


    }

    private void ActualizarLeaderboard()
    {
        scriptableSavePoints.leaderBoard.Sort((a, b) => b.puntos.CompareTo(a.puntos));

        foreach (Transform g in leaderboardPanel.transform)
        {
            Destroy(g.gameObject);
        }

        foreach (LeaderBoard p in scriptableSavePoints.leaderBoard)
        {
            GameObject a = Instantiate(boardPanel, leaderboardPanel.transform);
            a.GetComponentInChildren<TMP_Text>().text = $"{p.nombre} - {p.puntos}";
        }
        SaveManager.Instance.WriteFileOverwrite();
    }

    public void ColliderEndHit()
    {
        Time.timeScale = 0.0f;
        panelEnd.SetActive(true);
        if (scriptableSavePoints.highScore <= GameManager.Instance.totalPoints)
        {
            scriptableSavePoints.highScore = GameManager.Instance.totalPoints;
        }

        if (scriptableSavePoints.leaderBoard.Count < 10)
            submitLeaderPanel.SetActive(true);
        else
        {
            if (scriptableSavePoints.leaderBoard.Min((a) => a.puntos) <= GameManager.Instance.totalPoints)
            {
                submitLeaderPanel.SetActive(true);
                if (scriptableSavePoints.leaderBoard.Count >= 10)
                    scriptableSavePoints.leaderBoard.RemoveAt(scriptableSavePoints.leaderBoard.Count - 1);
            }
        }
        AnadirListener();
    }
}
