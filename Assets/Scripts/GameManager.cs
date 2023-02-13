using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int acierto;
    bool estado;
    bool quieto;
    private float entusiasmo;
    AudioSource audioSource;
    public static int puntajeFinal = 0;
    public int puntaje;
    public int multiplicador;
    public AudioClip[] fallos;
    public GameObject musica;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();

    }


    public GameObject Pantallas;
    

    public Text reloj;
    public Text aciertos;
    public Text countdown;
    public Text x;
    public Text pnt;

    public GameObject fillImage;

    string texto;

    // Start is called before the first frame update
    void Start()
    {

        acierto = 0;
        estado = false;
        entusiasmo = 0.2f;
        multiplicador = 1;
        quieto = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(0);
        }*/
    }

    public void StartGame()
    {
        //aciertos.gameObject.SetActive(true);
        estado = true;
    }

    public void SetEstado(bool _jugando)
    {
        estado = _jugando;
    }

    public bool GetEstado()
    {
        return estado;
    }

    public float GetEntusiasmo()
    {
        return entusiasmo;
    }

    public void RellenarImagen(float puntuacion)
    {
        entusiasmo += puntuacion;
        fillImage.transform.GetChild(1).GetComponent<Image>().fillAmount += puntuacion;
        if(entusiasmo <= 0.0f)
        {
            Pantallas.SetActive(true);

            StartCoroutine(Show(3.0f,0));


            
        }
        else if(entusiasmo >= 1.0f && acierto > 10)
        {
            //animación de fuego en el instrumento
        }
    }

    IEnumerator Show(float time, int tipo)
    {
        Pantallas.transform.GetChild(tipo).gameObject.SetActive(true);
        if(tipo==0)
        {
            musica.SetActive(false);
        }
        estado = false;
        yield return new WaitForSeconds(time);
        if(tipo==1)
        {
            musica.SetActive(false);
            CreateGameManager.Instance.Gane(puntaje);
        }
        CreateGameManager.Instance.CrearGameManager();
        CreateGameManager.Instance.DestroyGameObject();
    }


    public void Win()
    {
        Pantallas.SetActive(true);

        StartCoroutine(Show(3.0f,1));

    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(clip);
    }


    public void PlayClipLoop(AudioClip clip)
    {
        audioSource.loop = true;
        audioSource.PlayOneShot(clip);
    }

    public void StopClip()
    {
        audioSource.Stop();
    }

    public bool isPlay()
    {
        return audioSource.isPlaying;
    }

    public void Fallo()
    {
        PlayClip(fallos[Random.Range(0, fallos.Length)]);
        multiplicador = 0;
        acierto = 0;
        aciertos.text = acierto + "\n" + puntaje.ToString() + "\n" + multiplicador;
    }

    public void SubirPuntaje()
    {
        acierto++;
        if(acierto <= 9)
        {
            multiplicador = 1;
        }else if(acierto <= 19)
        {
            multiplicador = 2;
        }else if(acierto <= 29)
        {
            multiplicador = 3;
        }
        else
        {
            multiplicador = 4;
        }
        puntaje += 100 * multiplicador;
        aciertos.text = acierto.ToString();
        x.text = "x" + multiplicador.ToString();
        pnt.text = puntaje.ToString();

    }

    public void SetQuieto(bool _quieto)
    {
        quieto = _quieto;
    }
    public bool GetQuieto()
    {
        return quieto;
    }
}
