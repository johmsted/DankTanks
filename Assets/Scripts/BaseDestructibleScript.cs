using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


public class BaseDestructibleScript : MonoBehaviour
{
    public List<string> tags;
    public PhysicsMaterial2D chunkPhysicsMaterial;
    public CircleCollider2D explosion;
    public CircleCollider2D smallExplosion;
    public CamShake cam_shake;
	public Kino.AnalogGlitch anal_glitch;
    public float analStrength;


    virtual public void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if(collisionObject.gameObject.tag == "projectile")
        {
            cam_shake.shakeAmount = .05f;
            cam_shake.addDuration(.3f);
            Destroy(gameObject);
            CircleCollider2D explosion_instance = Instantiate(explosion, collisionObject.transform.position, collisionObject.transform.rotation) as CircleCollider2D;
            Destroy(collisionObject.gameObject);
			anal_glitch.camEffect (analStrength);
        }
        if (collisionObject.gameObject.tag == "explosion" ||  collisionObject.gameObject.tag == "smallExplosion")
        {
            Destroy(gameObject);
            Destroy(collisionObject.gameObject, .1f);
        }
        if (collisionObject.gameObject.tag == "smallProjectile")
        {
            cam_shake.shakeAmount = .025f;
            cam_shake.addDuration(.2f);
            Destroy(gameObject);
            CircleCollider2D explosion_instance = Instantiate(smallExplosion, collisionObject.transform.position, collisionObject.transform.rotation) as CircleCollider2D;
            Destroy(collisionObject.gameObject);
            anal_glitch.camEffect(analStrength);
        }
    }

    virtual public void copyFrom(BaseDestructibleScript source)
    {
        tags = source.tags;
        chunkPhysicsMaterial = source.chunkPhysicsMaterial;
        explosion = source.explosion;
        smallExplosion = source.smallExplosion;
        cam_shake = source.cam_shake;
		anal_glitch = source.anal_glitch;
        
        GetComponent<Collider2D>().sharedMaterial = chunkPhysicsMaterial;
    }
}
