using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private CharacterController charController;
public float gravity=-9.8f;
    public float speed=6.0f;
    // Start is called before the first frame update
    void Start()
    {
        charController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX=Input.GetAxis("Horizontal")*speed;
        float deltaZ=Input.GetAxis("Vertical")*speed;
        Vector3 movement=new Vector3(deltaX,0,deltaZ);
        movement=Vector3.ClampMagnitude(movement,speed);
        movement.y=gravity;
        movement *= Time.deltaTime;
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        Quaternion cameraRotation = Quaternion.LookRotation(cameraForward);
        movement = cameraRotation * movement;
        charController.Move(movement);
    }
}
