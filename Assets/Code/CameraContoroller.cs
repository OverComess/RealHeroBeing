using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroller : MonoBehaviour
{
    [SerializeField]
    Transform objectToLock;

    void Update()
    {
        Camera.main.transform.position = new(objectToLock.position.x,objectToLock.position.y,
            -10);
    }
}
