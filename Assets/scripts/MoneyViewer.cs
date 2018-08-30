using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyViewer : MonoBehaviour {

    public Text money;

	// Use this for initialization
	void Start () {
        money.text = "Money: " + PlayerPrefs.GetInt("money", 0);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
