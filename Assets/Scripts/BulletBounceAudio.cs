using UnityEngine;
using System.Collections;

public class BulletBounceAudio : MonoBehaviour {
    virtual public void OnCollisionEnter2D(Collision2D collisionObject)
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().pitch += .2f;
    }
}
