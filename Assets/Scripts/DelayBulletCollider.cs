using UnityEngine;
using System.Collections;

public class DelayBulletCollider : MonoBehaviour {
    float delay;
    

	// Use this for initialization
	void Start () {

        delay = .1f;
	}

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            gameObject.layer = 12;            
        }
    }
}
