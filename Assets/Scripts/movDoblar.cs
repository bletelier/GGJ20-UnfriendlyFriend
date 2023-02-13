using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDoblar : MonoBehaviour
{
    int speed;
   

    // Start is called before the first frame update
    void Start()
    {

        speed = 25;
        //transform.rotation = new Quaternion(transform.rotation.x, 0 , transform.rotation.z, transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);

        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Derecha")
        {
            StartCoroutine(virarDerecha());
        }
        if(col.gameObject.tag == "Izquierda")
        {
            StartCoroutine(virarIzquierda());
        }
        
       
        
        
        
    }

    private IEnumerator virarDerecha()
    {
        speed = 10;
        float initialAngle = transform.eulerAngles.y;
        while (transform.eulerAngles.y < initialAngle + 90)
        {
            transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime, Space.World);
            
            yield return null;
        }
        speed = 28;
       
    }

    private IEnumerator virarIzquierda()
    {
        speed = 10;
        float initialAngle = transform.eulerAngles.y;
        while (transform.eulerAngles.y > initialAngle - 90 )
        {
            transform.Rotate(new Vector3(0, 50, 0) * -Time.deltaTime, Space.World);

            yield return null;
        }
        speed = 28;

    }
}
