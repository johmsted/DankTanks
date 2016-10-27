using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using InControl;

namespace XboxControllerControls
{
    public class Platformer2DUserControlsP2 : MonoBehaviour
    {
        public float maxSpeed;
        private Player player;
        public float jump_force = 10f;
        private float jump_timer;
        public float jump_cooldown = 1f;
        private bool can_jump = false;



        void Start()
        {
            player = transform.GetComponent<Player>();
            jump_timer = 0;
        }


        void Update()
        {
            if (player == null)
            {
                player = transform.GetComponent<Player>();
                if (player == null)
                {
                    return;
                }
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(player.Actions.Move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            
            jump_timer -= Time.deltaTime;
            can_jump = jump_timer < 0;

			if (player.Actions.AButton.WasPressed && can_jump) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jump_force);
                jump_timer = jump_cooldown;
            }
            

        }
    }
}