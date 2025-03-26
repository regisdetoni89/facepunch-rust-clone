using UnityEngine;

public class PlayerController : MonoBehaviour{

    public CharacterController controller;
    public float speed = 5f;
    public float turnSpeed = 90; // degrees per second
    public float jumpStrength = 5f;
    private float verticalSpeed = 0f;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0);
        Vector3 vel = transform.forward * Input.GetAxis("Vertical") * speed;
        vel+= transform.right * Input.GetAxis("Horizontal") * speed;
        if (controller.isGrounded){
            verticalSpeed = 0;
            if (Input.GetAxis("Jump") != 0){
                verticalSpeed = jumpStrength;
            }
        }

        verticalSpeed -= 9.8f * Time.deltaTime;
        vel.y = verticalSpeed;

        controller.Move(vel * Time.deltaTime);
    }

}
