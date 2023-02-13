using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish" && GameManager.Instance.GetEntusiasmo() > 0.0f)
        {
            GameManager.Instance.Win();
        }
        Destroy(other.gameObject);
    }
}
