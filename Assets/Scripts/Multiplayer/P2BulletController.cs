using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2BulletController : MonoBehaviour
{
    float speed = -15f;
    float coolDownTimer;
    float timer;
    string avoidLetter;
    bool inCoolDown;
    Text avoidLetterText;
    Text timerText;
    Text gameOverText;


    void Start()
    {
        avoidLetterText = GameObject.Find("P2AvoidLetter").GetComponent<Text>();
        timerText = GameObject.Find("P2Tiempo").GetComponent<Text>();
        

        //configura el texto que muestra la letra para esquivar
        avoidLetterSelection();
        avoidLetterText.text = avoidLetter;
    }

    void Update()
    {
        //mueve la bala a la izquierda
        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);

        //actualiza el temporizador en pantalla
        timer += Time.deltaTime;
        timerText.text = "Tiempo: " + timer;

        //si se presiona una tecla
        if (Input.anyKeyDown)
        {
            if (Input.GetKey(avoidLetter) && !inCoolDown)
            {
                //devuelve la bala a la posición original y cambia la letra para esquivar
                gameObject.transform.position = new Vector3(41, -13, 0);
                avoidLetterSelection();
                avoidLetterText.text = avoidLetter;
                //aumenta la velocidad para la próxima bala
                speed -= 2f;
            }
            else
            {
                inCoolDown = true;
                //cambia la letra a rojo
                avoidLetterText.color = new Color(1, 0, 0, 1);
            }
        }

        //si está en cooldown aumenta el temporizador
        if (inCoolDown)
        {
            coolDownTimer += Time.deltaTime;
            //si llegó a 2 segundos, se elimina el cooldown
            if (coolDownTimer >= 2F)
            {
                inCoolDown = false;
                coolDownTimer = 0;
                //cambia la letra a amarillo
                avoidLetterText.color = new Color(1, 0.92f, 0.016f, 1);
            }
        }
    }

    //genera una letra al azar
    void avoidLetterSelection()
    {
        string alphabet = "zxcvb";
        avoidLetter = alphabet.Substring(Random.Range(0, 5), 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //muestra el mensaje de gameover
        gameOverText = GameObject.Find("P2GameOver").GetComponent<Text>();
        gameOverText.text = "Game Over Player 1 won!";
        Destroy(GameObject.Find("MrPickle_0"));
        Destroy(GameObject.Find("P2AvoidLetter"));
        Destroy(gameObject);
    }

}
