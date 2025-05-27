using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coffeeCount = 0;
    public static int highScore = 0;
    [SerializeField] GameObject coffeeDisplay;
    [SerializeField] GameObject highScoreDisplay;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        coffeeCount = 0;
    }

    void Update()
    {
        coffeeDisplay.GetComponent<TMPro.TMP_Text>().text = "COFFEE: " + coffeeCount;

        if(coffeeCount > highScore){
            highScore = coffeeCount;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreDisplay.GetComponent<TMPro.TMP_Text>().text = "HIGH SCORE: " + highScore;
    }
}
