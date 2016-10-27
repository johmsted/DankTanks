using UnityEngine;
using System.Collections;
using XboxControllerControls;

public class RestartLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || gameObject.GetComponent<Player>().Actions.Back.WasPressed)
            Application.LoadLevel(0); //or whatever number your scene is
    }
}
