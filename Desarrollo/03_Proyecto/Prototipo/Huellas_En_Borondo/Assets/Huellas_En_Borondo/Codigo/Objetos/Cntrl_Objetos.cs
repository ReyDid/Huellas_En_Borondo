using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Objetos : MonoBehaviour
{
    [Header("General")]
    public bool Dstr;
    int rndmVlcd;

    [Header("Referencias")]
    [HideInInspector]
    public Rigidbody CrpRgd;


    // Start is called before the first frame update
    void Start()
    {
        CrpRgd = GetComponent<Rigidbody>();

        rndmVlcd = Random.Range(1, 5);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Gravedad();

        if (Dstr)
        {
            Destruir();
        }
    }


    void Gravedad()
    {
        float vlcd = 0;
        switch (rndmVlcd)
        {
            case 1:
                vlcd = 200;
                break;
            case 2:
                vlcd = 100;
                break;
            case 3:
                vlcd = 300;
                break;
            case 4:
                vlcd = 50;
                break;
            case 5:
                vlcd = 80;
                break;
        }

        CrpRgd.velocity = new Vector3(0, -vlcd, 0);
    }
    void Destruir()
    {
        gameObject.SetActive(false);

        Dstr = false;
    }
}
