using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XboxControllerControls;

public class RapidFire : MonoBehaviour {

    public float maxSpeed = 40f;
    public Rigidbody2D smallBullet;
    public float fireHold = 0.0f;
    public float rapidFireCooldown = 1;
    public GameObject power;
    public float charge_speed;
    public Image rapidCdDisplay;
    private MetricManager mm;

    private Player player;


    private float shotTimer;
    private bool shot = false;
    private int buttonCheck = 0;

    public AudioSource audios;

    void Start()
    {
        player = transform.GetComponentInParent<Player>();
        shotTimer = 0;
        //rapidCdDisplay.fillAmount = 1;
        mm = GameObject.Find("EventSystem").GetComponent<MetricManager>();

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

        if (player.Actions.LeftTrigger.WasPressed && !shot)
        {
            buttonCheck = 1;
        }

        if (fireHold <= maxSpeed && buttonCheck == 1)
        {
            fireHold += Time.deltaTime * charge_speed * buttonCheck;
            scaled_power += fireHold / maxSpeed;
            power.transform.localScale = new Vector3(scaled_power, power.transform.localScale.y, power.transform.localScale.z);
        }

        if (player.Actions.LeftTrigger.WasReleased && !shot && buttonCheck == 1)
        {
            for (int i = 0; i < 15; i++)
            {
                Rigidbody2D bulletInstance = Instantiate(smallBullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 40f))) as Rigidbody2D;
                bulletInstance.velocity = transform.right * fireHold * Random.Range(.8f, 1.2f);
                Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            fireHold = 0.0f;
            shotTimer = rapidFireCooldown;
            scaled_power = 0;
            power.transform.localScale = new Vector3(scaled_power, power.transform.localScale.y, power.transform.localScale.z);
            buttonCheck = 0;
            rapidCdDisplay.fillAmount = 1;
            mm.AddToMetric1(1);
            GetComponent<AudioSource>().Play();
        }

    }
}
