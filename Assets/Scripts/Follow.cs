using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject follow;
    private void Awake()
    {
        this.transform.position =  new Vector3(follow.transform.position.x, follow.transform.position.y + 20.0f, follow.transform.position.z + 20.0f) ;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y + 25.0f, follow.transform.position.z - 20.0f);

    }
}
