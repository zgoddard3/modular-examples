using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hardcoded {

public class Destructible : MonoBehaviour
{
    public float health = 3f;

    void FixedUpdate() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}

}


