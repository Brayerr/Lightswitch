using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float senX;
    public float senY;

    public Transform orientation;

    float camXrotation;
    float camYrotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

        
        camYrotation += mouseX;
        camXrotation -= mouseY;

        camXrotation = Mathf.Clamp(camXrotation, -60f, 0f);

        transform.rotation = Quaternion.Euler(camXrotation, camYrotation, 0);
        orientation.rotation = Quaternion.Euler(0, camYrotation, 0);
    }
}
