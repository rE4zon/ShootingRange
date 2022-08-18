using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitiivty = 100f;
    [SerializeField] Transform playerBody;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitiivty * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitiivty * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
