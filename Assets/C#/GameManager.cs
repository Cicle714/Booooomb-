using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private bool Clear = false; //クリアしたか
    public bool clear
    {
        get { return Clear; }
        set { Clear = value; }
    }

    [SerializeField]
    private Image BlackImage; //暗転用

    [SerializeField]
    private Text ClearText;　//クリア表示
    [SerializeField]
    private Text gameOverText;　 //失敗表示

    private float GameOverCount = 0;
    private float BlackOutTime = 2;


    void Start()
    {
        BlackImage = BlackImage.GetComponent<Image>();
        BlackImage.color = new Color(0, 0, 0, 1);
        CountDown = MaxTime[StageNum];　//現在のステージの制限時間
    }

    // Update is called once per frame
    void Update()
    {
        if (BlackImage.color.a > 0 && !GameOver)
            BlackImage.color -= new Color(0, 0, 0, 1 * Time.deltaTime / 2);　//暗転


        if (!GameOver)
        {
           CountDown -= Time.deltaTime; //制限時間のカウントダウン
            
        }

        if(GameOver)
        {
            if (Clear)
            {
                ClearText.gameObject.SetActive(true);　//クリア表示
            }
            else
            {
                gameOverText.gameObject.SetActive(true);    //失敗表示
            }
            GameOverCount += Time.deltaTime;
            if(GameOverCount > BlackOutTime)
            {
                BlackImage.color += new Color(0, 0, 0, 1 * Time.deltaTime / 2);　//暗転
                if(BlackImage.color.a >= 1)
                {
                    SceneManager.LoadScene("Title");
                }
            }


        }
            
        if(CountDown <= 0)
        {
            CountDown = 0;
            GameOver = true;　//ゲーム終了
        }

        GameTime.GetComponent<Text>().text = "" + CountDown.ToString("F1");　//カウントの表示
    }
}
