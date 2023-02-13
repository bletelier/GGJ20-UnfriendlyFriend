using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GetEstado())
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + vel * Time.deltaTime, transform.position.z);
        }
    }
}
