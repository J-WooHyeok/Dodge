using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버시 활성화할 텍스트 게임 오브젝트
    public Button restart;
    public Text timeText;  // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText;// 최고 기록을 표시할 텍스트 컴포넌트
            
    float surviveTime;              // 생존시간     
    bool isGameover;                // 게임오버 상태

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;            //생존 시간 초기화
        isGameover = false;         //게임오버 상태 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);
         
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time : " + (int)bestTime;
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}