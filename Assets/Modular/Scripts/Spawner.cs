using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public void Spawn() {
        GameObject o = GameObject.Instantiate(prefab, transform.position, transform.rotation);
    }
}
