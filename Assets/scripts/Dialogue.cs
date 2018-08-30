using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{

    //public string stringToEdit = "Hello World\nI've got 2 lines...";
    public Rect windowRect = new Rect(20, 20, 120, 50);

    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "pullover")
        {
            //stringToEdit = GUI.TextArea(new Rect(100, 100, 200, 200), stringToEdit, 200);
            windowRect = GUI.Window(0, windowRect, null, "My Windowghgfhjfghjg fghjfghj fghjfghjfg fghjfgjh fghjgfh");

        }
    }
}
