using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Transform playerOrientation;

    [SerializeField] private float xSens;
    [SerializeField] private float ySens;

    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime *ySens;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);

        if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.X))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (Cursor.lockState == CursorLockMode.Confined && Input.GetKeyDown(KeyCode.X))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
