using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Cinematica : MonoBehaviour
{
    public bool rstCmr;

    [Header("General")]
    public bool ElmntVc;
    public bool CrearCinematica;
    public bool Restablecer;
    [HideInInspector]
    public bool Rstblcd;
    public bool Cinematica;

    [Header("Composicion")]
    public Pivotes _Pivotes;
    public KinematicaInversa _KnmtcInvrs;
    public Animator _Animador;

    [Header("Referencias")]
    public Estados _Estados;
    //
    public Almcn_Objetos _AlmacenObjetos;



    [System.Serializable]
    public class Pivotes
    {
        [Header("Control")]
        public Transform Camara;
        public Transform Chiva;
        public Transform Amelia;
        public Transform Dorotea;
        public Transform Benkos;

        [Header("Objeto")]
        public Transform _Camara; public Vector3 Pscn_Cmr, Escl_Cmr; public Quaternion Rtcn_Cmr;
        public Transform _Chiva; [HideInInspector] public Transform _Chv;
        public Transform _Amelia; public Vector3 Pscn_Aml, Escl_Aml; public Quaternion Rtcn_Aml;
        public Transform _Dorotea; public Vector3 Pscn_Drt, Escl_Drt; public Quaternion Rtcn_Drt;
        public Transform _Benkos; public Vector3 Pscn_Bnks, Escl_Bnks; public Quaternion Rtcn_Bnks;
    }
    [System.Serializable]
    public class KinematicaInversa
    {
        [Header("Control")]
        public string cntrl;
        [Header("Amelia")]
        public Transform Cbz_Aml;
        [Header("Dorotea")]
        public Transform Cbz_Drt;
        [Header("Benkos")]
        public Transform Cbz_Bnks;

        [Header("Objeto")]
        public string objt;
        [Header("Amelia")]
        public Transform _Cbz_Aml;
        [Header("Dorotea")]
        public Transform _Cbz_Drt;
        [Header("Benkos")]
        public Transform _Cbz_Bnks;
    }
    [System.Serializable]
    public class Estados
    {
        [Header("En la Cinematica")]
        public bool InicoBorondo;
        public bool ObtencionMacetas;
        public bool DespojeSombraOlvido;
    }

    // Start is called before the first frame update
    void Start()
    {
        Restablecer = true;
        Rstblcd = false;
        rstCmr = false;
    }
    // Update is called once per frame
    void Update()
    {
        Cinematografia();
    }
    void FixedUpdate()
    {
        //Cinematografia();
    }


    void Cinematografia()
    {
        ElmntVc =
            _Pivotes._Camara == null || _Pivotes._Chiva == null || _Pivotes._Amelia == null || _Pivotes._Dorotea == null || _Pivotes._Benkos == null ?
            true : false;
        CrearCinematica = false;


        if (!Restablecer)
        {
            if (Cinematica)
            {
                Cinematica_Objetos();
            }
            else
            {
                RstblcrCmr();
            }
        }
        else
        {
            Restablecer_Objetos();
            Rstblcd = true;
            Restablecer = false;
        }

        // Scuencia
        Animacion();
    }
    void OnDrawGizmos()// Pre-Visualizar Animacion
    {
        if (!Application.isPlaying)
        {
            ElmntVc =
            _Pivotes._Camara == null || _Pivotes._Chiva == null || _Pivotes._Amelia == null || _Pivotes._Dorotea == null || _Pivotes._Benkos == null ?
            true : false;
            Cinematica = false;

            if (CrearCinematica)
            {
                Cinematica_Objetos();
                Restablecer = false;
            }
            else
            {
                if (Restablecer)
                {
                    Restablecer_Objetos();
                    Restablecer = false;
                }
            }
        }
    }

    public void Reinicio()
    {
        _Estados.InicoBorondo = false;
        _Estados.ObtencionMacetas = false;
        _Estados.DespojeSombraOlvido = false;

        Restablecer = true;
    }

    void Cinematica_Objetos()
    {
        if (!ElmntVc)
        {
            // Crear
            if (_Pivotes._Chv == null)
            {
                if (!Application.isPlaying)
                {
                    GameObject objt = Instantiate(_Pivotes._Chiva.gameObject);
                    objt.name = "Chiva ()";
                    _Pivotes._Chv = objt.transform;
                }
                else
                {
                    for (int i = 0; i < _AlmacenObjetos.Cj_Transportes.transform.childCount; i++)
                    {
                        if (_AlmacenObjetos.Cj_Transportes.transform.GetChild(i).name == _AlmacenObjetos._Chiva.name)
                        {
                            _Pivotes._Chv = _AlmacenObjetos.Cj_Transportes.transform.GetChild(i);
                            _Pivotes._Chv.gameObject.SetActive(true);
                        }
                    }
                }
            }



            // Posicionar
            _Pivotes._Camara.position = _Pivotes.Camara.position;
            _Pivotes._Camara.rotation = _Pivotes.Camara.rotation;
            _Pivotes._Camara.localScale = _Pivotes.Camara.localScale;

            _Pivotes._Chv.position = _Pivotes.Chiva.position;
            _Pivotes._Chv.rotation = _Pivotes.Chiva.rotation;
            _Pivotes._Chv.localScale = _Pivotes.Chiva.localScale;

            _Pivotes._Amelia.position = _Pivotes.Amelia.position;
            _Pivotes._Amelia.rotation = _Pivotes.Amelia.rotation;
            _Pivotes._Amelia.localScale = _Pivotes.Amelia.localScale;

            _Pivotes._Dorotea.position = _Pivotes.Dorotea.position;
            _Pivotes._Dorotea.rotation = _Pivotes.Dorotea.rotation;
            _Pivotes._Dorotea.localScale = _Pivotes.Dorotea.localScale;

            _Pivotes._Benkos.position = _Pivotes.Benkos.position;
            _Pivotes._Benkos.rotation = _Pivotes.Benkos.rotation;
            _Pivotes._Benkos.localScale = _Pivotes.Benkos.localScale;
        }
        else
        {
            Debug.Log("Hay Elemento Vacio");
        }
    }
    //
    public void Restablecer_Objetos()
    {
        if (!ElmntVc)
        {
            if (_Pivotes._Chv != null)
            {
                if (_Pivotes._Chv.gameObject.name == "Chiva ()")
                {
                    DestroyImmediate(_Pivotes._Chv.gameObject);
                }
                else
                {
                    _Pivotes._Chv.gameObject.SetActive(false);
                    _Pivotes._Chv = null;
                }
            }

            RstblcrPscn_Objts();
        }
        else
        {
            Debug.Log("Hay Elemento Vacio");
        }
    }
    void RstblcrPscn_Objts()
    {
        if (!Application.isPlaying)
        {
            _Pivotes._Camara.localPosition = _Pivotes.Pscn_Cmr;
            _Pivotes._Camara.localRotation = _Pivotes.Rtcn_Cmr;
            _Pivotes._Camara.localScale = _Pivotes.Escl_Cmr;

            _Pivotes._Amelia.localPosition = _Pivotes.Pscn_Aml;
            _Pivotes._Amelia.localRotation = _Pivotes.Rtcn_Aml;
            _Pivotes._Amelia.localScale = _Pivotes.Escl_Aml;

            _Pivotes._Dorotea.localPosition = _Pivotes.Pscn_Drt;
            _Pivotes._Dorotea.localRotation = _Pivotes.Rtcn_Drt;
            _Pivotes._Dorotea.localScale = _Pivotes.Escl_Drt;

            _Pivotes._Benkos.localPosition = _Pivotes.Pscn_Bnks;
            _Pivotes._Benkos.localRotation = _Pivotes.Rtcn_Bnks;
            _Pivotes._Benkos.localScale = _Pivotes.Escl_Bnks;
        }
        else
        {
            rstCmr = true;
        }
    }
    void RstblcrCmr()
    {
        float vlcd = .8f;

        _Pivotes._Camara.localPosition = Vector3.Lerp(_Pivotes._Camara.localPosition, _Pivotes.Pscn_Cmr, vlcd * Time.deltaTime);
        _Pivotes._Camara.localRotation = Quaternion.Lerp(_Pivotes._Camara.localRotation, _Pivotes.Rtcn_Cmr, vlcd * Time.deltaTime);
        _Pivotes._Camara.localScale = Vector3.Lerp(_Pivotes._Camara.localScale, _Pivotes.Escl_Cmr, vlcd * Time.deltaTime);
    }

    void Animacion()
    {
        _Animador.SetBool("IncBrnd", _Estados.InicoBorondo);
        _Animador.SetBool("ObtncnMcts", _Estados.ObtencionMacetas);
        _Animador.SetBool("DspjSmbrOlvd", _Estados.DespojeSombraOlvido);
    }


    public void Evento()
    {

    }
    public void Bajar_Chiva()
    {
        Cntrl_Personaje.Sentado = false;
    }
}
