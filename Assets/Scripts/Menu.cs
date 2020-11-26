using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static float moveSpeed;
    public static float points;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("points", points);
        PlayerPrefs.GetFloat("movement", moveSpeed);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
        moveSpeed = 5f;
        PlayerPrefs.SetFloat("movement", moveSpeed);
        points = 0f;
        PlayerPrefs.SetFloat("points", points);
    }
}
