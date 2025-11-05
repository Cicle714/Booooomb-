using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text GameTime;

    private float CountDown; //残りタイマー
    [SerializeField]
    private List<float> MaxTime;　//タイマーのステージ毎の最初値
    [SerializeField]
    private int StageNum; //現在のステージ
    private bool GameOver = false; //ゲームの終了状態
    public bool gameOver
    {
        get { return GameOver; }
        set { GameOver = value; }
    }
    private bool Clear = false;
    public bool clear
    {
        get { return Clear; }
        set { Clear = value; }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CountDown = MaxTime[StageNum];
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        if(CountDown <= 0)
        {
            GameOver = true;
        }

        GameTime.GetComponent<Text>().text = "" + (int)CountDown;
    }
}
