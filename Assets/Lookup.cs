using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookup : MonoBehaviour

{
    // Start is called before the first frame update
    public float rotationspeed = 600;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Mouse Y") * rotationspeed;
        Camera.main.transform.Rotate(new Vector3(vertical, 0, 0) * Time.deltaTime);
    }
}
