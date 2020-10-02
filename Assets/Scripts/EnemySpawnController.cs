using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float timer;
    //float timerSpeeder = 0;
    public float speedSpeeder = -65f;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        EnemiesController bullet = FindObjectOfType<EnemiesController>();
        //timerSpeeder += 0.1f*Time.deltaTime;
        speedSpeeder -= 2f*Time.deltaTime;
        

        if (timer >= 2f && bullet == null)
        {
            timer = 0;
            
            Instantiate(bulletPrefab);
        }
    }
}
