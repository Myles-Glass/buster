using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitializeGame : MonoBehaviour {

    public void NewGameClick()
    {
        Initialize();
        SceneManager.LoadScene("highway", LoadSceneMode.Single);
    }

    void Initialize()
    {
        PlayerPrefs.SetInt("money", 0);
    }
}
