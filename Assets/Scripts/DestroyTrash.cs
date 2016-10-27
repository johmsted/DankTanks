﻿using UnityEngine;
using System.Collections;

public class DestroyTrash : MonoBehaviour
{
    virtual public void OnCollisionEnter2D(Collision2D collisionObject)
    { 

        if(collisionObject.gameObject.tag == "projectile")
        {
            Destroy(collisionObject.gameObject);
}
    }
}