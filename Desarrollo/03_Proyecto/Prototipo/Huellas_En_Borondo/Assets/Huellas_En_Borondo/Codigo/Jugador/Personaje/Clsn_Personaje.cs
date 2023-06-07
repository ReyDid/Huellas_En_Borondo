using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clsn_Personaje : MonoBehaviour
{
    [Header("Personaje")]
    public bool Prsnj1, Prsnj2, PrsnjG;

    [Header("Referencia")]
    public Cntrl_Personaje _Personaje;


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

    }


    void OnTriggerEnter(Collider Otr)
    {
        if (name == "Campo_Come")
        {
            // Comer Fruta
            if (Otr.tag == "Fruta")
            {
                Otr.transform.parent.parent.GetComponent<Cntrl_Objetos>().Dstr = true;
            }
        }

        if (name == "Campo_Muerde")
        {
            // Morder
            if (Otr.tag == "CrpPrsnj" || Otr.tag == "Obstcl")
            {
                if (Otr.tag == "CrpPrsnj")
                {
                    if (Otr.transform.parent.parent.name != "Cola")
                    {
                        _Personaje._Estado.Fin = true;
                    }
                }
                else
                {
                    _Personaje._Estado.Fin = true;
                }
            }
        }
    }
    void OnTriggerStay(Collider Otr)
    {
        if (Otr.gameObject.layer == 28)
        {
            if (Prsnj1)
            {
                _Personaje._Estado.P1_EnSuelo = true;
            }
            if (Prsnj2)
            {
                _Personaje._Estado.P2_EnSuelo = true;
            }
            if (PrsnjG)
            {
                _Personaje._Estado.PG_EnSuelo = true;
            }
        }
    }
    void OnTriggerExit(Collider Otr)
    {
        if (Otr.gameObject.layer == 28)
        {
            if (Prsnj1)
            {
                _Personaje._Estado.P1_EnSuelo = false;
            }
            if (Prsnj2)
            {
                _Personaje._Estado.P2_EnSuelo = false;
            }
            if (PrsnjG)
            {
                _Personaje._Estado.PG_EnSuelo = false;
            }
        }
    }
}
