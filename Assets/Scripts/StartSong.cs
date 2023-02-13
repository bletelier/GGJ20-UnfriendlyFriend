using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSong : MonoBehaviour
{
    public Text countdown;
    public GameObject musica;
    // Start is called before the first frame update

    private void Awake()
    {
        musica.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(Countback());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Countback()
    {
        countdown.text = "3";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.gameObject.SetActive(false);
        GameManager.Instance.StartGame();
        musica.SetActive(true);
    }
}
