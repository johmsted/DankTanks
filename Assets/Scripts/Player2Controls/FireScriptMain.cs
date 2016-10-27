using UnityEngine;
using System;
using InControl;

namespace XboxControllerControls {
    public class FireScriptMain : MonoBehaviour
    {
        public float maxSpeed = 40f;
        public Rigidbody2D bullet;
        public float fireHold = 0.0f;
        public float shotTimeLimit = 0.5f;
        public GameObject power;
        public GameObject LockSign;
        public float charge_speed;

        private Player player;


        private float shotTimer;
        private bool shot = false;
        private int buttonCheck = 0;

        void Start()
        {
            player = transform.GetComponentInParent<Player>();
            shotTimer = shotTimeLimit;
            LockSign.GetComponent<SpriteRenderer>().enabled = false;
        }

        void Update()
        {


            if (player == null)
            {
                player = transform.GetComponentInParent<Player>();
                if (player == null)
                {
                    return;
                }
            }

            


            shotTimer -= Time.deltaTime;

            float scaled_power = 0;

            shot = !(shotTimer < 0);

			if (player.Actions.Fire.WasPressed)
            {
                buttonCheck = 1;
            }

            if (fireHold <= maxSpeed && buttonCheck == 1)
            {
                fireHold += Time.deltaTime * charge_speed * buttonCheck;
                scaled_power += fireHold / maxSpeed;
                power.transform.localScale = new Vector3(scaled_power, power.transform.localScale.y, power.transform.localScale.z);
            }

			if (player.Actions.Fire.WasReleased && !shot)
            {
                Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 40f))) as Rigidbody2D;
                bulletInstance.velocity = transform.right * fireHold;
                Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                fireHold = 0.0f;
                shotTimer = shotTimeLimit;
                scaled_power = 0;
                power.transform.localScale = new Vector3(scaled_power, power.transform.localScale.y, power.transform.localScale.z);
                buttonCheck = 0;
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
}