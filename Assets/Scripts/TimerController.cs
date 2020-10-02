using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    float timer;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timer += Time.deltaTime;
            gameObject.GetComponent<Text>().text = "Tiempo: " + timer;
        }
        
    }
}
