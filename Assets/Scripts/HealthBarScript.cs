using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
    public float max_health = 100f;
    public float curr_health = 0f;
    public GameObject health;

	// Use this for initialization
	void Start () {
        curr_health = max_health;
	}
	
	// Update is called once per frame
	void Update () {
	    if(curr_health == 0)
        {
            Destroy(gameObject);
        }
	}

    virtual public void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "projectile" || collisionObject.gameObject.tag == "explosion")
        {
            curr_health -= 25f;
            float health_scale = curr_health / max_health;
            SetHealthBar(health_scale);
            Destroy(collisionObject.gameObject);
        }
    }
    public void SetHealthBar(float health_scale)
    {
        health.transform.localScale = new Vector3(health_scale, health.transform.localScale.y, health.transform.localScale.z);
    }
}
