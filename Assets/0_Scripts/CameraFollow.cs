using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
	public float smoothSpeed = 0.125f;
    public Vector3 offSet;

	private void Start()
	{
		player = GameObject.FindWithTag("Player").transform;
	}
	// Update is called once per frame
	void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
