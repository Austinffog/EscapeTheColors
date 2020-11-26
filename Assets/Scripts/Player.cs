using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float travelSpeed = 5f;
    private Rigidbody myRigidbody;

    public static float points;
    public Text pointsAmount;

    public static bool GameIsPaused = false;
    public GameObject GameOverMenu;

    private string storeID = "3565173";
    private string rewardedVideoID = "rewardedVideo";
    private int no;

    public GameObject pauseMenu;
    protected Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(storeID, false);
        myRigidbody = GetComponent<Rigidbody>();
        points = PlayerPrefs.GetFloat("points", points);

        joystick = FindObjectOfType<Joystick>();

        no = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = PlayerPrefs.GetFloat("movement", moveSpeed);

        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;

        myRigidbody.velocity = new Vector3(joystick.Horizontal * travelSpeed,
            joystick.Vertical * travelSpeed, myRigidbody.velocity.z);

        // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        // transform.position += movement * Time.deltaTime * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player") && collision.gameObject.name == ("Sphere(Clone)")
            | collision.gameObject.name == ("Cube(Clone)") | collision.gameObject.name == ("Capsule(Clone)"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void PlayAgain()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        moveSpeed = 5f;
        PlayerPrefs.SetFloat("movement", moveSpeed);
        points = 0f;
        PlayerPrefs.SetFloat("points", points);

        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Leave()
    {
        Application.Quit();
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Reward()
    {

        if (Advertisement.IsReady(rewardedVideoID))
        {

            var options = new ShowOptions { resultCallback = Options };
            Advertisement.Show(rewardedVideoID, options);

        }

    }

    private void Options(ShowResult result)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        moveSpeed = 5f;
        PlayerPrefs.SetFloat("movement", moveSpeed);


        switch (result)
        {
            case ShowResult.Finished:

                if (no == 1)
                {
                    points = 30;
                    pointsAmount.text = points.ToString();
                    PlayerPrefs.SetFloat("points", points);
                }
                else if (no == 2)
                {
                    points = 100;
                    pointsAmount.text = points.ToString();
                    PlayerPrefs.SetFloat("points", points);
                }
                else if (no == 3)
                {
                    points = 1;
                    pointsAmount.text = points.ToString();
                    PlayerPrefs.SetFloat("points", points);
                }
                break;
        }
    }

    public void Play30()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        moveSpeed = 5f;
        PlayerPrefs.SetFloat("movement", moveSpeed);
        points = 30;
        pointsAmount.text = points.ToString();
        PlayerPrefs.SetFloat("points", points);
    }

    public void Play100()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        moveSpeed = 5f;
        PlayerPrefs.SetFloat("movement", moveSpeed);
        points = 100;
        pointsAmount.text = points.ToString();
        PlayerPrefs.SetFloat("points", points);
    }

    public void Play1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        moveSpeed = 5f;
        PlayerPrefs.SetFloat("movement", moveSpeed);
        points = 1;
        pointsAmount.text = points.ToString();
        PlayerPrefs.SetFloat("points", points);
    }


}
