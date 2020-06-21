using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeTex,scoreText,coinTEXT;
    public bool DelTime = false;
    private float Timer;//计时s
    public string Key = "Timer";
  
    // Start is called before the first frame update
    void Start()
    {
        //Timer = PlayerPrefs.GetFloat(Key,0);
        Timer = 0;
        Time.timeScale = 1;
    }
    public void StartDelTime()
    {
        DelTime = true;
        Timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(DelTime)
        {
            Timer += Time.deltaTime;
            timeTex.text = GetTime();
        }
    }
    //private void OnDestroy()
    //{
    //    PlayerPrefs.SetFloat(Key, Timer);
    //}
    private string GetTime()
    {
        string timestr="";
        int min = (int)(Timer / 60);
        int hour = (int )(min /60);
        if (hour > 0)
            timestr += hour + ":";
        else
            timestr += "00:";
        min %= 60;
        if (min > 0)
            timestr += min + ":";
        else
            timestr += "00:";
        return timestr + (int)(Timer % 60);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void BackToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main");
    }
    public void Pause(int scale)
    {
        Time.timeScale = scale;
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    internal void EndGame(int getcoin)
    {
        int score = (int)Timer * 10;
        score += getcoin * 10;
        scoreText.text = "Score:" + score;
        coinTEXT.text = "Get Coin:" + getcoin;
    }
}
