using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movAuto : MonoBehaviour
{
    
    
    
    int speed;




    // Start is called before the first frame update
    void Start()
    {
       
        speed = 28;

        
    }

   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);

    }
}

    
