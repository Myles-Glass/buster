using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

    public GameObject vehicleLaneOne;
    public GameObject vehicleLaneTwo;
    
    public float minTime = 1.0f;
    public float maxTime = 10.0f;

    private float timeLaneOne;
    private float timeLaneTwo;
    private float spawnTimeLaneOne;
    private float spawnTimeLaneTwo;


    // Use this for initialization
    void Start () {
        SetRandomTimeLaneOne();
        SetRandomTimeLaneTwo();
        timeLaneOne = minTime;
        timeLaneTwo = minTime;
    }
	
	// Update is called once per frame
	void Update () {

        //Counts up
        timeLaneOne += Time.deltaTime;
        timeLaneTwo += Time.deltaTime;

        //Check if its the right time to spawn the object for Lane One
        if (timeLaneOne >= spawnTimeLaneOne)
        {
            SpawnLaneOne();
            SetRandomTimeLaneOne();
        }

        //Check if its the right time to spawn the object for Lane One
        if (timeLaneTwo >= spawnTimeLaneTwo)
        {
            SpawnLaneTwo();
            SetRandomTimeLaneTwo();
        }

    }

    void SpawnLaneOne()
    {
        timeLaneOne = 0;
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(vehicleLaneOne, new Vector2(15, -3), Quaternion.identity);
        
    }

    void SpawnLaneTwo()
    {
        timeLaneTwo = 0;
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(vehicleLaneTwo, new Vector2(15, -1.73f), Quaternion.identity);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTimeLaneOne()
    {
        spawnTimeLaneOne = Random.Range(minTime, maxTime);
    }
    
    //Sets the random time between minTime and maxTime
    void SetRandomTimeLaneTwo()
    {
        spawnTimeLaneTwo = Random.Range(minTime, maxTime);
    }
}
