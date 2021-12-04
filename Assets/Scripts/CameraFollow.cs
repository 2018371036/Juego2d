using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public Transform target;
    public float LeftLimit;
    public float RightLimit;
    public float BottomLimit;
    public float TopLimit;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x+xOffset, target.position.y+yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
            Mathf.Clamp(transform.position.y, BottomLimit, TopLimit),
            transform.position.z
        );
    }
}
