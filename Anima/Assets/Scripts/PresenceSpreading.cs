using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    memo...

    1. 障害物マップ生成
    2. 認識範囲生成   ←別スクリプト
        (認識範囲内)
            隠密度から認識判定
            (発見)
                存在収束
            (未発見)
                存在拡散    ←ここでやる
        (範囲外)
            存在拡散    ←ここでやる

    void PresenceSpread()呼び出し、拡散度、拡散マップを生成し、変数として呼び出し可能にする。
    認識範囲外且つ障害物のない場所にプレイヤーを拡散させる。
    →obstacleMap, recognitionRange から PresenceMap生成
    戦闘中に草むらに隠れるなど、認識範囲内で見失う場合にシームレスに行動をつなげる。
    例えば、草むらに隠れた敵は実際には認識できないがそこにいることはわかってるので攻撃を仕掛ける。

    必要な計算式
    ・拡散度
    ・プレイヤー拡散式

    public関数・変数
    public void PresenceSpread()
    public float[,] presenceMap
    public float spread

    */

public class PresenceSpreading : MonoBehaviour
{
    //public関数変数
    public float[,] presenceMap;
    public float spread;

    public void PresenceSpread()
    {
        presenceMap = new float[mapRange.x, mapRange.y];
        spread = 0;
    }



    //インスタンス生成
    MapPropertiesDefiner mapPropertiesDefiner = new MapPropertiesDefiner();
    InfluenceMap influenceMap;

    //読み込み変数
    float[,] recognitionRange;
    float[,] obstacleMap;
    Vector2Int mapRange;
    bool discovery;

    private void Awake()
    {
        mapRange = mapPropertiesDefiner.mapRange;
        influenceMap = new InfluenceMap(mapRange.x, mapRange.y);
        obstacleMap = new float[mapRange.x, mapRange.y];

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

}
