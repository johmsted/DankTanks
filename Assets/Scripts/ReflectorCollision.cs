using UnityEngine;
using System.Collections;

public class ReflectorCollision : MonoBehaviour {

    public float max_health = 100f;
    public float curr_health = 0f;
    public GameObject health;
    private float collision_timer;
    private float collision_cooldown = .15f;

    // Use this for initialization
    void Start()
    {
        curr_health = max_health;
        collision_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (curr_health <= 0)
        {
            Destroy(gameObject);
        }

        collision_timer -= Time.deltaTime;
        
    }

    virtual public void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "projectile" || collisionObject.gameObject.tag == "explosion")
        {
            if (collision_timer <= 0)
            {
                curr_health -= 25f;
                float health_scale = curr_health / max_health;
                SetHealthBar(health_scale);
                collision_timer = collision_cooldown;
            }
        }
    }
    public void SetHealthBar(float health_scale)
    {
        health.transform.localScale = new Vector3(health_scale, health.transform.localScale.y, health.transform.localScale.z);
    }
}
