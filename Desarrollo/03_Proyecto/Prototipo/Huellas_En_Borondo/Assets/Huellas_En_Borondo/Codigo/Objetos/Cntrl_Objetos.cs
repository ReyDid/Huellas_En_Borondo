using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Objetos : MonoBehaviour
{
    [Header("General")]
    public bool Dstr;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Dstr)
        {
            Destruir();
        }
    }


    void Destruir()
    {
        gameObject.SetActive(false);

        Dstr = false;
    }
}
