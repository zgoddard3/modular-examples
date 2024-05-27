using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Hardcoded {

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 movement;
    private bool fire;
    private float cameraElevation = 0f;
    public Transform cameraTransform;
    public float sensitivity = 100f;
    public float speed = 1f;
    public Transform bulletSpawn;
    public GameObject bullet;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        movement = new Vector3(
            Input.GetAxis("Horizontal"),
            -.5f,
            Input.GetAxis("Vertical")
        );

        cameraElevation -= Input.GetAxis("Mouse Y")*Time.deltaTime*sensitivity;
        cameraElevation = Mathf.Clamp(cameraElevation, -75f, 75f);

        cameraTransform.localRotation = Quaternion.Euler(cameraElevation, 0f, 0f);
        
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.y += Input.GetAxis("Mouse X")*Time.deltaTime*sensitivity;
        transform.rotation = Quaternion.Euler(rotation);

        fire |= Input.GetMouseButtonDown(0);

        float fade = .3f;
        HUD._instance.overlay.color *= 1f - fade*Time.deltaTime;
        HUD._instance.overlay.color += Color.clear*fade*Time.deltaTime;
    }

    void FixedUpdate()
    {
        movement = transform.TransformVector(movement);
        controller.Move(movement*Time.fixedDeltaTime*speed);

        if (fire) {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            fire = false;
        }

        if (health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

}
