using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Collider))]
// [RequireComponent(typeof(Rigidbody))]

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController control;
    public Vector3 direction;
    public float speed=10;
    private int lane = 1;
    public float laneDistance = 5;
    public float jumpfrc = 10;
    public float gravity = 5;
    public Collider coll;


    void Start()
    {
        control = GetComponent<CharacterController>();
        coll = GetComponent<Collider>();

    }

    // Update is called once per frame

    private void Update()
    {
        direction.z = speed;
        
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            direction.y = 0;

            JumpKarao();
           
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane++;
            if (lane == 3)
            {
                lane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane--;
            if (lane == -1)
            {
                lane = 0;
            }
        }


        Vector3 target = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lane == 0)
        {
            target += Vector3.left * laneDistance;
        }
        else if (lane == 2)
        {
            target += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, target, 80 * Time.deltaTime);
        
    }
    void FixedUpdate()
    {
        control.Move(direction * Time.deltaTime);
    }

    private void JumpKarao()
    {
        direction.y = jumpfrc;
    }

    bool Grounded()
    {

        return Physics.Raycast( transform.position , Vector3.down , coll.bounds.extents.y + 0.2f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            Debug.Log("We hit something");
            Trigger.gg = true;

        }
    }
}
