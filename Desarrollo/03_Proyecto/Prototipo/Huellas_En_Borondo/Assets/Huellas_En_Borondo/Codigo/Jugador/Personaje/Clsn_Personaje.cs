using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clsn_Personaje : MonoBehaviour
{
    [Header("Personaje")]
    public bool Prsnj1, Prsnj2, PrsnjG;

    [Header("Cuerpo")]
    public float DstncRyEscl;
    public LayerMask ObstclEsclr;

    [Header("Escalar")]
    public bool Escalar;
    public CapsuleCollider ClsnCrp;

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
        if (name == "Escalar")
        {
            RaycastHit ryEscl;

            if (Escalar)
            {
                if (Physics.Raycast(transform.position + (Vector3.up * .2f), transform.forward, out ryEscl, DstncRyEscl, ObstclEsclr))
                {
                    Debug.DrawLine(transform.position + (Vector3.up * .2f), ryEscl.point, Color.green);

                    if (Prsnj1)
                    {
                        _Personaje._Estado.P1_Escala = true;
                    }
                    if (Prsnj2)
                    {
                        _Personaje._Estado.P2_Escala = true;
                    }
                    if (PrsnjG)
                    {
                        _Personaje._Estado.PG_Escala = true;
                    }
                    //ClsnCrp.enabled = false;
                }
                else
                {
                    Debug.DrawRay(transform.position + (Vector3.up * .2f), transform.forward * DstncRyEscl, Color.blue);

                    if (Prsnj1)
                    {
                        _Personaje._Estado.P1_Escala = false;
                    }
                    if (Prsnj2)
                    {
                        _Personaje._Estado.P2_Escala = false;
                    }
                    if (PrsnjG)
                    {
                        _Personaje._Estado.PG_Escala = false;
                    }
                    //ClsnCrp.enabled = true;
                }
            }
            else
            {
                if (Prsnj1)
                {
                    _Personaje._Estado.P1_Escala = false;
                }
                if (Prsnj2)
                {
                    _Personaje._Estado.P2_Escala = false;
                }
                if (PrsnjG)
                {
                    _Personaje._Estado.PG_Escala = false;
                }
            }
        }
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

        if (Otr.gameObject.layer == 28)
        {
            switch (name)
            {
                case "Escalar":
                    if (Prsnj1)
                    {
                        _Personaje._Estado.FrzGrvd_P1 = 0;
                    }
                    if (Prsnj2)
                    {
                        _Personaje._Estado.FrzGrvd_P2 = 0;
                    }
                    if (PrsnjG)
                    {
                        _Personaje._Estado.FrzGrvd_PG = 0;
                    }
                    break;
            }
        }
    }
    void OnTriggerStay(Collider Otr)
    {
        if (Otr.gameObject.layer == 28)
        {
            switch (name)
            {
                case "Pie":
                    if (Prsnj1)
                    {
                        _Personaje._Estado.P1_EnSuelo = !_Personaje._Estado.P1_Escala ? true : false;
                    }
                    if (Prsnj2)
                    {
                        _Personaje._Estado.P2_EnSuelo = !_Personaje._Estado.P2_Escala ? true : false;
                    }
                    if (PrsnjG)
                    {
                        _Personaje._Estado.PG_EnSuelo = !_Personaje._Estado.PG_Escala ? true : false;
                    }
                    break;
            }
        }

        if (Otr.gameObject.layer == 27)
        {
            switch (name)
            {
                case "Cuerpo":
                    if (Prsnj1)
                    {
                        _Personaje._Estado.P1_FrCamino = true;
                    }
                    if (Prsnj2)
                    {
                        _Personaje._Estado.P2_FrCamino = true;
                    }
                    if (PrsnjG)
                    {
                        _Personaje._Estado.PG_FrCamino = true;
                    }
                    break;
            }
        }

        if (Otr.gameObject.layer == 30)
        {
            switch (name)
            {
                case "Escalar":
                    Escalar = true;
                    break;
            }
        }
    }
    void OnTriggerExit(Collider Otr)
    {
        if (Otr.gameObject.layer == 28)
        {
            switch (name)
            {
                case "Pie":
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
                    break;
            }
        }

        if (Otr.gameObject.layer == 27)
        {
            switch (name)
            {
                case "Cuerpo":
                    if (Prsnj1)
                    {
                        _Personaje._Estado.P1_FrCamino = false;
                    }
                    if (Prsnj2)
                    {
                        _Personaje._Estado.P2_FrCamino = false;
                    }
                    if (PrsnjG)
                    {
                        _Personaje._Estado.PG_FrCamino = false;
                    }
                    break;
            }
        }

        if (Otr.gameObject.layer == 30)
        {
            switch (name)
            {
                case "Escalar":
                    Escalar = false;
                    break;
            }
        }
    }
}
