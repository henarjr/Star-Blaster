using UnityEngine;
public class characterSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject ship1;
    [SerializeField] GameObject ship2;
    [SerializeField] GameObject ship3;

    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseShip1()
    {
        ship1.SetActive(true);
        BeginGame();
    }

    public void ChooseShip2()
    {
        ship2.SetActive(true);
        BeginGame();
    }

    public void ChooseShip3()
    {
        ship3.SetActive(true);
        BeginGame();
    }

}
