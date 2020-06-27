using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawn1, spawn2, spawn3;
    public GameObject obstacle;
    public GameObject powerup;
    public float obspeed = 20f;
    public float spawnrate = 2f;
    public float obsExpTime = 5f;
    GameObject obst;
    GameObject pU;
    float nextspawn = 0f;
    int spawned;
    int SPAWNED2;
    public float spawnrate2 = 15f;
    float nextspawn2 = 0f;
    public float PUExpTime = 5f;



    void Start()
    {
       
    }
    void Update()
    {
        if (Time.time > nextspawn)
        {
            spawned = Random.Range(1, 4);


            switch (spawned)
            {
                case 1:
                    obst = Instantiate(obstacle, spawn1.position, spawn1.rotation);
                    obst.GetComponent<Rigidbody>().AddForce(obst.transform.forward * obspeed);
                    Destroy(obst, obsExpTime);
                    break;
                case 2:
                    obst = Instantiate(obstacle, spawn2.position, spawn2.rotation);
                    obst.GetComponent<Rigidbody>().AddForce(obst.transform.forward * obspeed);
                    Destroy(obst, obsExpTime);
                    break;
                case 3:
                    obst = Instantiate(obstacle, spawn3.position, spawn3.rotation);
                    obst.GetComponent<Rigidbody>().AddForce(obst.transform.forward * obspeed);
                    Destroy(obst, obsExpTime);
                    break;
            }

            nextspawn = Time.time + spawnrate;

        }
        if(Time.time > nextspawn2)
        {
          SPAWNED2 = Random.Range(1, 4);

            switch (SPAWNED2)
            {
                case 1:
                    pU = Instantiate(powerup, spawn1.position, spawn1.rotation);
                    pU.GetComponent<Rigidbody>().AddForce(pU.transform.forward * obspeed);
                    Destroy(pU, PUExpTime);
                    break;
                case 2:
                    pU = Instantiate(powerup, spawn2.position, spawn2.rotation);
                    pU.GetComponent<Rigidbody>().AddForce(pU.transform.forward * obspeed);
                    Destroy(pU, PUExpTime);
                    break;
                case 3:
                    pU = Instantiate(powerup, spawn3.position, spawn3.rotation);
                    pU.GetComponent<Rigidbody>().AddForce(pU.transform.forward * obspeed);
                    Destroy(pU, PUExpTime);
                    break;

            }
            nextspawn2 = Time.time + spawnrate2;

        }
      

    }
   
}
