using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressNote : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material material;
    public KeyCode keyCode;
    Color color;
    private List<GameObject> toDestroy;
    public Color colorTo;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        color = material.color;
        toDestroy = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            material.color = colorTo;
            if(GameManager.Instance.GetEstado())
            {
                if (toDestroy.Count > 0)
                {
                    GameManager.Instance.RellenarImagen(0.02f);
                    GameManager.Instance.SubirPuntaje();
                    if (toDestroy[0].tag == "Finish")
                    {
                        Destroy(toDestroy[0]);
                        toDestroy.RemoveAt(0);
                        GameManager.Instance.Win();
                    }
                    else
                    {
                        Destroy(toDestroy[0]);
                        toDestroy.RemoveAt(0);
                    }
                    
                }
                else
                {
                    GameManager.Instance.Fallo();
                    GameManager.Instance.RellenarImagen(-0.1f);
                }
            }
        }
        else if (Input.GetKeyUp(keyCode))
        {
            material.color = color;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject objeto = other.gameObject;
        toDestroy.Add(objeto);
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.RellenarImagen(-0.1f);     
        GameObject objeto = other.gameObject;
        toDestroy.Remove(objeto);
        GameManager.Instance.Fallo();

    }
}
