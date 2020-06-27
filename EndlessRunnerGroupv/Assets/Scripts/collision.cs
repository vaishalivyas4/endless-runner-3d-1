using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(0);
            UIPoints.Points = 0;

        }




        /* else if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }*/

    }

}
