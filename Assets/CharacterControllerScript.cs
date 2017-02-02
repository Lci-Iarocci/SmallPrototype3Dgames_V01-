using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float rotSpeed = 15.0f;
    public float jumpSpeed = 15.0f;
    public float jumpScaler = 5f;
    public float fallRate = -1.5f;
    public float gravity = -9.8f;
    private CharacterController cc;
    private float ySpeed;

    private bool isSpaced = false;
    private GameObject currentlyOn;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isSpaced == false)
            {

                isSpaced = true;
            }
            else
            {

                isSpaced = false;
            }
        }
        if (isSpaced == false)
        {
            float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
            float deltaZ = Input.GetAxis("Vertical") * moveSpeed;

            Vector3 movement = new Vector3(0, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            if (cc.isGrounded)
            {


            }
            else
            {
                ySpeed += gravity * jumpScaler * Time.deltaTime;

                if (ySpeed < gravity)
                {
                    ySpeed = gravity;
                }
            }

            transform.Rotate(new Vector3(0, deltaX * rotSpeed * Time.deltaTime, 0));
            movement.y = ySpeed;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            cc.Move(movement);

        }
        else
        {
            transform.SetParent(currentlyOn.transform);
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        currentlyOn = hit.gameObject;
        Debug.Log(currentlyOn.transform.name);

    }
}
