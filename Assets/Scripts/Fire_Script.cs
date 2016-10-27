using UnityEngine;
using System;

public class Fire_Script : MonoBehaviour
{
	public float maxSpeed = 40f;
	public Rigidbody2D bullet;
	public string fireKey;
	public float fireHold = 0.0f;
	public float shotTimeLimit = 0.5f;
    public GameObject power;
    public GameObject LockSign;

	private float shotTimer;
	private bool shot = false;

	void Start()
	{
		shotTimer = shotTimeLimit;
        LockSign.GetComponent<SpriteRenderer>().enabled = false;
	}

	void Update()
	{
		shotTimer -= Time.deltaTime;

        float scaled_power = 0;

		shot = !(shotTimer < 0);

		if (Input.GetKey (fireKey)) 
		{	
			if(fireHold <= maxSpeed)
				fireHold += Time.deltaTime * 10;
                scaled_power += fireHold / maxSpeed;
                power.transform.localScale = new Vector3(scaled_power, power.transform.localScale.y, power.transform.localScale.z);
        }

        if (Input.GetKeyUp (fireKey) && !shot)
		{
			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 40f))) as Rigidbody2D;
			bulletInstance.velocity = transform.right * fireHold;
			Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
			fireHold = 0.0f;
			shotTimer = shotTimeLimit;
            power.transform.localScale = new Vector3(scaled_power, power.transform.localScale.y, power.transform.localScale.z);
        }
        
        if (!shot)
        {
            LockSign.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            LockSign.GetComponent<SpriteRenderer>().enabled = true;
        }

    }
}