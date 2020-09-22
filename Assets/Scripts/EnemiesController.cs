using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    bool avoid = false;
    string alphabet = "qwertyuiopasdfghjklzxcvbnm";
    string avoidLetter;
     
    // Start is called before the first frame update
    void Start()
    {
        avoidLetter = alphabet.Substring(Random.Range(0, 27), 1);
        Debug.Log(avoidLetter);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(avoid == true)
        {
            Destroy(gameObject);
        }

        gameObject.transform.Translate(-65f * Time.deltaTime, 0, 0);

        if (Input.GetKey(avoidLetter))
        {
            avoid = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InterfazDeUsuario interfazDeUsuario = FindObjectOfType<InterfazDeUsuario>();
        interfazDeUsuario.MostrarMensajeSalteableTecla("Game over, presione cualquier tecla para continuar");
        Destroy(gameObject);
    }

   
}
