using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    Transform target;

    float smoothSpeed = .125f;
    Vector3 offset = new Vector3(0f,0f,-20f);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desPos, smoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(target);
    }
}
