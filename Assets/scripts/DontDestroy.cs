using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public bool Default = true;
    public bool KeepClonesOnly = false;

    // Use this for initialization
    void Awake () {

        if (Default)
        {
            DontDestroyOnLoad(this.gameObject);
        }

        if (KeepClonesOnly)
        {
            if (this.gameObject.name.Contains("(Clone)"))
            {
                DontDestroyOnLoad(transform.gameObject);
            }
        }   
	}
}
