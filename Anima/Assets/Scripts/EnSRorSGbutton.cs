using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnSRorSGbutton : MonoBehaviour {

    public GameObject canvas;
    public GameObject SR;
    public GameObject SG;

	public void SRButton()
    {
        canvas.SetActive(false);
        SR.SetActive(true);
    }

    public void SGButton()
    {
        canvas.SetActive(false);
        SG.SetActive(true);
    }

    public void Back()
    {
        SceneManager.LoadScene("WeaponManager");
    }

    public void Back2()
    {
        SG.SetActive(false);
        SR.SetActive(false);
        canvas.SetActive(true);
    }
}
