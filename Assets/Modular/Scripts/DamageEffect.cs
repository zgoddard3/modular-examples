using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{

    [Range(0f, 1f)]
    public float fade = 0.1f;

    public void Update() {
        HUD._instance.overlay.color *= 1f - fade*Time.deltaTime;
        HUD._instance.overlay.color += Color.clear*fade*Time.deltaTime;
    }

    public void Damage(float damage) {
        HUD._instance.overlay.color = Color.red;
    }
}
