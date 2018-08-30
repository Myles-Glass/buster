using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonChoices : MonoBehaviour {

    //Debug
    public Text DEBUGPlayerRoll;
    public Text DEBUGSuspectRoll;

    public ProgressBar progressBar;
    public Player player;
    public Suspect suspect;

    //Attributes of the driver
    private int talk;
    private int persuasion;
    private int intimidation;
    private int force;
    private int observe;

    //The roll
    private int playerRolled;
    private int suspectRolled;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DEBUGPlayerRoll.text = "Player rolled: " + playerRolled;
        DEBUGSuspectRoll.text = "Suspect has: " + suspectRolled;

    }

    private void OnRenderObject()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "pullover")
        {
            talk = suspect.getTalk();
            persuasion = suspect.getPersuasion();
            intimidation = suspect.getIntimidation();
            force = suspect.getForce();
            observe = suspect.getObserve();
        }
    }

    public void Talk()
    {
        if (numberTumbler(talk))
        {
            Debug.Log("Win!!! " + talk, gameObject);
        }
        else { Debug.Log("Fail!!! " + talk, gameObject); }
    }

    public void Persuasion()
    {
        if (numberTumbler(persuasion))
        {
            Debug.Log("Win!!! " + persuasion, gameObject);
        }
        else { Debug.Log("Fail!!! " + persuasion, gameObject); }
    }

    public void Intimidate()
    {
        if (numberTumbler(intimidation))
        {
            Debug.Log("Win!!! " + intimidation, gameObject);
        }
        else { Debug.Log("Fail!!! " + intimidation, gameObject); }
    }

    public void Force()
    {
        if (numberTumbler(force))
        {
            Debug.Log("Win!!! " + force, gameObject);
        }
        else { Debug.Log("Fail!!! " + force, gameObject); }
    }

    bool numberTumbler(int attributeNumber)
    {
        playerRolled =  Random.Range(1, 100);
        suspectRolled = attributeNumber; //Only needed this line for debug

        if (playerRolled > attributeNumber)
        {
            progressBar.addChunk();
            return true;
        }
        else
        {
            progressBar.removeChunks();
            player.addMoney(progressBar.getReward());//Adds reward money on fail
            SceneManager.LoadScene("highway", LoadSceneMode.Single);//Loads scene on fail
            return false;
        }
            
    }
}
