using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yok_ol : MonoBehaviour
{

    Transform cocuk;

    void Start()
    {
        cocuk = GameObject.Find("cocuk").transform; 
    }

   

    void Update()
    {

  

        if (transform.position.z < cocuk.position.z)
        {
            gameObject.SetActive(false);
        }


    }
}
