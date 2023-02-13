using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateGameManager : MonoBehaviour
{
    public static CreateGameManager Instance { get; private set; }
    public GameObject obj;
    public GameObject obj2;
    public GameObject parent;
    public GameObject perdi;
    public GameObject[] compas;
    public Image[] compasIm;
    public int totalAmigos = 1;
    public int puntTotal = 0;
    int tipo;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        GameObject gm = (GameObject)Instantiate(obj, parent.transform);
        gm.GetComponent<GameManager>().reloj = parent.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        gm.transform.SetAsFirstSibling();
    }

    public void SetTipo(int _tipo)
    {
        tipo = _tipo;
    }

    // Start is called before the first frame update
    public void CrearGameManager()
    {
        GameObject gm = (GameObject)Instantiate(obj, parent.transform);
        gm.GetComponent<GameManager>().reloj = parent.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        gm.transform.SetAsFirstSibling();
        obj2.GetComponent<Reloj>().batalla = false;
        parent.SetActive(true);
        
    }

    public void Losse()
    {
        perdi.gameObject.SetActive(true);
        StartCoroutine(Inicio());
    }

    IEnumerator Inicio()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("PantallaPrincipal");
    }

    public void Final()
    {
        if(totalAmigos >= 4)
        {
            
            Destroy(parent.transform.GetChild(0).gameObject);
            parent.SetActive(false);
            //reloj.GetComponent<Reloj>().batalla = true;
            SceneManager.LoadScene("Final", LoadSceneMode.Additive);
        }
        
    }

    public void Gane(int punt)
    {
        puntTotal += punt;
        totalAmigos++;
        Destroy(compas[tipo].transform.GetChild(0).gameObject);
        compas[tipo].GetComponent<followChar>().enabled = true;
        compas[tipo].GetComponent<AudioSource>().enabled = true;
        compasIm[tipo].GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    public void DestroyGameObject()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
    }
}
