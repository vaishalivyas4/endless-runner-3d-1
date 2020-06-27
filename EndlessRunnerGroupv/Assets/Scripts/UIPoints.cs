using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPoints : MonoBehaviour
{
    public static int Points;
    public static int ammo = 10; 
    public Text Score;
    public Text Nammo;

    private void Update()
    {
        Score.text = "" + Points;
        UIPoints.Points += 1;

        Nammo.text = "" + ammo;
    }

     
}
