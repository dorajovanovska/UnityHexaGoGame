using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;

    public Vector3 Offset;

    private void Update()
    {
        transform.position = PlayerTransform.position + Offset;
    }
}
