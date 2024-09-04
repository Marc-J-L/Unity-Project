using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject main;
    public GameObject tut;
    public GameObject score;
    public GameObject over;

    public Text nowScoreText;
    public Text bestScoreText;
    public GameObject NewScore;

    public Image Medal;

    public List<Sprite> medals;

    public GameObject bird;

    public bool isGameReady = false;
    public bool isGameStart = false;

    public Text scoreText;
    public AudioController audioController;

    //public void Start()
    //{
    //    PlayerPrefs.SetInt("bestScore", 0);
    //}

    public void PlayBtnClick()
    {
        Tools.Ins.HideUI(main);
        Tools.Ins.ShowUI(tut);
        Tools.Ins.ShowUI(score);
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();

        bird.GetComponent<birdFlay>().ChangeState(true);
        isGameReady = true;
    }

    private void Update()
    {
        if (!isGameReady) return;
        if (isGameStart) return;
        if (Input.GetMouseButtonDown(0))
        {
            Tools.Ins.HideUI(tut);
            //tut.GetComponent<UIManage>().HideUI();
            
            bird.GetComponent<birdFlay>().Fly();
            bird.GetComponent<birdFlay>().ChangeState(true, true);
            isGameStart = true;
        }
    }
    /// <summary>
    /// game over
    /// </summary>
    public void GameOver()
    {
        if (!isGameStart) return;

        isGameReady = false;
        isGameStart = false;

        audioController.StopBgm();
        audioController.PlaySfx(audioController.death);

        Camera.main.transform.DOShakePosition(1, 2);
        
        GameObject.Find("columnController").GetComponent<ColumnController>().StopMove();
        GameObject.Find("background").GetComponent<BgControl>().isMove = false;
        GameObject.Find("allland").GetComponent<BgControl>().isMove = false;

        Tools.Ins.ShowUI(over);

        //get score
        int score = int.Parse(scoreText.text);
        //Medal.sprite = test;
        if(score >= 15)
        {
            Medal.sprite = medals[3];
        }else if(score >= 10)
        {
            Medal.sprite = medals[2];
        }else if(score >= 5)
        {
            Medal.sprite = medals[1];
        }else if(score >= 3)
        {
            Medal.sprite = medals[0];
        }
        else
        {
            Medal.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
            NewScore.SetActive(true);

        }

        nowScoreText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
        

    }

    /// <summary>
    /// get point
    /// </summary>
    public void GetScore()
    {
        if (!isGameStart) return;
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
        audioController.PlaySfx(audioController.checkpoint);
    }

    /// <summary>
    /// restart 
    /// </summary>
    public void Restart()
    {

        SceneManager.LoadScene("SampleScene");
        audioController.PlayBgm();
    }
}
