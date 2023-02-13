using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followChar : MonoBehaviour
{
    public GameObject charac;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(charac.transform.position.x, charac.transform.position.y +2.0f, charac.transform.position.z -2.0f);
    }
}
