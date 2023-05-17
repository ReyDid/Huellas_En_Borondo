using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clsn_Personaje : MonoBehaviour
{
    [Header("General")]
    public bool Cabeza;

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
        if (Cabeza)
        {
            transform.rotation = _Personaje._Avatar.transform.GetChild(1).rotation;
        }
    }


    void OnTriggerEnter(Collider Otr)
    {
        if (name == "Campo_Come")
        {
            // Comer Fruta
            if (Otr.tag == "Fruta")
            {
                _Personaje._Estado.Frutas++;

                _Personaje._Estado.TmñCrp++;
                Otr.transform.parent.parent.GetComponent<Cntrl_Fruta>().Dstr = true;
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
                        _Personaje.PrtCrp_Mrdd = Otr.transform.parent.parent.GetComponent<PrtsCrp_Personaje>().Id;
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
}
