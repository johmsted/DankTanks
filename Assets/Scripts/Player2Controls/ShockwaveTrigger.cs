using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace XboxControllerControls
{
    public class ShockwaveTrigger : MonoBehaviour
    {
        //***Goes on players***
        // Use this for initialization
        public GameObject shockwave;
        public float shockwave_cooldown;
        public Image shockwaveCdDisplay;

        private float cooldown;
        private Player player;

        void Start()
        {
            player = transform.GetComponent<Player>();
            cooldown = 0;
        }

        // Update is called once per frame
        void Update()
        {
            cooldown -= Time.deltaTime;
            if(player.Actions.BButton.WasPressed && cooldown <= 0)
            {
                Instantiate(shockwave, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
                cooldown = shockwave_cooldown;
                shockwaveCdDisplay.fillAmount = 1;
            }
        }
    }
}
