using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Villano : MonoBehaviour
{
    public static bool Reiniciar;
    public static bool Pausar;
    public static bool Confrontacion;
    public static bool Agotado;
    public static bool Triunfar;
    public float tmp;

    [Header("General")]
    public GameObject _PersonajeV;
    [HideInInspector]
    public GameObject _Avatar;
    Transform FBX;
    Transform HjFBX;
    public bool Confronta;
    public bool Accion;
    public bool Atacando;
    public bool Poder;

    [Header("Composicion")]
    public Animator Anmdr;
    public GameObject SñlDspr_Pdr;
    public Transform Nubes;
    public Transform Objtv_Persecucion;
    [HideInInspector]
    public Transform Objtv;
    Vector3 PntObjtv;
    int TpPdr;
    public GameObject Pdr;
    public GameObject Pdr_Estun;
    public GameObject Pdr_Nube;
    public GameObject[] Pdr_Division;
    int PscnPdrDvsn;
    //
    public float Vlcd_Rtcn;
    public float Vlcd_Mvmnt;
    float TmpAgtd;
    //
    Vector3 Altr;
    float Dstncd;
    float TmpLnzrPdr;
    float TmpPdr;
    float DrccnPdr;
    public LayerMask Capa;

    [Header("Estados")]
    public bool EnVuelo;
    public bool EnSuelo;
    public bool LnzrPoder;
    public bool Agotamiento;

    // Start is called before the first frame update
    void Start()
    {
        tmp = 1;
        Objtv = Objtv_Persecucion.parent.parent.GetChild(1);
        _Avatar = _PersonajeV.transform.GetChild(0).gameObject;
        FBX = _Avatar.transform.GetChild(1).GetChild(1);

        TpPdr = 3;
        SñlDspr_Pdr.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Rayo();
        Confrontar();

        Rotacion();
        Movimiento();
        if (Atacando || Confronta)
        {
            Habilidades();
        }
        if (Agotado)
        {
            EnVuelo = false;
            Agotar();
        }
        else
        {
            EnVuelo = true;
        }

        Animaciones();

        if (Reiniciar)
        {
            Reinicio();
        }
        Pausa();
    }

    void Reinicio()
    {
        Anmdr.Rebind();

        Atacando = false;
        Agotado = false;
        Triunfar = false;
        tmp = 1;
        for (int i = 0; i < Nubes.childCount; i++)
        {
            Nubes.GetChild(i).GetComponent<Mnj_NubeV>().Tmp = 1;
            Nubes.GetChild(i).GetComponent<Mnj_NubeV>().Oculta = false;
        }
        if (HjFBX != null)
        {
            HjFBX.GetChild(1).localPosition = new Vector3(0, 5.25f, 0);
            HjFBX.parent = FBX.GetChild(0);
            HjFBX.localPosition = Vector3.zero;
            HjFBX.localRotation = Quaternion.identity;
            HjFBX = null;
        }
        SñlDspr_Pdr.SetActive(false);
        Accion = false;
        TmpAgtd = 0;
        TmpLnzrPdr = 0;
        TmpPdr = 0;

        EnVuelo = false;
        EnSuelo = false;
        LnzrPoder = false;
        Agotamiento = false;

        Reiniciar = false;
    }
    void Pausa()
    {
        if (Pausar)
        {
            tmp = 0;
            for (int i = 0; i < Nubes.childCount; i++)
            {
                Nubes.GetChild(i).GetComponent<Mnj_NubeV>().Tmp = 0;
            }

            Anmdr.speed = 0;
        }
        else
        {
            tmp = 1;
            for (int i = 0; i < Nubes.childCount; i++)
            {
                Nubes.GetChild(i).GetComponent<Mnj_NubeV>().Tmp = 1;
            }

            Anmdr.speed = 1;
        }
    }

    void Rayo()
    {
        RaycastHit ryCrp;
        float dstncRyCrp = 622;

        if (Physics.Raycast(FBX.position + (FBX.up * 100), -FBX.up, out ryCrp, dstncRyCrp, Capa))
        {
            //Debug.DrawLine(FBX.position + (FBX.up * 100), ryCrp.point, Color.blue);
            Altr = new Vector3(0, ryCrp.point.y, 0);
        }
    }
    void Rotacion()
    {
        float inclncnA = 0;
        if (EnVuelo)
        {
            if (Confronta)
            {
                inclncnA = -77;
            }
            else
            {
                inclncnA = -44;
            }
        }
        else
        {
            inclncnA = 0;
        }

        _PersonajeV.transform.GetChild(1).LookAt(Objtv_Persecucion.position);
        Quaternion Rtcn = _PersonajeV.transform.GetChild(1).rotation;
        Rtcn.eulerAngles = new Vector3(Objtv_Persecucion.eulerAngles.x, Rtcn.eulerAngles.y, Objtv_Persecucion.eulerAngles.z);

        _PersonajeV.transform.rotation = Quaternion.Lerp(_Avatar.transform.rotation, Rtcn, Vlcd_Rtcn * Time.deltaTime);
        Quaternion rtcnA = Anmdr.transform.localRotation;
        rtcnA.eulerAngles = new Vector3(inclncnA, 0, 0);
        Anmdr.transform.localRotation = Quaternion.Lerp(Anmdr.transform.localRotation, rtcnA, 3 * (Time.deltaTime * tmp));
    }
    void Movimiento()
    {
        if (Accion)
        {
            Dstncd = 1.1f;
        }
        else
        {
            if (!Confronta)
            {
                Dstncd = -66;
            }
            else
            {
                Dstncd = -8;
            }
        }

        _PersonajeV.transform.position = Vector3.Lerp(_PersonajeV.transform.position, Objtv_Persecucion.position + (-Objtv_Persecucion.forward * 33), 
            Vlcd_Mvmnt * (Time.deltaTime * tmp));

        FBX.position = Vector3.Lerp(FBX.position, Objtv_Persecucion.position + (Objtv_Persecucion.forward * Dstncd), Vlcd_Mvmnt * (Time.deltaTime * tmp));
        Vector3 pscnrAltr = FBX.GetChild(0).position;
        pscnrAltr = new Vector3(pscnrAltr.x, Altr.y, pscnrAltr.z);
        FBX.GetChild(0).position = Vector3.Lerp(FBX.GetChild(0).position, pscnrAltr, (Vlcd_Mvmnt * .7f) * (Time.deltaTime * tmp));
        FBX.GetChild(0).localPosition = new Vector3(0, FBX.GetChild(0).localPosition.y, 0);
    }
    void Confrontar()
    {
        Confronta = Confrontacion;
        float vlcdRtr = 1.8f;
        if (Confronta)
        {
            Quaternion rtr = Objtv_Persecucion.parent.transform.localRotation;
            rtr.eulerAngles = new Vector3(0, 180, 0);
            Objtv_Persecucion.parent.transform.localRotation = Quaternion.Lerp(Objtv_Persecucion.parent.transform.localRotation, rtr, vlcdRtr *(Time.deltaTime * tmp));
        }
        else
        {
            Objtv_Persecucion.parent.transform.localRotation = Quaternion.Lerp(Objtv_Persecucion.parent.transform.localRotation, Quaternion.identity,
                vlcdRtr * (Time.deltaTime * tmp));
        }
    }
    void Habilidades()
    {
        float tmpUsrPdr = 4;
        if (Confronta)
        {
            tmpUsrPdr = 1f;
        }

        if (Accion || (Confronta && !Agotado))
        {
            if (TmpLnzrPdr <= 0)
            {
                LnzrPoder = false;
                Pdr_Estun.SetActive(false);
                Pdr_Nube.SetActive(false);
                Pdr_Estun.transform.parent.GetChild(0).gameObject.SetActive(false);
                Pdr_Nube.transform.parent.GetChild(0).gameObject.SetActive(false);
                Pdr_Division[0].transform.parent.gameObject.SetActive(false);

                Pdr_Estun.transform.parent.localPosition = Vector3.zero;
                Pdr_Nube.transform.parent.localPosition = Vector3.zero;
                float pscnX_PD = 0;
                switch (PscnPdrDvsn)
                {
                    case 0:
                        pscnX_PD = 3;
                        break;
                    case 2:
                        pscnX_PD = -3;
                        break;
                }
                Pdr_Division[PscnPdrDvsn].transform.localPosition = new Vector3(pscnX_PD, 0, 0);


                if (Confronta)
                {
                    TpPdr = 3;
                }
                else
                {
                    TpPdr = Random.Range(4, 13);

                    switch (TpPdr)
                    {
                        case 3:
                        case 6:
                        case 7:
                        case 4:
                        case 12:
                            TpPdr = 2;
                            break;
                        case 5:
                        case 9:
                        case 10:
                        case 11:
                        case 8:
                        case 13:
                            TpPdr = 1;
                            break;
                    }
                }
                TmpLnzrPdr = .01f;
            }
            else
            {
                TmpLnzrPdr += 1 * (Time.deltaTime * tmp);

                if (TmpLnzrPdr >= tmpUsrPdr * .66)
                {
                    SñlDspr_Pdr.SetActive(!Poder && !Confronta);
                    Pdr_Estun.SetActive(TpPdr == 1);
                    Pdr_Nube.SetActive(TpPdr == 2);

                    Pdr.transform.position = Objtv.position;
                }
                if (TmpLnzrPdr >= tmpUsrPdr)
                {
                    Pdr_Estun.transform.parent.GetChild(0).gameObject.SetActive(TpPdr == 1);
                    Pdr_Nube.transform.parent.GetChild(0).gameObject.SetActive(TpPdr == 2);
                    Pdr_Division[0].transform.parent.gameObject.SetActive(TpPdr == 3);

                    if (!Poder)
                    {
                        PscnPdrDvsn = Random.Range(0, Pdr_Division.Length - 1);
                        SñlDspr_Pdr.SetActive(false);
                        PntObjtv = Pdr.transform.GetChild(0).position;

                        if (!Confronta)
                        {
                            TmpPdr = 2.8f;
                        }
                        else
                        {
                            TmpPdr = .8f;
                        }
                        Poder = true;
                    }
                    else
                    {
                        LnzrPoder = true;
                    }
                    //
                    if (TmpPdr > 2.8f * .96f)
                    {
                        if (TpPdr != 3)
                        {
                            PntObjtv = Pdr.transform.GetChild(0).position;
                        }
                    }
                }
            }

            if (Poder)
            {
                switch (TpPdr)
                {
                    case 1:
                        Pdr_Estun.transform.parent.position = Vector3.Lerp(Pdr_Estun.transform.parent.position, PntObjtv, 3.3f * (Time.deltaTime * tmp));
                        break;
                    case 2:
                        Pdr_Nube.transform.parent.position = Vector3.Lerp(Pdr_Nube.transform.parent.position, PntObjtv, 6.4f * (Time.deltaTime * tmp));
                        break;
                    case 3:
                        Pdr_Division[PscnPdrDvsn].transform.localPosition = Pdr_Division[PscnPdrDvsn].transform.localPosition + Vector3.forward *
                            (18 * (Time.deltaTime * tmp));
                        break;
                }
            }
            if (TmpPdr > 0)
            {
                TmpPdr -= 1 * (Time.deltaTime * tmp);
            }
            else
            {
                if (TmpLnzrPdr >= tmpUsrPdr)
                {
                    Poder = false;
                    TmpLnzrPdr = 0;
                    TmpPdr = 0;
                }
            }
        }
        else
        {
            SñlDspr_Pdr.SetActive(false);
            Pdr_Estun.SetActive(false);
            Pdr_Nube.SetActive(false);
            Pdr_Estun.transform.parent.GetChild(0).gameObject.SetActive(false);
            Pdr_Nube.transform.parent.GetChild(0).gameObject.SetActive(false);

            Poder = false;
            TmpLnzrPdr = 0;
            TmpPdr = 0;
        }
    }
    void Agotar()
    {
        if (TmpAgtd == 0)
        {
            for (int i = 0; i < Nubes.childCount; i++)
            {
                Nubes.GetChild(i).GetComponent<Mnj_NubeV>().Oculta = true;
            }
            HjFBX = FBX.GetChild(0).GetChild(0);
            FBX.GetChild(0).GetChild(0).parent = null;
            TmpAgtd = .01f;
        }
        if (HjFBX != null)
        {
            HjFBX.GetChild(1).localPosition = Vector3.Lerp(HjFBX.GetChild(1).localPosition, Vector3.zero, 1.8f * (Time.deltaTime * tmp));
        }
    }

    void Animaciones()
    {
        Anmdr.SetBool("Vuelo", EnVuelo);
        Anmdr.SetBool("Poder", LnzrPoder);
        Anmdr.SetBool("EnSuelo", EnSuelo);
        Anmdr.SetBool("Agotamiento", Agotamiento);
    }
}
