using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    public float vel;
    Animator anim;

    public Rigidbody rb;

    public AudioClip pasos;
    public AudioClip auch; 
    bool isMov;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isMov = false;
        anim.SetInteger("direction", 0);

    }

    

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GetQuieto())
        {
            
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.Translate(Vector3.right * Time.deltaTime * vel);
                anim.SetInteger("direction", 1 );
                //isMov = true;
                
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                transform.Translate(Vector3.left * Time.deltaTime * vel);
                anim.SetInteger("direction", -1);
                //isMov = true;

            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                transform.position += (new Vector3(0, 0, 1) * Time.deltaTime * vel);
                anim.SetInteger("direction", 2);
                //isMov = true;

            }
            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                transform.position += (new Vector3(0, 0, -1) * Time.deltaTime * vel);
                anim.SetInteger("direction", -2);
                //isMov = true;

            }
            else
            {
                anim.SetInteger("direction", 0);
                //isMov = false;
            }
        }
        else
        {
            anim.SetInteger("direction", 0);
            //isMov = false;
        }

        if (isMov)
        {
            /*bool isplay = GameManager.Instance.isPlay();
            if (!isplay)
            {
               // GameManager.Instance.PlayClip(pasos);
            }*/
            
        }
        else
        {
            //GameManager.Instance.StopClip();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Meta")
        {
            CreateGameManager.Instance.Final();
            Debug.Log("Toque meta");
        }
    }


   
      

}



