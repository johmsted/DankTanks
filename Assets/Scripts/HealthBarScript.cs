using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
    public float max_health = 100f;
    public float curr_health = 0f;
    public GameObject health;
    public CamShake cam_shake;
	public Kino.AnalogGlitch anal_glitch;
	public ParticleSystem blacksmoke;
	public ParticleSystem spark;
	public AudioSource audios;
    bool smokeStarted = false;
    bool sparkStarted = false;
    public float analStrength = .4f;

	// Use this for initialization
	void Start () {
        curr_health = max_health;
		blacksmoke.Stop ();
		spark.Stop ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (curr_health < 70 && !sparkStarted) {
			spark.Play ();
            sparkStarted = true;
		}

		if (curr_health < 30 && !smokeStarted) {
			blacksmoke.Play ();
            smokeStarted = true;
		}

	    if(curr_health <= 0)
        {
            //Application.LoadLevel(0);
            cam_shake.shakeDuration = 0;
            Destroy(gameObject);
        }
        
    }

    virtual public void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "projectile" || collisionObject.gameObject.tag == "explosion")
        {
            cam_shake.shakeAmount = .25f;
            cam_shake.addDuration(.60f);
            curr_health -= 25f;
            float health_scale = curr_health / max_health;
            SetHealthBar(health_scale);
            Destroy(collisionObject.gameObject);
			anal_glitch.camEffect (analStrength);
			audios.Play ();
        }
        if (collisionObject.gameObject.tag == "smallProjectile" || collisionObject.gameObject.tag == "smallExplosion")
        {
            cam_shake.shakeAmount = .15f;
            cam_shake.addDuration(.4f);
            curr_health -= 10f;
            float health_scale = curr_health / max_health;
            SetHealthBar(health_scale);
            Destroy(collisionObject.gameObject);
            anal_glitch.camEffect(analStrength);
            audios.Play();
        }
    }
    public void SetHealthBar(float health_scale)
    {
        health.transform.localScale = new Vector3(health_scale, health.transform.localScale.y, health.transform.localScale.z);
    }
}
