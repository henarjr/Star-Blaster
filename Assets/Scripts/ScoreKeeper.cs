using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;

    static ScoreKeeper instance;
    public static ScoreKeeper Instance => instance;

    void Awake()
    {
        ManagerSingleton();
    }
    void ManagerSingleton()
    {
        //int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        //if (instanceCount > 1 )
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }



    public int GetScore()
    {
        return currentScore;
    }

    public void ModifyScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue); // Ensure score doesn't go below 0
        print("Current Score: " + currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }


}
