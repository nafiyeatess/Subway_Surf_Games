using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cocuk : MonoBehaviour
{


    Transform yol_1, yol_2;

    public GameObject altin;

    public GameObject araba,kutuk,tas,miknatis;


    public List<GameObject> tum_altinlar;
    public List<GameObject> tum_engeller;



    private void Start()
    {
        yol_1 = GameObject.Find("yol_1").transform;
        yol_2 = GameObject.Find("yol_2").transform;

        tum_altinlar = new List<GameObject>();
        tum_engeller = new List<GameObject>();



        uretme_fonksiyonu(altin, 10, tum_altinlar);

        uretme_fonksiyonu(araba, 3, tum_engeller);
        uretme_fonksiyonu(kutuk, 3, tum_engeller);
        uretme_fonksiyonu(tas, 3, tum_engeller);
        uretme_fonksiyonu(miknatis, 3, tum_engeller);




        InvokeRepeating("altin_uret", 0.0f, 1.0f);
        InvokeRepeating("engel_uret", 2.0f, 3.0f);


    }




    void uretme_fonksiyonu(GameObject nesne,int miktar,List<GameObject> liste)
    {
        for (int i = 0; i < miktar; i++)
        {
            GameObject yeni_nesne = Instantiate(nesne);

            yeni_nesne.SetActive(false);
            liste.Add(yeni_nesne);
        }
    }






    void altin_uret()
    {
        foreach(GameObject altin in tum_altinlar)
        {
            if (altin.activeInHierarchy == false)
            {
                altin.SetActive(true);
                altin.transform.position = new Vector3(-3.0f, -3.0f, transform.position.z + 10.0f);
                return;
            }
        }
    }



    void engel_uret()
    {
        int rast = Random.Range(0, tum_engeller.Count);

        if (tum_engeller[rast].activeInHierarchy == false)
        {
            tum_engeller[rast].SetActive(true);
            tum_engeller[rast].transform.position = new Vector3(-3.0f, -3.0f, transform.position.z + 10.0f);
        }
        else
        {
            foreach (GameObject engel in tum_engeller)
            {
                if (engel.activeInHierarchy == false)
                {
                    engel.SetActive(true);
                    engel.transform.position = new Vector3(-3.0f, -3.0f, transform.position.z + 10.0f);
                    return;
                }
            }
        }

     
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "yol_1")
        {
            yol_2.position = new Vector3(yol_2.position.x, yol_2.position.y, yol_1.position.z + 10.0f);

        }
        if (collision.gameObject.name == "yol_2")
        {
            yol_1.position = new Vector3(yol_1.position.x, yol_1.position.y, yol_2.position.z + 10.0f);
        }



        if (collision.gameObject.tag == "altin")
        {
            collision.gameObject.SetActive(false);
        }






    }



}
