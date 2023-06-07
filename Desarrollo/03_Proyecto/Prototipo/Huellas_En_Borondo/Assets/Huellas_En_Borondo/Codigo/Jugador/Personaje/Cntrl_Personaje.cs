using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cntrl_Personaje : MonoBehaviour
{
    [Header("General")]
    public GameObject _Personaje_1;
    [HideInInspector]
    public GameObject _Avatar_1;
    public GameObject _Personaje_2;
    [HideInInspector]
    public GameObject _Avatar_2;
    public GameObject _Personaje_G;
    [HideInInspector]
    public GameObject _Avatar_G;
    //
    float entrd_H;
    float entrd_V;
    float entrd_Turbo;
    float entrd_Cambio;

    [Header("Composicion")]
    public int TmñMxm;
    [HideInInspector]
    public Rigidbody CrpRgd_1;
    [HideInInspector]
    public Rigidbody CrpRgd_2;
    [HideInInspector]
    public Rigidbody CrpRgd_G;
    [HideInInspector]
    public GameObject Pdr_Prsnj1;
    [HideInInspector]
    public GameObject Pdr_Prsnj2;
    public Animator Anmdr_Drt;
    public Animator Anmdr_Bnks;
    public Animator Anmdr_Aml;
    public Transform PscnCmpñr;
    public Camera Cmr;
    public GameObject Pnts_Rcrrd;
    public int PntObjtvG;
    public int PntObjtv;
    public float Dstnc_PntObjtvG;
    public float Dstnc_PntObjtv;
    //
    float VlcdRtcn;
    float Vlcd;
    float VlcdLtrl;
    float Ltrl;
    bool ltrlDrch;
    float LtrlDsh;
    float orntrMvmnt;

    float ltrlAml;

    [Header("Referencias")]
    public Estado _Estado;
    public Interfaz2D _Interfaz2D;
    //
    public Cntrl_Entrada _Entrada;


    [System.Serializable]
    public class Estado
    {
        public bool P1_EnSuelo;
        public bool P2_EnSuelo;
        public bool PG_EnSuelo;

        [HideInInspector]
        public float FrzGrvd_P1;
        [HideInInspector]
        public float FrzGrvd_P2;
        [HideInInspector]
        public float FrzGrvd_PG;
        public bool Auto;
        [HideInInspector]
        public float Dsplzr;
        [HideInInspector]
        public float DsplzrG;

        public Vector3 DrccnDsplzmnt;
        public float CntdDsplzmnt;

        public float VlcdGlbl_Prsnj;
        [HideInInspector]
        public float VlcdGlbl_Rl;

        public float Vlcd_Dsplzmnt;
        public float Vlcd_Crp;
        [HideInInspector]
        public float MltplVlcd;
        public float Vlcd_Rtcn;

        public float DrccnDash;
        public float FrzDash;
        [HideInInspector]
        public float TmpDash;
        [HideInInspector]
        public float TmpDash_;

        public bool CmbrPersonaje;

        [Header("Estado Personaje")]
        public string Personaje;
        public bool EnDash;

        [Header("Estado Juego")]
        public bool EnPausa;
        public bool EnJuego;
        public bool Fin;
    }
    [System.Serializable]
    public class Interfaz2D
    {
        public bool EnMenu;

        [Header("General")]
        public TMP_Text Pntj;
        public TMP_Text Pntj_Mn;
        public GameObject BtnAtrs_Mn;

        [Header("Composicion")]
        public Animator Anmdr_Intrfz;
        //
        public GameObject CntrlTctl;
    }


    // Start is called before the first frame update
    void Start()
    {
        _Avatar_1 = _Personaje_1.transform.GetChild(0).gameObject;
        _Avatar_2 = _Personaje_2.transform.GetChild(0).gameObject;
        _Avatar_G = _Personaje_G.transform.GetChild(0).gameObject;
        CrpRgd_1 = _Personaje_1.GetComponent<Rigidbody>();
        CrpRgd_2 = _Personaje_2.GetComponent<Rigidbody>();
        CrpRgd_G = _Personaje_G.GetComponent<Rigidbody>();
        Pdr_Prsnj1 = Anmdr_Drt.transform.parent.gameObject;
        Pdr_Prsnj2 = Anmdr_Bnks.transform.parent.gameObject;


        Inicio();
    }
    // Update is called once per frame
    void Update()
    {
        entrd_H = _Entrada.Dsplzmnt_H;
        entrd_V = _Entrada.Dspzmnt_V;
        entrd_Turbo = _Entrada.Turbo;
        entrd_Cambio = Input.GetAxisRaw("Cambiar");
    }
    void FixedUpdate()
    {
        Gravedad();

        // Distancia del punto de recorrido proximo
        Dstnc_PntObjtvG = Vector3.Distance(new Vector3(_Personaje_G.transform.position.x, 0, _Personaje_G.transform.position.z),
            new Vector3(Pnts_Rcrrd.transform.GetChild(PntObjtvG).position.x, 0, Pnts_Rcrrd.transform.GetChild(PntObjtvG).position.z));
        Dstnc_PntObjtv = Vector3.Distance(new Vector3(_Personaje_1.transform.position.x, 0, _Personaje_1.transform.position.z),
            new Vector3(Pnts_Rcrrd.transform.GetChild(PntObjtv).position.x, 0, Pnts_Rcrrd.transform.GetChild(PntObjtv).position.z));

        if (!_Estado.EnPausa && !_Estado.Fin)
        {
            //Time.timeScale = 1;

            Personaje_1();
            Personaje_2();
            Personaje_Guia();
        }
        else
        {
            if (_Estado.Fin)
            {

            }
            if (_Estado.EnPausa)
            {
                //Time.timeScale = 0;
            }
            else
            {
                //Time.timeScale = 1;
            }
        }

        Interfaz();
        Time.timeScale = 1;
    }


    void Inicio()
    {
        _Estado.Auto = true;
        _Estado.Dsplzr = 1;
        _Estado.DsplzrG = 1;
        _Estado.Personaje = "Dorotea";
    }
    

    void Gravedad()
    {
        float frzGrvd = 11;
        float vlcdG = 8;

        if (_Estado.P1_EnSuelo)
        {
            _Estado.FrzGrvd_P1 = Mathf.MoveTowards(_Estado.FrzGrvd_P1, 0, vlcdG * Time.deltaTime);
        }
        else
        {
            _Estado.FrzGrvd_P1 = Mathf.MoveTowards(_Estado.FrzGrvd_P1, -frzGrvd, vlcdG * Time.deltaTime);
        }


        if (_Estado.P2_EnSuelo)
        {
            _Estado.FrzGrvd_P2 = Mathf.MoveTowards(_Estado.FrzGrvd_P2, 0, vlcdG * Time.deltaTime);
        }
        else
        {
            _Estado.FrzGrvd_P2 = Mathf.MoveTowards(_Estado.FrzGrvd_P2, -frzGrvd, vlcdG * Time.deltaTime);
        }


        if (_Estado.PG_EnSuelo)
        {
            _Estado.FrzGrvd_PG = Mathf.MoveTowards(_Estado.FrzGrvd_PG, 0, vlcdG * Time.deltaTime);
        }
        else
        {
            _Estado.FrzGrvd_PG = Mathf.MoveTowards(_Estado.FrzGrvd_PG, -frzGrvd, vlcdG * Time.deltaTime);
        }
    }
    //
    void Personaje_1()
    {
        Rotacion();
        Desplazamiento();

        Acciones();
        Animacion();
    }
    void Personaje_2()
    {
        // Rotacion
        _Personaje_2.transform.GetChild(1).LookAt(PscnCmpñr.position);
        Quaternion Rtr = _Personaje_2.transform.GetChild(1).rotation;
        Rtr.eulerAngles = new Vector3(0, Rtr.eulerAngles.y, 0);
        //
        _Personaje_2.transform.GetChild(2).rotation = Quaternion.Lerp(_Personaje_2.transform.GetChild(2).rotation, Rtr, (_Estado.Vlcd_Rtcn * .6f) * Time.deltaTime);
        _Avatar_2.transform.rotation = Quaternion.Lerp(_Avatar_2.transform.rotation, _Personaje_2.transform.GetChild(2).rotation, (_Estado.Vlcd_Rtcn * 1.5f) * Time.deltaTime);

        // Movimiento
        float DstncObjtv = Vector3.Distance(_Personaje_2.transform.position, PscnCmpñr.position);
        float VlcdSgr = .4f;
        if (DstncObjtv > .5)
        {
            if (DstncObjtv < 4)
            {
                VlcdSgr = 1.1f;
            }
            else if (DstncObjtv < 6)
            {
                VlcdSgr = 1.7f;
            }
            else
            {
                VlcdSgr = 4f;
            }
        }
        Vector3 Dsplzmnt = ((PscnCmpñr.position - _Personaje_2.transform.position).normalized * (_Estado.Dsplzr) * ((Vlcd * VlcdSgr) * Time.deltaTime));

        float Grvd = 0;
        Grvd = _Estado.FrzGrvd_P2;
        CrpRgd_2.velocity = (Dsplzmnt) + (Vector3.up * Grvd);
    }
    void Personaje_Guia()
    {
        // Rotacion
        _Personaje_G.transform.GetChild(1).LookAt(Pnts_Rcrrd.transform.GetChild(PntObjtvG).position);
        Quaternion Rtr = _Personaje_G.transform.GetChild(1).rotation;
        Rtr.eulerAngles = new Vector3(0, Rtr.eulerAngles.y, 0);
        //
        if (Dstnc_PntObjtvG > .5)
        {

        }
        else
        {
            if (PntObjtvG == Pnts_Rcrrd.transform.childCount - 1)// Ultimo punto de recorrido
            {
                _Estado.DsplzrG = 0;
            }
            else
            {
                PntObjtvG++;
            }
        }
        //
        _Personaje_G.transform.GetChild(2).rotation = Quaternion.Lerp(_Personaje_G.transform.GetChild(2).rotation, Rtr, (_Estado.Vlcd_Rtcn * .6f) * Time.deltaTime);
        if (_Estado.DsplzrG > 0)
        {
            _Avatar_G.transform.rotation = Quaternion.Lerp(_Avatar_G.transform.rotation, _Personaje_G.transform.GetChild(2).rotation, (_Estado.Vlcd_Rtcn * .38f) * 
                Time.deltaTime);
        }

        // Movimiento
        float vlz = 40;
        //
        Vector3 Dsplzmnt = Vector3.zero;
        Dsplzmnt = _Personaje_G.transform.GetChild(2).forward * (_Estado.DsplzrG);

        if (_Estado.Auto)
        {
            Vlcd = Mathf.Lerp(Vlcd, (_Estado.Vlcd_Dsplzmnt * _Estado.MltplVlcd) * _Estado.VlcdGlbl_Prsnj, vlz * Time.deltaTime);
        }
        else
        {
            if (_Estado.CntdDsplzmnt > 0)
            {
                Vlcd = Mathf.Lerp(Vlcd, (_Estado.Vlcd_Dsplzmnt * _Estado.MltplVlcd) * _Estado.VlcdGlbl_Rl, vlz * Time.deltaTime);
            }
            else
            {
                Vlcd = Mathf.Lerp(Vlcd, 0, (vlz * .3f) * Time.deltaTime);
            }
        }
        //
        CrpRgd_G.velocity = (Dsplzmnt * ((Vlcd) * Time.deltaTime)) + (Vector3.up * _Estado.FrzGrvd_PG);
    }


    void Rotacion()
    {
        // Rotacion
        _Personaje_1.transform.GetChild(1).LookAt(Pnts_Rcrrd.transform.GetChild(PntObjtv).position);
        Quaternion Rtr = _Personaje_1.transform.GetChild(1).rotation;
        Rtr.eulerAngles = new Vector3(0, Rtr.eulerAngles.y, 0);
        //
        if (Dstnc_PntObjtv > .5)
        {
            
        }
        else
        {
            if (PntObjtv == Pnts_Rcrrd.transform.childCount - 1)// Ultimo punto de recorrido
            {
                _Estado.Auto = false;
                _Estado.Dsplzr = 0;
            }
            else
            {
                PntObjtv++;
            }
        }
        //
        _Personaje_1.transform.GetChild(2).rotation = Quaternion.Lerp(_Personaje_1.transform.GetChild(2).rotation, Rtr, (_Estado.Vlcd_Rtcn * .6f) * Time.deltaTime);
        _Avatar_1.transform.rotation = Quaternion.Lerp(_Avatar_1.transform.rotation, _Personaje_1.transform.GetChild(2).rotation, (_Estado.Vlcd_Rtcn * .38f) * Time.deltaTime);


        // Orientacion
        float vlcdOrtcn = 0;
        //
        if (entrd_H < 0)
        {
            vlcdOrtcn = _Estado.Vlcd_Rtcn * .6f;
            orntrMvmnt = -35;
        }
        else if (entrd_H > 0)
        {
            vlcdOrtcn = _Estado.Vlcd_Rtcn * .6f;
            orntrMvmnt = 35;
        }
        else
        {
            vlcdOrtcn = _Estado.Vlcd_Rtcn * 1.4f;
            orntrMvmnt = 0;
        }
        //
        Quaternion Orntr = _Avatar_1.transform.GetChild(1).localRotation;
        Orntr.eulerAngles = new Vector3(0, orntrMvmnt, 0);
        //
        if (entrd_H <=  -1)
        {
            if (entrd_H <= -.7)
            {
                Ltrl = Mathf.Lerp(Ltrl, -1, 3.3f * Time.deltaTime);
            }
            VlcdLtrl = Mathf.Lerp(VlcdLtrl, -1, 5 * Time.deltaTime);
            
        }
        if (entrd_H >= 1)
        {
            if (entrd_H >= .7)
            {
                Ltrl = Mathf.Lerp(Ltrl, 1, 3.3f * Time.deltaTime);
            }
            VlcdLtrl = Mathf.Lerp(VlcdLtrl, 1, 5 * Time.deltaTime);
        }
        if (entrd_H > -1 && entrd_H < 1) 
        {
            if (entrd_H > -.7 && entrd_H < .7)
            {
                Ltrl = Mathf.Lerp(Ltrl, 0, 11.6f * Time.deltaTime);
            }
            VlcdLtrl = Mathf.Lerp(VlcdLtrl, 0, 11.6f * Time.deltaTime);
        }
        _Avatar_1.transform.GetChild(1).rotation = Quaternion.Lerp(_Avatar_1.transform.GetChild(1).rotation, _Personaje_1.transform.GetChild(2).rotation,
                vlcdOrtcn * Time.deltaTime);
        _Avatar_1.transform.GetChild(1).GetChild(1).localRotation = Quaternion.Lerp(_Avatar_1.transform.GetChild(1).GetChild(1).localRotation, Orntr,
            (vlcdOrtcn * 1.3f) * Time.deltaTime);
    }
    void Desplazamiento()
    {
        float vlz = 40;

        // Movimiento Frontal
        _Estado.CntdDsplzmnt = Mathf.Clamp(Mathf.Abs(entrd_H) + Mathf.Abs(entrd_V), 0, 1);
        //
        Vector3 Dsplzmnt = Vector3.zero;
        Dsplzmnt = _Personaje_1.transform.GetChild(2).forward * (_Estado.Dsplzr);

        if (_Estado.Auto)
        {
            Vlcd = Mathf.Lerp(Vlcd, (_Estado.Vlcd_Dsplzmnt * _Estado.MltplVlcd) * _Estado.VlcdGlbl_Prsnj, vlz * Time.deltaTime);
        }
        else
        {
            if (_Estado.CntdDsplzmnt > 0)
            {
                Vlcd = Mathf.Lerp(Vlcd, (_Estado.Vlcd_Dsplzmnt * _Estado.MltplVlcd) * _Estado.VlcdGlbl_Rl, vlz * Time.deltaTime);
            }
            else
            {
                Vlcd = Mathf.Lerp(Vlcd, 0, (vlz * .3f) * Time.deltaTime);
            }
        }
        //
        float Grvd = 0;
        Grvd = _Estado.FrzGrvd_P1;
        CrpRgd_1.velocity = (Dsplzmnt * ((Vlcd) * Time.deltaTime)) + (Vector3.up * Grvd);

        // Movimiento Lateral
        _Avatar_1.transform.GetChild(1).localPosition += new Vector3(((VlcdLtrl * 1.1f) * (Vlcd * .02f) * Time.deltaTime) + (_Estado.FrzDash * Time.deltaTime), 0, 0);
    }
    //
    void Acciones()
    {
        // Velocidad Del Nivel
        float Vlcd_Nivel = 1;


        // Dash
        float frzDsh = 20;
        float tmpDsh = .2f;
        if (_Estado.Personaje == "Dorotea")
        {
            frzDsh = 10;
            tmpDsh = .2f;
        }
        else if (_Estado.Personaje == "Benkos")
        {
            frzDsh = 48;
            tmpDsh = .08f;
        }
        //
        if (entrd_H > 0)
        {
            ltrlDrch = true;
        }
        else
        {
            ltrlDrch = false;
        }
        //
        if (entrd_Turbo > 0)
        {
            if (_Estado.TmpDash == 0)
            {
                _Estado.EnDash = true;
                if (entrd_H < 0)
                {
                    _Estado.FrzDash = -frzDsh;
                }
                else if (entrd_H > 0)
                {
                    _Estado.FrzDash = frzDsh;
                }
                else
                {
                    _Estado.FrzDash = -frzDsh;
                }
                _Estado.DrccnDash = -1;
                LtrlDsh = ltrlDrch ? 1 : -1;
                _Estado.TmpDash_ = .2f;

                _Estado.TmpDash = .01f;
            }
        }
        else
        {
            if (_Estado.DrccnDash == 0)
            {
                _Estado.TmpDash = 0;
            }
        }
        //
        if (_Estado.TmpDash > 0 && _Estado.TmpDash <= tmpDsh)
        {
            _Estado.TmpDash += 1 * Time.deltaTime;
        }
        else
        {
            _Estado.EnDash = false;
        }
        //
        if (_Estado.EnDash)
        {
            
        }
        else
        {
            if (_Estado.TmpDash_ > 0)
            {
                _Estado.TmpDash_ -= 1 * Time.deltaTime;
            }
            else
            {
                _Estado.DrccnDash = 0;
            }
            _Estado.FrzDash = 0;

            if (entrd_H != 0)
            {
                _Estado.MltplVlcd = Mathf.Lerp(_Estado.MltplVlcd, (100 * .6f) * Vlcd_Nivel, 4.4f * Time.deltaTime);
            }
            else
            {
                _Estado.MltplVlcd = Mathf.Lerp(_Estado.MltplVlcd, 100 * Vlcd_Nivel, 3.3f * Time.deltaTime);
            }
        }


        // Cambio de Personaje
        float vlcdCmb = 2;
        if (entrd_Cambio > 0)
        {
            if (!_Estado.CmbrPersonaje)
            {
                if (_Estado.Personaje == "Dorotea")
                {
                    _Estado.Personaje = "Benkos";
                }
                else if (_Estado.Personaje == "Benkos")
                {
                    _Estado.Personaje = "Dorotea";
                }
                GameObject Prsnj1 = Pdr_Prsnj2.transform.GetChild(0).gameObject;
                GameObject Prsnj2 = Pdr_Prsnj1.transform.GetChild(0).gameObject;
                Pdr_Prsnj1.transform.GetChild(0).parent = Pdr_Prsnj2.transform;
                Pdr_Prsnj2.transform.GetChild(0).parent = Pdr_Prsnj1.transform;

                _Estado.CmbrPersonaje = true;
            }
        }
        else
        {
            _Estado.CmbrPersonaje = false;
        }
        //
        Pdr_Prsnj1.transform.GetChild(0).localRotation = Quaternion.identity;
        Pdr_Prsnj1.transform.GetChild(0).localPosition = Vector3.Lerp(Pdr_Prsnj1.transform.GetChild(0).localPosition, Vector3.zero, vlcdCmb * Time.deltaTime);
        Pdr_Prsnj2.transform.GetChild(0).localRotation = Quaternion.identity;
        Pdr_Prsnj2.transform.GetChild(0).localPosition = Vector3.Lerp(Pdr_Prsnj2.transform.GetChild(0).localPosition, Vector3.zero, vlcdCmb * Time.deltaTime);
    }


    void Interfaz()
    {
        _Interfaz2D.EnMenu = _Estado.EnPausa || _Estado.Fin;

        _Interfaz2D.BtnAtrs_Mn.SetActive(!_Estado.Fin);

        _Interfaz2D.Anmdr_Intrfz.SetBool("Menu", _Interfaz2D.EnMenu);
    }
    void Animacion()
    {
        Animator A_Prsnj1 = Anmdr_Drt;
        Animator A_Prsnj2 = Anmdr_Bnks;
        Animator A_PrsnjG = Anmdr_Aml;
        switch (_Estado.Personaje)
        {
            case "Dorotea":
                A_Prsnj1 = Anmdr_Drt;
                A_Prsnj2 = Anmdr_Bnks;
                break;
            case "Benkos":
                A_Prsnj1 = Anmdr_Bnks;
                A_Prsnj2 = Anmdr_Drt;
                break;
        }

        // Personaje 1
        A_Prsnj1.SetBool("EnMovimiento", _Estado.Dsplzr > 0);
        A_Prsnj1.SetFloat("Lateral", Ltrl);
        A_Prsnj1.SetFloat("DrccnDash", _Estado.DrccnDash);
        A_Prsnj1.SetFloat("LtrlDash", LtrlDsh);

        // Personaje 2
        A_Prsnj2.SetBool("EnMovimiento", _Estado.Dsplzr > 0);
        A_Prsnj2.SetFloat("Lateral", Ltrl);
        A_Prsnj2.SetFloat("DrccnDash", 0);
        A_Prsnj2.SetFloat("LtrlDash", LtrlDsh);

        // Personaje Guia
        ltrlAml = Mathf.Lerp(ltrlAml, Ltrl, 2.36f * Time.deltaTime);
        A_PrsnjG.SetBool("EnMovimiento", _Estado.DsplzrG > 0);
        A_PrsnjG.SetFloat("Lateral", ltrlAml);
    }
}
