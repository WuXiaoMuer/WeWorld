using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{    
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 cubePosition = hit.point + hit.normal * 0.5f;
                Instantiate(cubePrefab, cubePosition, Quaternion.identity);
            }
        }
    }
}
