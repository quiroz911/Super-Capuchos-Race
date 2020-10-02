using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvoidLetterTextController : MonoBehaviour
{
    public bool inCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //actualiza el valor de la letra para esquivar el enemigo
        if(FindObjectOfType<EnemiesController>() != null)
        {
            gameObject.GetComponent<Text>().text = FindObjectOfType<EnemiesController>().avoidLetter;
        }
        //Pone rojo la letra si está en cooldown, amarillo de lo contrario
        if (inCoolDown)
        {
            gameObject.GetComponent<Text>().color = new Color(1, 0, 0, 1);
        }
        else
        {
            gameObject.GetComponent<Text>().color =  new Color(1, 0.92f, 0.016f, 1);
        }
        
    }
}
