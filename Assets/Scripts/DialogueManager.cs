using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    public GameObject dialogo;
    public GameObject padre;
    public Transform personaje;
    public GameObject reloj;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
    Queue<string> sentences;
    Queue<string> names;
    string sceneTo;
    int tipo;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        tipo = dialogue.tipo;
        dialogo.SetActive(true);
        sceneTo = dialogue.battle;
        GameManager.Instance.SetQuieto(true);
        foreach (string sentence in dialogue.dialogue)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        NextSentence();
    }
    public void NextSentence()
    {
        if(sentences.Count == 0 || names.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        dialogo.transform.GetChild(1).GetComponent<Text>().text = name;
        dialogo.transform.GetChild(2).GetComponent<Text>().text = sentence;
    }

    public void EndDialogue()
    {
        dialogo.SetActive(false);
        CreateGameManager.Instance.SetTipo(tipo);
        Destroy(padre.transform.GetChild(0).gameObject);
        reloj.GetComponent<Reloj>().batalla = true;
        SceneManager.LoadScene(sceneTo, LoadSceneMode.Additive);
        personaje.position += new Vector3(0, 0, -5.0f);
        padre.SetActive(false);
        
    }
}
