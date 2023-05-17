using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cntrl_Personaje : MonoBehaviour
{
    [Header("General")]
    public GameObject _Personaje;
    public GameObject _Avatar;
    public GameObject _Cuerpo;
    public GameObject _Cola;
    //
    float entrd_H;
    float entrd_V;
    float entrd_Turbo;

    [Header("Composicion")]
    public int TmñMxm;
    [HideInInspector]
    public Rigidbody CrpRgd;
    public Camera Cmr;
    //
    public PrtsCrp_Personaje _PrtCuerpo;
    public int PrtCrp_Mrdd;
    float Vlcd;

    [Header("Referencias")]
    public Estado _Estado;
    public Interfaz2D _Interfaz2D;
    //
    public Cntrl_Entrada _Entrada;
    public PrtsCrp_Personaje[] _PrtsCuerpo;


    [System.Serializable]
    public class Estado
    {
        public bool Auto;
        [HideInInspector]
        public float Dsplzr;

        public int Frutas;
        //
        public int Tamaño_Crp;
        [HideInInspector]
        public int TmñCrp;
        public float Dstncmnt_Prts;

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
        _PrtsCuerpo = new PrtsCrp_Personaje[TmñMxm];
        for (int i = 0; i < _PrtsCuerpo.Length; i++)
        {
            GameObject Prt = Instantiate(_PrtCuerpo.gameObject);
            Prt.transform.parent = _Cuerpo.transform.GetChild(0);
            Prt.transform.position = Vector3.zero;
            Prt.name = "_" + (i + 1);
            Prt.SetActive(false);

            _PrtsCuerpo[i] = Prt.GetComponent<PrtsCrp_Personaje>();
            _PrtsCuerpo[i]._Personaje = GetComponent<Cntrl_Personaje>();
        }
        _PrtsCuerpo[0].transform.GetChild(0).GetChild(0).gameObject.tag = "Vc";
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

        _Cola.GetComponent<PrtsCrp_Personaje>()._Personaje = GetComponent<Cntrl_Personaje>();

        CrpRgd = _Personaje.GetComponent<Rigidbody>();


        Inicio();
    }
    // Update is called once per frame
    void Update()
    {
        entrd_H = _Entrada.Dsplzmnt_H;
        entrd_V = _Entrada.Dspzmnt_V;
        entrd_Turbo = _Entrada.Turbo;
    }
    void FixedUpdate()
    {
        if (!_Estado.EnPausa && !_Estado.Fin)
        {
            //Time.timeScale = 1;

            Rotacion();
            Desplazamiento();
            PartesCuerpo();

            Acciones();
        }
        else
        {
            if (_Estado.Fin)
            {
                MorderCuerpo();
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
    }


    void Inicio()
    {
        _Estado.TmñCrp = 1;
        _Estado.Auto = true;
        _Estado.Dsplzr = 1;
    }
    //
    void Rotacion()
    {
        _Estado.DrccnDsplzmnt = Cmr.transform.forward * entrd_V;
        _Estado.DrccnDsplzmnt += Cmr.transform.right * entrd_H;

        _Estado.DrccnDsplzmnt.y = 0;

        if (_Estado.DrccnDsplzmnt == Vector3.zero)
        {
            _Estado.DrccnDsplzmnt = _Avatar.transform.GetChild(1).forward;
        }

        Quaternion Rtcn = Quaternion.LookRotation(_Estado.DrccnDsplzmnt);
        Rtcn.eulerAngles = new Vector3(0, Rtcn.eulerAngles.y, 0);
        _Avatar.transform.GetChild(1).rotation = Quaternion.Lerp(_Avatar.transform.GetChild(1).rotation, Rtcn, _Estado.Vlcd_Rtcn * Time.deltaTime);
    }
    void Desplazamiento()
    {
        float vlz = 40;

        _Estado.CntdDsplzmnt = Mathf.Clamp(Mathf.Abs(entrd_H) + Mathf.Abs(entrd_V), 0, 1);
        //
        Vector3 Dsplzmnt = Vector3.zero;
        Dsplzmnt = _Avatar.transform.GetChild(1).forward * (_Estado.Dsplzr);

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
        CrpRgd.velocity = (Dsplzmnt * ((Vlcd) * Time.deltaTime));
    }
    //
    void PartesCuerpo()
    {
        if (_Estado.TmñCrp != _Estado.Tamaño_Crp)
        {
            for (int i = 0; i < _Estado.TmñCrp; i++)
            {
                if (_PrtsCuerpo[i].tag != "PrtCrp")
                {
                    if (i == 0)
                    {
                        _PrtsCuerpo[i]._Ancla = _Avatar.transform.GetChild(1).gameObject;
                    }
                    else
                    {
                        _PrtsCuerpo[i]._Ancla = _PrtsCuerpo[i - 1].gameObject;
                    }

                    _PrtsCuerpo[i].transform.parent = _Cuerpo.transform;
                    _PrtsCuerpo[i].transform.position = _PrtsCuerpo[i]._Ancla.transform.position + _PrtsCuerpo[i]._Ancla.transform.forward * -1;
                    _PrtsCuerpo[i].gameObject.SetActive(true);
                    _PrtsCuerpo[i].Dstncmnt_Prt = _Estado.Dstncmnt_Prts;
                    _PrtsCuerpo[i].VlcdSgmnt_Crp = _Estado.Vlcd_Crp;
                    _PrtsCuerpo[i].tag = "PrtCrp";
                }

                if (i == (_Estado.TmñCrp - 1))
                {
                    _Cola.GetComponent<PrtsCrp_Personaje>()._Ancla = _PrtsCuerpo[i].gameObject;
                    _Cola.transform.position = _PrtsCuerpo[i].transform.position + _PrtsCuerpo[i].transform.forward * -1;

                    _Cola.GetComponent<PrtsCrp_Personaje>().Dstncmnt_Prt = _Estado.Dstncmnt_Prts;
                    _Cola.GetComponent<PrtsCrp_Personaje>().VlcdSgmnt_Crp = _Estado.Vlcd_Crp;
                }

                _PrtsCuerpo[i].Id = i;
            }

            _Cola.GetComponent<PrtsCrp_Personaje>().Id = _Cola.GetComponent<PrtsCrp_Personaje>()._Ancla.GetComponent<PrtsCrp_Personaje>().Id;
            _Estado.Tamaño_Crp = _Estado.TmñCrp;
        }
    }
    //
    void MorderCuerpo()
    {
        for (int i = 0; i < _PrtsCuerpo.Length; i++)
        {
            if (PrtCrp_Mrdd > 0)
            {
                if (i > PrtCrp_Mrdd)
                {
                    _PrtsCuerpo[i].VlcdSgmnt_Crp = 0;
                }

                if (_Cola.GetComponent<PrtsCrp_Personaje>().Id == PrtCrp_Mrdd)
                {
                    _Cola.SetActive(false);
                }
                else
                {
                    _PrtsCuerpo[PrtCrp_Mrdd].gameObject.SetActive(false);
                    _PrtsCuerpo[PrtCrp_Mrdd + 1].gameObject.SetActive(false);
                }
            }
            else
            {
                _PrtsCuerpo[i].VlcdSgmnt_Crp = 0;
            }
        }

        _Cola.GetComponent<PrtsCrp_Personaje>().VlcdSgmnt_Crp = 0;
    }
    //
    void Acciones()
    {
        // Velocidad Del Nivel
        float Vlcd_Nivel = 1 + (_Estado.Frutas * .0088f);

        // Turbo
        if (entrd_Turbo > 0)
        {
            _Estado.MltplVlcd = Mathf.Lerp(_Estado.MltplVlcd, (100 * 1.8f) * Vlcd_Nivel, 6 * Time.deltaTime);
        }
        else
        {
            _Estado.MltplVlcd = Mathf.Lerp(_Estado.MltplVlcd, 100 * Vlcd_Nivel, 3.3f * Time.deltaTime);
        }
    }


    void Interfaz()
    {
        _Interfaz2D.EnMenu = _Estado.EnPausa || _Estado.Fin;

        _Interfaz2D.Pntj.text = ": " + _Estado.Frutas;
        _Interfaz2D.Pntj_Mn.text = "" + _Estado.Frutas;
        _Interfaz2D.BtnAtrs_Mn.SetActive(!_Estado.Fin);

        _Interfaz2D.Anmdr_Intrfz.SetBool("Menu", _Interfaz2D.EnMenu);
    }
}
