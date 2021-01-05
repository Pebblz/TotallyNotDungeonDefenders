using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float health = 100;
    
    public float speed = 3f;
    public float jump = 8f;
    public bool grounded = true;

    private CharacterController characterController;

    public float RotationSpeed = 240.0f;

    private float Gravity = 20.0f;

    private Vector3 moveDir = Vector3.zero;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        #region CONTROLS
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 camForward_Dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v * camForward_Dir + h * Camera.main.transform.right;

        if (move.magnitude > 1f) move.Normalize();


        move = transform.InverseTransformDirection(move);

        float turnAmount = Mathf.Atan2(move.x, move.z);

        transform.Rotate(0, turnAmount * RotationSpeed * Time.deltaTime, 0);

        if (characterController.isGrounded)
        {
            //jump
            if (Input.GetKey(KeyCode.Space))
            {
                moveDir.y = jump;
            } else
            {
                moveDir = transform.forward * move.magnitude;
                moveDir *= speed;
            }
          

        }

        moveDir.y -= Gravity * Time.deltaTime;

        characterController.Move(moveDir * Time.deltaTime);

       
        #endregion

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        

    }




    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    //just a simple function to lose health
    public void HitPlayer(float amount)
    {
        health -= amount;
    }

 
}
