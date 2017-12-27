using UnityEngine;
using System.Collections;

public class ShockwaveSpread : MonoBehaviour {
    public float spread_time;
    private float countdown;

	// Use this for initialization
	void Start () {
        countdown = spread_time;
	}
	
	// Update is called once per frame
	void Update () {
	    countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            Destroy(gameObject);
        }
        transform.localScale = new Vector3(transform.localScale.x * 1.175f, transform.localScale.y * 1.175f, transform.localScale.z * 1.175f);
	}
}
