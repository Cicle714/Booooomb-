using System.IO;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapMaker : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;　//プレイヤー
    [SerializeField]
    private GameObject Block1;　//ブロック
    [SerializeField]
    private List<GameObject> Arrow;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string csvFile = "Map.csv";　//csvの名前

        string[] lines = File.ReadAllLines(csvFile);　//ファイルの読み込み

        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue; //何も描いていなかったらスキップ
            string[] values = lines[i].Split(',');　//CSVのi行目を「,」で区切ってvalues[]に代入
            for (int j = 0; j < values.Length; j++)
            {
                if (string.IsNullOrWhiteSpace(values[j])) continue;

                int.TryParse(values[j], out int num);　//文字の状態から数値に変換

                switch (num) {
                    case 0:　//プレイヤー生成
                        Instantiate(PlayerObject, transform.position + ObjPos(j, i), Quaternion.identity);
                    break;　
                    case 1: //ブロック生成
                        Instantiate(Block1, transform.position + ObjPos(j,i), Quaternion.identity);
                    break;
                    case 2:
                        Instantiate(Arrow[0], transform.position + ObjPos(j,i),Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(Arrow[1], transform.position + ObjPos(j, i), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(Arrow[2], transform.position + ObjPos(j, i), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(Arrow[3], transform.position + ObjPos(j, i), Quaternion.identity);
                        break;
                }
                

            }

           
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 ObjPos(int x,int y)
    {
        return new Vector2(x, y);
    }
    

}
