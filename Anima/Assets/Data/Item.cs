using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    //所持品(ミッション内で使用するもの。(弾薬を含む。))

    //アイテム名
    [SerializeField] private ItemName itemName;

    //アイコン
    [SerializeField] private Sprite icon;

    //数
    [SerializeField] private int number;

    private char cord;
    public byte Cord { private get { return (byte)cord; } set { cord = (char)value; } }


    //プロパティ
    public ItemName Name { get { return itemName; } }
    public Sprite Icon { get { return icon; } }
    public int Number { get { return number; }set { number = value < 0 ? 0 : value; } }


    //セーブ＆ロード
    public void Save()
    {
        PlayerPrefs.SetInt("i" + cord, number);
    }

    public void Load()
    {
        PlayerPrefs.GetInt("i" + cord, 0);
    }
}
