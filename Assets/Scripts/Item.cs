using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Text pointsAmount;
    public Text highScoreAmount;

    public GameObject diamond;
    public GameObject doublePoints;
    public GameObject player;

    public float points = 0f;

    public Player gameOver;

    public static float timeStart;
    public static float highScore;

    // Start is called before the first frame update
    private void Start()
    {
        gameOver = GameObject.FindObjectOfType(typeof(Player)) as Player; 
        //connect the gameOver variable with the player script to access the methods

        highScore = PlayerPrefs.GetFloat("highScore", highScore);
    }

    // Update is called once per frame
    void Update()
    {
        points = PlayerPrefs.GetFloat("points", points);
        timeStart = PlayerPrefs.GetFloat("timer", timeStart);
        if (points == 30 & timeStart == 0f)
        {
            gameOver.Play30();
        }
        if (points == 100 & timeStart == 0f)
        {
            gameOver.Play100();
        }
        if (points == 1 & timeStart == 0f)
        {
            gameOver.Play1();
        }
        if (points == 0f & timeStart == 0f)
        {
            gameOver.PlayAgain();
        }
        if (points < 150 & timeStart >= 50f)
        {
            gameOver.GameOver();
        }
        if (points < 1000 & timeStart >= 150f)
        {
            gameOver.GameOver();
        }
        if (points < 3000 & timeStart >= 300f)
        {
            gameOver.GameOver();
        }
        if (points < 7500 & timeStart >= 500f)
        {
            gameOver.GameOver();
        }
        if (points < 19500 & timeStart >= 1000f)
        {
            gameOver.GameOver();
        }
        if (points < 36000 & timeStart >= 1500f)
        {
            gameOver.GameOver();
        }
        if (points < 50000 & timeStart >= 2000f)
        {
            gameOver.GameOver();
        }
        if (points < 80000 & timeStart >= 2500f)
        {
            gameOver.GameOver();
        }
        if (points >= 80000 & timeStart >= 2500.5f)
        {
            gameOver.Pause();
        }

        if (points > highScore)
        {
            highScore = points;
        }
        highScoreAmount.text = "HS: " + highScore.ToString();

        PlayerPrefs.SetFloat("highScore", highScore);
        PlayerPrefs.Save();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Diamond(Clone)"))
        {
            Destroy(collision.gameObject);
            points += 10f;
            pointsAmount.text = points.ToString();
            PlayerPrefs.SetFloat("points", points);
        }

        if (collision.gameObject.name == ("DoublePoints(Clone)"))
        {
            Destroy(collision.gameObject);
            points += 20f;
            pointsAmount.text = points.ToString();
            PlayerPrefs.SetFloat("points", points);
        }

    }

}
