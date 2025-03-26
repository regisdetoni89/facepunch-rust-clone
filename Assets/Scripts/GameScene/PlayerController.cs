using UnityEngine;

public class PlayerController : MonoBehaviour{

    public CharacterController controller;
    public float speed = 5f;
    public float turnSpeed = 90; // degrees per second
    public float jumpStrength = 5f;
    private float verticalSpeed = 0f;

    public float slideFriction = 0.3f;

    private Vector3 hitNormal = Vector3.down;

    private Vector3 vel = Vector3.zero;

    void OnControllerColliderHit (ControllerColliderHit hit) {
	    hitNormal = hit.normal;
        verticalSpeed = 0;
    }

    void Update()
    {

        bool isStuck = controller.velocity.magnitude <= 1.3f && controller.isGrounded;
        bool isGrounded = Vector3.Angle (Vector3.up, hitNormal) <= controller.slopeLimit;

        transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0);
        if (isGrounded){
            vel = transform.forward * Input.GetAxis("Vertical") * speed;
            vel += transform.right * Input.GetAxis("Horizontal") * speed;
        }else{
            vel += transform.forward * Input.GetAxis("Vertical") * speed * 0.5f * Time.deltaTime;
            vel += transform.right * Input.GetAxis("Horizontal") * speed * 0.5f * Time.deltaTime;
            if(controller.isGrounded){
                vel.x += (1f - hitNormal.y) * hitNormal.x * (1f - slideFriction);
                vel.z += (1f - hitNormal.y) * hitNormal.z * (1f - slideFriction);
            }
        }
        if (isGrounded || isStuck){
            if (Input.GetAxis("Jump") != 0){
                verticalSpeed = jumpStrength;
                if(isStuck){
                    vel = Vector3.zero;
                }
                hitNormal = Vector3.down;
            }
        }

        verticalSpeed -= 9.8f * Time.deltaTime;
        vel.y = verticalSpeed;



        controller.Move(vel * Time.deltaTime);
    }

}
