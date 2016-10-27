using UnityEngine;
using System.Collections;

public class Aim_Script : MonoBehaviour
{
    public Object turret;
    public int aimspeed = 80;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && transform.rotation.z < 180)
            transform.Rotate(Vector3.forward * Time.deltaTime * aimspeed);

        if (Input.GetKey(KeyCode.RightArrow) && transform.rotation.z > 0)
            transform.Rotate(Vector3.back * Time.deltaTime * aimspeed);

    }
}
