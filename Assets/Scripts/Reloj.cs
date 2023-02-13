using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    string texto;
    public Text reloj;
    static int minutos = 0;
    static int hora = 15;
    [Range(0.0f, 1000.0f)]
    public float ScaleHour;
    public bool batalla;
    float segundos = 1.0f;
    int segundoInt = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime * ScaleHour;
        segundoInt = (int)segundos;

        if (segundoInt % 600 == 0)
        {
            minutos += 10;
            segundos = 1;
            ImprimirTiempo(hora,minutos,batalla);
            if (minutos % 60 == 0)
            {
                hora += 1;
                minutos = 0;
                ImprimirTiempo(hora, minutos, batalla);
            }
        }
    }
    public void ImprimirTiempo(int hora, int minutos, bool jugando)
    {
        if(hora >= 21)
        {
            CreateGameManager.Instance.Losse();
        }
        if (!jugando)
        {
            if (minutos >= 10.0f)
            {
                texto = hora.ToString() + ":" + minutos.ToString();

            }
            else
            {
                texto = hora.ToString() + ":0" + minutos.ToString();
            }
            reloj.text = texto;
        }
    }
}
