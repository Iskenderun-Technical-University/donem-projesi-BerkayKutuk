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
        //Araba H�z�
        if (oyunBitti == false)
            GetComponent<Rigidbody>().AddForce(Vector3.left * 20, ForceMode.Force);

        else if (oyunBitti == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        //Sa�a-Sola gidi� h�z�
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
        //Engele �arpt���nda oyunu yeniden ba�lat
        if (collision.collider.tag == "Engel")
        {
            //ba�lang�� delay�
            Invoke("restart", 3f);
            oyunBitti = true;
        }
        //coine �arpt���nda puan kazanma ve coini yok etme
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
