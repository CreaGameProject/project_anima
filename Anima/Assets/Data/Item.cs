using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    //所持品(ミッション内で使用するもの。(弾薬を含む。))

    //アイコン
    [SerializeField] private Sprite icon;
    public Sprite Icon { get { return icon; } }

    //数
    [SerializeField] private int number;
    public int Number { get { return number; }set { number = value < 0 ? 0 : value; } }
}
