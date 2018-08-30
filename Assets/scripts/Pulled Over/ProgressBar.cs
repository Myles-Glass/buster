using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour {

    private int progress = 0;
    private int reward = 0;

    public Player player;
    public GameObject chunk1;
    public GameObject chunk2;
    public GameObject chunk3;

    // Use this for initialization
    void Start ()
    {
        removeChunks();
	}

    /*
     * Adds a chunk to the progress bar, resets after 4th win
     * 
     */
    public void addChunk()
    {
        progress = progress + 1;
        reward = 15;

        //Activate chunk 1
        chunk1.SetActive(true);

        //Activate chunk 2
        if (progress == 2)
        {
            chunk2.SetActive(true);
            reward = 50;
        }

        //Activate chunk 3
        if (progress == 3)
        {
            chunk3.SetActive(true);
            reward = 125;
        }

        //Super win
        if (progress > 3)
        {
            Debug.Log("SUPER Win!!! ", gameObject);
            removeChunks();
            reward = 300;
            player.addMoney(reward);
            SceneManager.LoadScene("highway", LoadSceneMode.Single);
        }
    }

    /*
     * Resets progress to zero and disables all chunks
     * 
     */
    public void removeChunks()
    {
        progress = 0;
        chunk1.SetActive(false);
        chunk2.SetActive(false);
        chunk3.SetActive(false);
    }

    /*
     * Getter for reward
     * 
     */
    public int getReward()
    {
        return reward;
    }
}
