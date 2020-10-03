using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class EnemiesController : MonoBehaviour
{
    public bool avoid = false;
    string alphabet = "qwert";
    public string avoidLetter;
    float speed;
    bool cooldown = false;
    float timer;
     
    // Start is called before the first frame update
    void Start()
    {
        speed = FindObjectOfType<EnemySpawnController>().speedSpeeder;
        avoidLetter = alphabet.Substring(Random.Range(0, 5), 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (avoid == true)
        {
            Destroy(gameObject);
        }

        if (cooldown == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer = 0;
                cooldown = false;
                //actualiza el color del texto
                FindObjectOfType<AvoidLetterTextController>().inCoolDown = false;
            }
        }

        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);

        if (Input.anyKeyDown)
        {
            if (Input.GetKey(avoidLetter) && cooldown == false)
            {
                avoid = true;
            }
            else
            {
                cooldown = true;
                //actualiza el color del texto
                FindObjectOfType<AvoidLetterTextController>().inCoolDown = true;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InterfazDeUsuario interfazDeUsuario = FindObjectOfType<InterfazDeUsuario>();
        interfazDeUsuario.MostrarMensajeSalteableTecla("Game over, presione cualquier tecla para continuar");

        //destruye al personaje
        PlayerController player = FindObjectOfType<PlayerController>();
        player.Playerhit();

        //destruye el spawn de enemigos y el enemigo actual
        Destroy(FindObjectOfType<EnemySpawnController>());
        Destroy(gameObject);

        //detiene el tiempo
        FindObjectOfType<TimerController>().isGameOver = true;
    }

   
   
}
