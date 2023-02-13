using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarAutos : MonoBehaviour
{
    public GameObject[] direccionAuto;

  
    

    float x;
    new Vector3 posOrigen;

    int min;
    int max;

    bool couroutineStarted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        posOrigen = transform.position;

    }

    void Start()
    {
        min = 3;
        max = 7;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!couroutineStarted)
            StartCoroutine(UsingYield(Random.Range(min, max)));
            
    }

    IEnumerator UsingYield(int seconds)
    {
        couroutineStarted = true;
        int ind = Random.Range(0, 9);
       
        
        Instantiate(direccionAuto[ind], posOrigen, transform.rotation);
        

        yield return new WaitForSeconds(seconds);

        couroutineStarted = false;
    }

    
}
