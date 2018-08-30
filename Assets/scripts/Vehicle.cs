using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vehicle : MonoBehaviour {

    
    public Sprite[] vehicleSprites;

   // public Suspect suspect;


    //Highway variables
    public Vector2 speed = new Vector2(3, 0);
    public float lifetime;

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    private float speedVariation;
    private float time;
    private bool isSuspect = false;

    //Pulled over variables
    private bool pulledOver = false;

    // Use this for initialization
    void Start () {

        //Varies the speed a little for realism, 1.2f is a good default
        speedVariation = Random.Range(0, 1.2f);

        //Actual speed of vehicles
        movement = new Vector2(-(speed.x + speedVariation), speed.y);

        //Sets a random sprite to this object
        this.GetComponent<SpriteRenderer>().sprite = vehicleSprites[Random.Range(0, vehicleSprites.Length - 1)];

        //Marked car for a suspect
        if (Random.Range(0, 3) == 2)
        {
            isSuspect = true;
            this.GetComponent<SpriteRenderer>().sprite = vehicleSprites[4];
        }

        //Assigning traits to suspect
        if (isSuspect)
        {
            //suspect.buildSuspect();
        }

        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        //Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        if (!pulledOver)
        {
            //Move the game object
            rigidbodyComponent.velocity = movement;

            //Lifetime of the cars on the highway
            if (time > lifetime)
            {
                if (this.gameObject.name == "Vehicle(Clone)")
                {
                    Destroy(this.gameObject, 0);
                }
                time = 0;//reset time for lifetime
            }

            //Deletes the cars not pulled over
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.name == "pullover")
            {
                //Object.Destroy(this, 0);
                lifetime = 0;
            }
        }

        if (pulledOver)
        {
            //Sets the speed to zero when pulled over
            rigidbodyComponent.velocity = new Vector2(0,0);

            //Deletes the object from the pullover scene
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name != "pullover")
            {
                Destroy(this.gameObject, 0);
            }
        }
    }

    void OnMouseDown()
    {
        if (!pulledOver)
        {
            float myScale = 1.9f;
            transform.localScale = new Vector3(myScale, myScale, myScale);
            this.transform.position = new Vector3(-5, 10.9f, 0);
            SceneManager.LoadScene("pullover", LoadSceneMode.Single);
        }

        pulledOver = true;
    }

    public bool getIsSuspect()
    {
        return isSuspect;
    }
}
