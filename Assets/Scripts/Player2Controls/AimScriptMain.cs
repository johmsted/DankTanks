using UnityEngine;
using System.Collections;
using InControl;

namespace XboxControllerControls
{
    public class AimScriptMain : MonoBehaviour
    {
        public Object turret;
        public int aimspeed = 80;
        private Player player;

        public GameObject shield;
        public float shield_cooldown;
        private float shield_timer;

        // Use this for initialization
        void Start()
        {
            player = transform.GetComponentInParent<Player>();
            shield_timer = 0;
        }

        // Update is called once per frame
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

            
            transform.Rotate(Vector3.forward * Time.deltaTime * -player.Actions.MoveAim * aimspeed);
            

            shield_timer -= Time.deltaTime;

            if (player.Actions.XButton.WasPressed && shield_timer <= 0)
            {
                                                                                                        //value 0 to 1
                GameObject shield_instance = Instantiate(shield, new Vector3(transform.position.x + (transform.rotation.z-.7f)*-4.5f, transform.position.y + 1.25f, transform.position.z), transform.rotation) as GameObject;
                shield_timer = shield_cooldown;
                
            }
            Debug.Log(transform.rotation.z);


        }
    }
}
