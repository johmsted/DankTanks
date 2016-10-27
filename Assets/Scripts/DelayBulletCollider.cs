using UnityEngine;
using System.Collections;

public class DelayBulletCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.tag = "Untagged";
	}
	
	// Update is called once per frame
	void Update () {
        float timer = .012f;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            gameObject.tag = "projectile";
        }

	}
}
