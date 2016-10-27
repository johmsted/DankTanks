using UnityEngine;
using System;

public class Proj_Script : MonoBehaviour
{
	public float maxSpeed = 40f;
	public Rigidbody2D bullet;
    public float shotTimer = .8f;
    public bool shot = false;

	void Update()
	{
        shotTimer -= Time.deltaTime;

        if (shotTimer < 0)
        {
            shot = false;
        }
        else
            shot = true;

		if (Input.GetKeyDown(KeyCode.Space) && !shot)
		{
			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 40f))) as Rigidbody2D;
			bulletInstance.velocity = transform.right * maxSpeed;
			Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
            shotTimer = .8f;
		}
    }
}