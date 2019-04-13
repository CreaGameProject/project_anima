using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Material",menuName = "CreateMaterial")]
public class Material : ScriptableObject
{
    //素材(ミッションで獲得するもの。(所持金を含む))

    //アイコン
    [SerializeField] private Sprite icon;
    public Sprite Icon { get { return icon; } }

    //数
    [SerializeField] private int number;
    public int Number { get { return number; } set { number = value < 0 ? 0: value; } }
}
