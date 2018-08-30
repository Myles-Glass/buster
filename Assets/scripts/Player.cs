using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int money;
    public Text moneyText;

	// Use this for initialization
	void Start () {
        moneyText.text = "Money: " + getMoney();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
     * Adds money to the playerprefs and sets the text
     * 
     */
    public void addMoney(int amountToAdd)
    {
        money = getMoney() + amountToAdd;
        PlayerPrefs.SetInt("money", money);
        moneyText.text = "Money: " + getMoney();
    }

    /*
     * getter for money
     * 
     */
    public int getMoney()
    {
        return PlayerPrefs.GetInt("money", 0);
    }
}
