using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    private int startingLives = 5;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private FoodSpawner spawner;
    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private Text endScoreText;
    public static int lives = 5;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        lives = startingLives;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0) {
            spawner.CancelInvoke();
            spawner.enabled = false;
            gameover.SetActive(true);
            endScoreText.text = "Score: " + score.ToString();
            FoodController[] activeFoods = GameObject.FindObjectsOfType<FoodController>();
            foreach (var activeFood in activeFoods)
            {
                activeFood.enabled = false;
            }
            gameObject.SetActive(false);
        }
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
    }
}
