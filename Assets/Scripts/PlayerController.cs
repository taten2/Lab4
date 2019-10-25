using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 0.1f;
    float rotation = 0.0f;
    float rotSpeed = 2.5f;

    Vector3 direction = new Vector3(0, 0, 0);

    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0.0f;
        float moveY = 0.0f;
        float moveZ = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Walking", 1);
            moveX += speed;
        } else
        {
            anim.SetInteger("Walking", 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("WalkBack", 1);
            moveX += -speed;
        }
        else
        {
            anim.SetInteger("WalkBack", 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("TurnLeft", 1);
            //moveZ += speed;
        }
        else
        {
            anim.SetInteger("TurnLeft", 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("TurnRight", 1);
            //moveZ -= speed;
        }
        else
        {
            anim.SetInteger("TurnRight", 0);
        }

        rotation += Input.GetAxis("Horizontal") * rotSpeed;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        transform.Translate(moveZ, moveY, moveX);
    }

}
