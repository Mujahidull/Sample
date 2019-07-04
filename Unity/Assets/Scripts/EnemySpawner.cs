using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] cars;
    int carNo;
    public float maxPos = 2.3f;
    public float delayTimer = 2f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-2.3f, 2.3f), transform.position.y , transform.position.z);
            carNo = Random.Range(0,5);
            Instantiate(cars[carNo], carPos, transform.rotation);
            timer = delayTimer;
        }
     }
}
