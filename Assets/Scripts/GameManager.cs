using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalPoints;
    public float totalTime;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;

        totalPoints = 0;
        totalTime = 0.0f;
    }
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

    }

    private void Update()
    {
        AddTime();
    }

    public void AddPoints(int add)
    {
        totalPoints += add;
    }

    private void AddTime()
    {
        totalTime += Time.deltaTime;
    }

}
