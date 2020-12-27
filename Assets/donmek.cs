using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donmek : MonoBehaviour
{

    // altin y miknatis x

    string isim;

    float deger = 500.0f;


    void Start()
    {
        isim = gameObject.tag;


    }

   
    void Update()
    {

        if (isim == "miknatis")
        {
            transform.Rotate(deger*Time.deltaTime, 0, 0);
        }

        if (isim == "altin")
        {
            transform.Rotate(0, deger * Time.deltaTime, 0, Space.World);
        }

    }
}
