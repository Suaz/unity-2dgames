using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject carFollowed;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(
            carFollowed.transform.position.x,
            carFollowed.transform.position.y,
            -10
        );
    }
}