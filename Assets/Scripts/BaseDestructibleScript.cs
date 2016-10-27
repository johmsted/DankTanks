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


    virtual public void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if(collisionObject.gameObject.tag == "projectile")
        {
            Destroy(gameObject);
            CircleCollider2D explosion_instance = Instantiate(explosion, collisionObject.transform.position, collisionObject.transform.rotation) as CircleCollider2D;
            Destroy(collisionObject.gameObject);
        }
        if (collisionObject.gameObject.tag == "explosion")
        {
            Destroy(gameObject);
            Destroy(collisionObject.gameObject, .1f);
        }
    }

    virtual public void copyFrom(BaseDestructibleScript source)
    {
        tags = source.tags;
        chunkPhysicsMaterial = source.chunkPhysicsMaterial;
        explosion = source.explosion;
        
        GetComponent<Collider2D>().sharedMaterial = chunkPhysicsMaterial;
    }
}
