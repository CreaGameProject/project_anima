using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Material",menuName = "CreateMaterial")]
public class Material : ScriptableObject
{
    //素材(ミッションで獲得するもの。(所持金を含む))

    //アイテム名
    [SerializeField] private MaterialName materialName;

    //アイコン
    [SerializeField] private Sprite icon;

    //数
    [SerializeField] private int number;

    private char cord;
    public byte Cord { private get { return (byte)cord; } set { cord = (char)value; } }


    //プロパティ
    public MaterialName Name { get { return materialName; } }
    public Sprite Icon { get { return icon; } }
    public int Number { get { return number; } set { number = value < 0 ? 0: value; } }


    //セーブ＆ロード
    public void Save()
    {
        PlayerPrefs.SetInt("m" + cord, number);
    }

    public void Load()
    {
        PlayerPrefs.GetInt("m" + cord, 0);
    }
}
