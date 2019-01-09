using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnOrSeButtons : MonoBehaviour
{
    

    public void Onclick()
    {
        Debug.Log("EnhanceButton clicked");
        SceneManager.LoadScene("WeaponEnhance");
    }
    public void Onclick2()
    {
        SceneManager.LoadScene("WeaponSelect");
    }

    public void Onclick3()
    {

        //シーン"home"の名前を一致させてね
        SceneManager.LoadScene("Base");
    }
}