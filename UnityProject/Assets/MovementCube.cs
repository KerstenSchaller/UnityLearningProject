using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var newPos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"),0);
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        newPos.z = transform.position.z;


        transform.position = newPos;
    }
}
