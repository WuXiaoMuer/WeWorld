using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;
    public float damping = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wantedPosition = target.position + Vector3.up * height - target.forward * distance;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
        transform.LookAt(target);
    }
}
