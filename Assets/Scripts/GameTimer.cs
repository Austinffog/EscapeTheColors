using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeStart = 0f;
    public Text gameCounter;
    Camera cam;
    public Color color1 = Color.blue;
    public Color color2 = Color.green;
    public Color color3 = Color.red;
    public Color color4 = Color.grey;
    public Color color5 = Color.cyan;
    public Color color6 = Color.yellow;
    public Color color7 = Color.black;
    public Color color8 = Color.white;

    public Text winner, Message50, Message150, Message300, Message500, Message1000, Message2500, Message5000, Message10000;

    public static float moveSpeed;
    private float duration = 0f;
    private float duration1 = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameCounter.text = timeStart.ToString("F2");
        cam = Camera.main;
        cam.clearFlags = CameraClearFlags.SolidColor;
        //round = PlayerPrefs.GetString("Game", round);

        //GameSave();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = PlayerPrefs.GetFloat("movement", moveSpeed);

        timeStart += Time.deltaTime;
        PlayerPrefs.SetFloat("timer", timeStart);
        if (timeStart < 50f)
        {
        }
        else if (timeStart >= 50f)
        {
            cam.backgroundColor = color1;
            moveSpeed = 10f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }
        else if (timeStart >= 150f)
        {
            cam.backgroundColor = color2;
            moveSpeed = 11f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }
        else if (timeStart >= 300f)
        {
            cam.backgroundColor = color3;
            moveSpeed = 12f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }
        else if (timeStart >= 500f)
        {
            cam.backgroundColor = color4;
            moveSpeed = 13f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }
        else if (timeStart >= 1000f)
        {
            cam.backgroundColor = color5;
            moveSpeed = 14f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }
        else if (timeStart >= 1500f)
        {
            cam.backgroundColor = color6;
            moveSpeed = 15f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }
        else if (timeStart >= 2000f)
        {
            cam.backgroundColor = color7;
            moveSpeed = 16f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }
        else if (timeStart >= 2500f)
        {
            cam.backgroundColor = color8;
            moveSpeed = 17f;
            PlayerPrefs.SetFloat("movement", moveSpeed);
        }

        if (timeStart >= 0.5f)
        {
            Invoke("TextEnable50", duration1);
        }
        if (timeStart >= 3.5f)
        {
            Invoke("TextDisable50", duration);
        }
        if (timeStart >= 50.5f)
        {
            Invoke("TextEnable150", duration1);
        }
        if (timeStart >= 53.5f)
        {
            Invoke("TextDisable150", duration);
        }
        if (timeStart >= 150.5f)
        {
            Invoke("TextEnable300", duration1);
        }
        if (timeStart >= 153.5f)
        {
            Invoke("TextDisable300", duration);
        }
        if (timeStart >= 300.5f)
        {
            Invoke("TextEnable500", duration1);
        }
        if (timeStart >= 303.5f)
        {
            Invoke("TextDisable500", duration);
        }
        if (timeStart >= 500.5f)
        {
            Invoke("TextEnable1000", duration1);
        }
        if (timeStart >= 503.5f)
        {
            Invoke("TextDisable1000", duration); ;
        }
        if (timeStart >= 1000.5f)
        {
            Invoke("TextEnable2500", duration1);
        }
        if (timeStart >= 1003.5f)
        {
            Invoke("TextDisable2500", duration);
        }
        if (timeStart >= 1500.5f)
        {
            Invoke("TextEnable5000", duration1);
        }
        if (timeStart >= 1503.5f)
        {
            Invoke("TextDisable5000", duration);
        }
        if (timeStart >= 2000.5f)
        {
            Invoke("TextEnable10000", duration1);
        }
        if (timeStart >= 2003.5f)
        {
            Invoke("TextDisable10000", duration);
        }
        if (timeStart >= 2500.5f)
        {
            Invoke("TextWinner", duration);
        }
        gameCounter.text = timeStart.ToString("F2");
    }

    private void TextEnable50()
    {
        Message50.enabled = true;
    }
    private void TextDisable50()
    {
        Message50.enabled = false;
    }
    private void TextEnable150()
    {
        Message150.enabled = true;
    }
    private void TextDisable150()
    {
        Message150.enabled = false;
    }
    private void TextEnable300()
    {
        Message300.enabled = true;
    }
    private void TextDisable300()
    {
        Message300.enabled = false;
    }
    private void TextEnable500()
    {
        Message500.enabled = true;
    }
    private void TextDisable500()
    {
        Message500.enabled = false;
    }
    private void TextEnable1000()
    {
        Message1000.enabled = true;
    }
    private void TextDisable1000()
    {
        Message1000.enabled = false;
    }
    private void TextEnable2500()
    {
        Message2500.enabled = true;
    }
    private void TextDisable2500()
    {
        Message2500.enabled = false;
    }
    private void TextEnable5000()
    {
        Message5000.enabled = true;
    }
    private void TextDisable5000()
    {
        Message5000.enabled = false;
    }
    private void TextEnable10000()
    {
        Message10000.enabled = true;
    }
    private void TextDisable10000()
    {
        Message10000.enabled = false;
    }
    private void TextWinner()
    {
        winner.enabled = true;
    }
}
