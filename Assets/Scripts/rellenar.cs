using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class rellenar : MonoBehaviour
{
    public Text final;
    // Start is called before the first frame update
    void Start()
    {
        final.text = "Gracias a ti, la banda ha reparado su amistad\nPuntaje Final: " + CreateGameManager.Instance.puntTotal.ToString();
        StartCoroutine(MainMenu());
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(20.0f);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
