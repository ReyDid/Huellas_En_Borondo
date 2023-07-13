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

        if (Otr.gameObject.layer == 22)
        {
            switch (name)
            {
                case "Cuerpo":
                    if (Prsnj1)
                    {
                        if (Otr.tag == "Hll")// Objeto : Huella
                        {
                            _Personaje._Estado.Cntd_Huellas += Otr.GetComponent<Clsn_Objetos>()._Objetos._Tipo.Cntd;
                            _Personaje._Estado.ClclHlls_Mct += Otr.GetComponent<Clsn_Objetos>()._Objetos._Tipo.Cntd;
                            if (Cntrl_Personaje.Letras > 0)
                            {
                                _Personaje._Estado.ClclHlls_Ltr += Otr.GetComponent<Clsn_Objetos>()._Objetos._Tipo.Cntd;
                            }
                            _Personaje._Estado.ClclHlls_SprHll++;
                            if (_Personaje._Estado.EnLsn)
                            {
                                _Personaje._Estado.ClclHlls_MMdcnl += Otr.GetComponent<Clsn_Objetos>()._Objetos._Tipo.Cntd;
                            }
                            Otr.GetComponent<Clsn_Objetos>()._Objetos._NoColision.Intr = true;
                        }
                        if (Otr.tag == "Obstcl")// Objeto : Obstaculo
                        {
                            switch (_Personaje._Estado.Personaje)
                            {
                                case "Dorotea":
                                    if (_Personaje._Estado.Sld_Dorotea > 0)
                                    {
                                        _Personaje._Estado.Sld_Dorotea--;
                                    }
                                    break;
                                case "Benkos":
                                    if (_Personaje._Estado.Sld_Benkos > 0)
                                    {
                                        _Personaje._Estado.Sld_Benkos--;
                                    }
                                    break;
                            }
                        }
                        if (Otr.tag == "Mct")// Objeto : Maceta
                        {
                            _Personaje._Estado.Cntd_Macetas++;
                            Otr.GetComponent<Clsn_Objetos>()._Objetos.Dstr = true;
                        }
                        if (Otr.tag == "Ltr")// Objeto : Letra
                        {
                            int prmr = 1;
                            int sgnd = 1;
                            int trcr = 1;
                            switch (Otr.GetComponent<Clsn_Objetos>()._Objetos.name)
                            {
                                case "B":
                                    prmr = 0;
                                    sgnd = 0;
                                    trcr = 0;
                                    break;
                                case "O_1":
                                case "O_2":
                                case "O_3":
                                    prmr = 1;
                                    sgnd = 3;
                                    trcr = 6;
                                    break;
                                case "R":
                                    prmr = 2;
                                    sgnd = 2;
                                    trcr = 2;
                                    break;
                                case "N":
                                    prmr = 4;
                                    sgnd = 4;
                                    trcr = 4;
                                    break;
                                case "D":
                                    prmr = 5;
                                    sgnd = 5;
                                    trcr = 5;
                                    break;
                            }
                            for (int i = 0; i < _Personaje._Estado.Ttl_Letras.Count; i++)
                            {
                                if (_Personaje._Estado.Ttl_Letras[i] == "" && (i == prmr || i == sgnd || i == trcr))
                                {
                                    _Personaje._Estado.Ttl_Letras[i] = Otr.GetComponent<Clsn_Objetos>()._Objetos.name;
                                    i = _Personaje._Estado.Ttl_Letras.Count;
                                }
                            }

                            _Personaje._Estado.EnPlbr = true;
                            _Personaje._Estado.TmpPlbr = 3.3f;
                            Otr.GetComponent<Clsn_Objetos>()._Objetos.Dstr = true;
                        }
                        if (Otr.tag == "ClccnH")// Objeto : Coleccion de Huellas
                        {
                            _Personaje._Estado.Cntd_Huellas += Otr.GetComponent<Clsn_Objetos>()._Objetos._Tipo.Cntd;
                            Otr.GetComponent<Clsn_Objetos>()._Objetos.Dstr = true;
                        }
                        if (Otr.tag == "Alfñq")// Objeto : Alfeñique
                        {
                            switch (_Personaje._Estado.Personaje)
                            {
                                case "Dorotea":
                                    if (_Personaje._Estado.Sld_Dorotea < 3)
                                    {
                                        _Personaje._Estado.Sld_Dorotea++;
                                    }
                                    break;
                                case "Benkos":
                                    if (_Personaje._Estado.Sld_Benkos < 3)
                                    {
                                        _Personaje._Estado.Sld_Benkos++;
                                    }
                                    break;
                            }
                            Otr.GetComponent<Clsn_Objetos>()._Objetos.Dstr = true;
                        }
                        if (Otr.tag == "MMdcnl")// Objeto : Mata Medicinal
                        {
                            switch (_Personaje._Estado.Personaje)
                            {
                                case "Dorotea":
                                    _Personaje._Estado.Sld_Benkos = 3;
                                    break;
                                case "Benkos":
                                    _Personaje._Estado.Sld_Dorotea = 3;
                                    break;
                            }
                            _Personaje._Estado.EnLsn = false;
                            Otr.GetComponent<Clsn_Objetos>()._Objetos.Dstr = true;
                        }
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

        if (Otr.gameObject.layer == 26)
        {
            switch (name)
            {
                case "Cuerpo":
                    if (Prsnj1)
                    {
                        _Personaje._Estado.EnCnmtc = true;
                        _Personaje._Estado.TpCnmtc = Otr.name;
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

        if (Otr.gameObject.layer == 26)
        {
            switch (name)
            {
                case "Cuerpo":
                    if (Prsnj1)
                    {
                        _Personaje._Estado.EnCnmtc = false;
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
