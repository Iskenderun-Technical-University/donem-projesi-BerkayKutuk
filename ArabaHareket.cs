using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArabaHareket : MonoBehaviour
{
    bool oyunBitti = false;
    public int puan = 0;

    // Start is called before the first frame update
    void Start()
    {
        puan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Araba Hýzý
        if (oyunBitti == false)
            GetComponent<Rigidbody>().AddForce(Vector3.left * 20, ForceMode.Force);

        else if (oyunBitti == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        //Saða-Sola gidiþ hýzý
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 50, ForceMode.Force);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -50, ForceMode.Force);
        }


        if(GetComponent<Rigidbody>().position.x <= -160)
        {
            oyunBitti = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("restart", 3f);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        //Engele çarptýðýnda oyunu yeniden baþlat
        if (collision.collider.tag == "Engel")
        {
            //baþlangýç delayý
            Invoke("restart", 3f);
            oyunBitti = true;
        }
        //coine çarptýðýnda puan kazanma ve coini yok etme
        if(collision.collider.tag == "Coin")
        {
            puan++;
            Destroy(collision.gameObject);
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunBitti = false;
    }


}
