using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cntrl_Partida : MonoBehaviour
{
    public Text ID_Sstm;
    public bool Inicio;
    public bool Smlr_Build;

    [Header("General")]
    public float Tiempo_SlccnSstm;
    public float Tiempo_J;

    [Header("Refrencias")]
    public Tmp_Entradas _TmpEntradas;
    //
    public Dts_Sistema _DatosSstm;
    public Cntrl_Personaje _Personaje;
    public Cntrl_Camara _Camara;


    [System.Serializable]
    public class Tmp_Entradas
    {
        public GameObject Pantalla;

        [HideInInspector]
        public bool pntllCmplt;
        [HideInInspector]
        public float tmpCrgPrtd;
        [HideInInspector]
        public float tmpPausa;
    }


    // Start is called before the first frame update
    void Start()
    {
        _TmpEntradas.pntllCmplt = true;
        if (Inicio && !Smlr_Build)
        {
            _DatosSstm.ID_Sstm = "";
        }
<<<<<<< Updated upstream
=======

        if (!Inicio)
        {
            _Camara.mltpl_VlcdMvmntGnrl = 1;
            Reanuda = true;
            Estd_Cinematica = 1;
        }
>>>>>>> Stashed changes
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (_DatosSstm.ID_Sstm == "PC")
        {
            // PC
            //Screen.SetResolution(960, 540, Screen.fullScreen);
            if (_Personaje != null)
            {
                _Personaje._Interfaz2D.CntrlTctl.SetActive(false);
            }
        }
        else if (_DatosSstm.ID_Sstm == "Movil")
        {

        }
        //
        if (_Personaje != null)
        {
            if (_Personaje._Estado.Dsplzr <= 0)
            {
                _Camara.PscnZ = Mathf.Lerp(_Camara.PscnZ, -28.4f, 1.4f * Time.deltaTime);
                _Camara.pscnY = Mathf.Lerp(_Camara.pscnY, 1.4f, 1.4f * Time.deltaTime);
            }
            else
            {
                _Camara.PscnZ = Mathf.Lerp(_Camara.PscnZ, -55.1f, 2.5f * Time.deltaTime);
                _Camara.pscnY = Mathf.Lerp(_Camara.pscnY, 22.1f, 2.5f * Time.deltaTime);
            }
        }


        if (!Inicio)
        {
            if (_TmpEntradas.tmpCrgPrtd > 0)
            {
                SceneManager.LoadScene(1);
            }


            if (Smlr_Build)
            {
                if (!_TmpEntradas.pntllCmplt && !Screen.fullScreen)
                {
                    _TmpEntradas.Pantalla.SetActive(true);
                }
                else
                {
                    _TmpEntradas.Pantalla.SetActive(false);
                }
            }
            else
            {
                _TmpEntradas.Pantalla.SetActive(!Screen.fullScreen);
            }
            _Personaje._Estado.EnPausa = _TmpEntradas.Pantalla.activeInHierarchy;

            if (_Personaje._Entrada.Pausa > 0)
            {
                if (_TmpEntradas.tmpPausa == 0)
                {
                    Screen.fullScreen = false;
                    _TmpEntradas.pntllCmplt = false;

                    _TmpEntradas.tmpPausa = .01f;
                }
            }
            else
            {
                _TmpEntradas.tmpPausa = 0;
            }
            //
            if (_Personaje._Estado.Fin)
            {
                if (_TmpEntradas.tmpCrgPrtd == 0)
                {
                    Screen.fullScreen = false;
                    _TmpEntradas.pntllCmplt = false;
                }
            }

            Cinematicas();
        }
        else
        {
            if (ID_Sstm.text != "Ninguno")
            {
                _DatosSstm.ID_Sstm = ID_Sstm.text;
            }


            if (_TmpEntradas.tmpCrgPrtd > 0)
            {
                if (_TmpEntradas.tmpCrgPrtd < .03)
                {
                    _TmpEntradas.tmpCrgPrtd += 1 * Time.deltaTime;
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }


    public void Partida()
    {
        _TmpEntradas.tmpCrgPrtd = .01f;
    }
    public void Ir_Pagina()
    {
        Application.Quit();
    }
    public void PantallaCompleta()
    {
        Screen.fullScreen = true;
        _TmpEntradas.pntllCmplt = true;
    }
}
