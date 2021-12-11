using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5;
    float lookSensitivity = 2;
    float cameraRotationLimit = 45;
    float currentCameraRotationX;
    private Camera cam;
 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        /*
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
 
        Vector3 getVel = new Vector3(xMove, 0, zMove) * speed;
        rb.velocity = getVel;
        */
        Move();
        //CameraRotate();
        CharacterRotate();
    }

    void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    void CameraRotate()
    {
        float xRotate = Input.GetAxisRaw("Mouse Y");
        float camaraRotateX = xRotate * lookSensitivity;

        currentCameraRotationX = camaraRotateX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        //cam.transform.localEulterAngles = new Vector3(currentCameraRotationX, 0, 0);
    }

    void CharacterRotate()
    {
        float yRotate = Input.GetAxisRaw("Mouse X");
        Vector3 rotateY = new Vector3(0, yRotate, 0) * lookSensitivity;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateY));
    }
}
