using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Collider2D coll;

    [SerializeField] private float spawn_delay;
    [SerializeField] private float spawn_radius;

    //System.Random rnd = new System.Random();
            
    private GameObject parent = new GameObject("Enemies");
    private float spawn_time;


    // Start is called before the first frame update
    void Start()
    {
        parent.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        spawn_time += Time.deltaTime;
        if (spawn_time % 10 > 1)
        {
            float x_spawn = UnityEngine.Random.Range(-2f, 2f) * 5;
            float y_spawn = UnityEngine.Random.Range(-2f, 2f) * 5;

            while (coll.bounds.Contains(new Vector3(x_spawn, y_spawn, 0f)))
            {
                x_spawn = UnityEngine.Random.Range(-2f, 2f) * 5;
                y_spawn = UnityEngine.Random.Range(-2f, 2f) * 5;
            }
            

            spawn_time = 0;
            Spawner(x_spawn, y_spawn);            
        }

        //Debug.Log(spawn_time);
    }

    void Spawner(float x_spawn, float y_spawn)
    {
        Vector3 playerPosition = player.position;

        

        if (Math.Pow(x_spawn + playerPosition.x, 2) + Math.Pow(y_spawn + playerPosition.y, 2) > Math.Pow(spawn_radius, 2))
        {
            Instantiate(prefab, new Vector3(x_spawn, y_spawn, 0f), Quaternion.identity);
            //Debug.Log($"{ x_spawn} { y_spawn}");
            //Debug.Log($"{playerPosition.x} {playerPosition.y}");

        }

    }
}
