using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMapGenerator : MonoBehaviour
{
    //インスタンス生成
    MapPropertiesDefiner mapPropertiesDefiner = new MapPropertiesDefiner();
    InfluenceMap influenceMap;

    //最終障害物マップ
    float[,] obstacleMap;

    //変数
    Vector2Int mapRange;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    //障害物マップ生成
    public void LoadObstacleMap()
    {

    }
}
