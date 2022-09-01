using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;


    // Update is called once per frame
    private void Start()
    {
        offset = transform.position - player.position;
    }
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, player.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 50 * Time.deltaTime);
    }
}
