using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public GameObject PU;

    private void OnCollisionEnter(Collision COL)
    {
        if (COL.gameObject.tag == "Player")
        {
            UIPoints.ammo += 5;
            Destroy(PU,0.01f);

        }
    }
}
