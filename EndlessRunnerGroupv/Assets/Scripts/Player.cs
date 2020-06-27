using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator ANIME;

    public float jumpforce = 30f;

    public GameObject Obstacle;
    public GameObject fl1, fl2;
    GameObject flash;
    public float rayrange = 400f;
    RaycastHit HIT;


    public float maxpos = 1f;
   Vector3 ppos;
    Vector3 mainpos; 

    public float movespeed = 1f;
    public float rotspeed = 10f;
    public float maxrot = 60f;
    float currot = 0;
   public float bulletspeed = 1000f;
   public float bulletExptime = 2f;

    public GameObject CAM;
   public GameObject Bulletprefab;
    public Transform Nozzle1, Nozzle2;
   GameObject Bullet;

    Vector3 CurCAMrot;

    Rigidbody RB;

    bool onGround = true;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        ANIME = GetComponent<Animator>();
    }

    void Update()
    {
       
        #region cam rotation
        float MOUSEY = Input.GetAxis("Mouse Y");

        CAM.transform.Rotate(Vector3.right * rotspeed * MOUSEY);

        currot += (MOUSEY * rotspeed);
        currot = Mathf.Clamp(currot, -maxrot, maxrot);
        CurCAMrot = CAM.transform.rotation.eulerAngles;
        CurCAMrot.x = -currot;
        CAM.transform.rotation = Quaternion.Euler(CurCAMrot);
        CAM.transform.Rotate(Vector3.right * rotspeed * MOUSEY);
        #endregion

        #region JUMP
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            RB.AddForce(Vector3.up * jumpforce);
            onGround = false;
        }
#endregion

        #region movement using transform
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(1, 0, 0);
        }

        mainpos = transform.position;
        mainpos.x = Mathf.Clamp(mainpos.x, -maxpos, maxpos);
        transform.position = mainpos;
        #endregion

        #region movement using position
        /*   ppos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
           if (Input.GetKeyDown(KeyCode.RightArrow))
           {           
               ppos = transform.position - Vector3.right;
           }
           else if (Input.GetKeyDown(KeyCode.LeftArrow))
           {
               ppos = transform.position + Vector3.right;
           }

           ppos.x = Mathf.Clamp(ppos.x,-maxpos,maxpos);

           transform.position = ppos; */
        #endregion

        if (Input.GetButtonDown("Fire1")&& UIPoints.ammo>0 )
        {
            UIPoints.ammo -= 1;
            FireRay();
            
            #region FLASH
            flash = Instantiate(fl1, Nozzle1.position, Nozzle1.rotation);
            Destroy(flash, 1f);
            flash = Instantiate(fl2, Nozzle2.position, Nozzle2.rotation);
            Destroy(flash, 1f);
            #endregion
            ANIME.SetBool("FIRE1",true);
            ANIME.SetBool("FIRE2",true);
            #region bullet
            /*   Bullet = Instantiate(Bulletprefab, Nozzle1.position, Nozzle1.rotation = Quaternion.Euler(-90, 0, 0)) ;
               Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.up * bulletspeed);
               Destroy(Bullet, bulletExptime);
               Bullet = Instantiate(Bulletprefab, Nozzle2.position, Nozzle2.rotation = Quaternion.Euler(-90, 0, 0));
               Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.up * bulletspeed);
               Destroy(Bullet,bulletExptime);*/
            #endregion
        }

    }

    #region Ground check
    private void OnCollisionEnter(Collision COL)
    {
        if(COL.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    #endregion

    #region RAYCAST
    void FireRay()
    {
        Ray Start = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
      

        if(Physics.Raycast(Start,out HIT, rayrange))
        {
            if (HIT.collider.tag == "Obstacle")
            {
                HIT.collider.GetComponent<Rigidbody>().AddForce(Vector3.back * 3000f);
                HIT.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * 500f);
                UIPoints.Points += 500;
                Destroy(HIT.collider.gameObject, 0.5f);
            }
        }
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward * rayrange, Color.yellow,1f);

    }
    #endregion
}
