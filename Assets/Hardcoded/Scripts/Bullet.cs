using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hardcoded
{

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifespan = 5f;
    public float damage = 1f;
    private new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.TransformVector(Vector3.forward*speed);
    }

    void FixedUpdate() {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Destructible destructible = collision.gameObject.GetComponent<Destructible>();
        if (destructible != null) {
            destructible.health -= damage;
        }

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null) {
            player.health -= damage;
            HUD._instance.overlay.color = Color.red;
        }
    }

}

}


