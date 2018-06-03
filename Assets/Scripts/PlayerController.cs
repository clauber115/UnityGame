using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveVel;
    //public Rigidbody theRB;
    public CharacterController controller;
    public float jumpForce;

    private Vector3 moveDir;
    public float gravityScale;

	// Use this for initialization
	void Start () {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}

    //Update is called once per frame
    void Update()
    {
        //don't put movement here to avoid jerkiness in motion
    }
    // LateUpdate is called after every Update()
    void LateUpdate()
    {
        /*theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveVel, theRB.velocity.y, Input.GetAxis("Vertical") * moveVel);

        if (Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }*/

        //moveDir = new Vector3(Input.GetAxis("Horizontal") * moveVel, moveDir.y, Input.GetAxis("Vertical") * moveVel);

        //Move by camera orientation
        //but don't fuck up gravity
        float yStore = moveDir.y;
        moveDir = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDir = moveDir.normalized * moveVel;
        moveDir.y = yStore; //this saves gravity from getting normalized

        if (controller.isGrounded)
        {
            moveDir.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpForce;
            }
        }

        moveDir.y = moveDir.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDir * Time.deltaTime);
    }
}