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
    //
    bool Reanuda;

    [Header("Composicion")]
    public int Estd_Cinematica;

    [Header("Refrencias")]
    public Tmp_Entradas _TmpEntradas;
    //
    public Dts_Sistema _DatosSstm;
    public Cntrl_Personaje _Personaje;
    public Cntrl_Villano _Villano;
    public Cntrl_Camara _Camara;
    public Cntrl_Cinematica _Cinematica;
    public Cntrl_Instanciado _Instanciado;


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

        if (!Inicio)
        {
            _Camara.mltpl_VlcdMvmntGnrl = 1;
            Reanuda = true;
            Estd_Cinematica = 1;
        }
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
            _Camara.Cinematica = _Personaje._Estado.EnCnmtc;
            if (_Camara._Encuadre.Angl_Y == 180)
            {
                _Personaje._Estado.Invertido = true;
            }
            else
            {
                _Personaje._Estado.Invertido = false;
            }


            // Cinematica Camara
            if (_Personaje._Estado.Dsplzr <= 0)
            {
                _Villano.Accion = false;

                _Camara.VlcdR = 3.3f;
                _Camara._Encuadre.Angl_X = 40;
                _Camara._Encuadre.Angl_Y = 0;
                //
                _Camara.PscnZ = Mathf.Lerp(_Camara.PscnZ, -28.4f, 1.4f * Time.deltaTime);
                _Camara.pscnY = Mathf.Lerp(_Camara.pscnY, 1.4f, 1.4f * Time.deltaTime);
            }
            else
            {
                if (_Camara.Cinematica)
                {
                    if (_Personaje._Estado.TpCnmtc == "Accion" || _Personaje._Estado.TpCnmtc == "Curva" || _Personaje._Estado.TpCnmtc == "AtaqueT")
                    {
                        _Villano.Accion = true;
                        if (_Personaje._Estado.TpCnmtc == "AtaqueT")
                        {
                            _Villano.Atacando = true;
                        }
                        else
                        {
                            _Villano.Atacando = false;
                        }
                    }
                    else
                    {
                        _Villano.Accion = false;
                        _Villano.Atacando = false;
                    }
                    switch (_Personaje._Estado.TpCnmtc)
                    {
                        case "Curva":
                        case "AtaqueT":
                        case "Accion":
                            _Camara.VlcdR = 1.8f;
                            _Camara._Encuadre.Angl_X = 3.5f;
                            _Camara._Encuadre.Angl_Y = 180;
                            //
                            _Camara.PscnZ = Mathf.Lerp(_Camara.PscnZ, -38.1f, .8f * Time.deltaTime);
                            _Camara.pscnY = Mathf.Lerp(_Camara.pscnY, 9.99f, 1.1f * Time.deltaTime);
                            break;
                        case "Inclina":
                            _Camara.VlcdR = .8f;
                            _Camara._Encuadre.Angl_X = 11;
                            _Camara._Encuadre.Angl_Y = 0;
                            //
                            _Camara.PscnZ = Mathf.Lerp(_Camara.PscnZ, -40.1f, 2.5f * Time.deltaTime);
                            _Camara.pscnY = Mathf.Lerp(_Camara.pscnY, 11.1f, 2.5f * Time.deltaTime);
                            break;
                    }
                }
                else
                {
                    _Villano.Accion = false;

                    _Camara.VlcdR = 3.3f;
                    _Camara._Encuadre.Angl_X = 40;
                    _Camara._Encuadre.Angl_Y = 0;
                    //
                    if (!Cntrl_Villano.Confrontacion)
                    {
                        _Camara.PscnZ = Mathf.Lerp(_Camara.PscnZ, -55.1f, 2.5f * Time.deltaTime);
                        _Camara.pscnY = Mathf.Lerp(_Camara.pscnY, 22.1f, 2.5f * Time.deltaTime);
                    }
                    else
                    {
                        _Camara.PscnZ = Mathf.Lerp(_Camara.PscnZ, -38f, .8f * Time.deltaTime);
                        _Camara.pscnY = Mathf.Lerp(_Camara.pscnY, 33.3f, 1.1f * Time.deltaTime);
                    }
                }
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
            _Personaje._Estado.EnPausa = _TmpEntradas.Pantalla.activeInHierarchy && Reanuda;

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



    void Cinematicas()
    {
        _Cinematica._Animador.speed = _Personaje.Anmdr_Drt.speed;
        _Personaje._Estado.Cinematica = Estd_Cinematica > 0;
        _Cinematica.Cinematica = Estd_Cinematica > 0;

        switch (Estd_Cinematica)
        {
            case 0://
                if (_Camara.mltpl_VlcdMvmntGnrl == 0)
                {
                    _Camara.mltpl_VlcdMvmntGnrl = .01f;
                }
                else
                {
                    _Camara.mltpl_VlcdMvmntGnrl = Mathf.Lerp(_Camara.mltpl_VlcdMvmntGnrl, 1, .3f * Time.deltaTime);
                }
                _Personaje._Estado.Cinematica = false;
                //
                _Cinematica._Estados.InicoBorondo = false;
                _Cinematica._Estados.ObtencionMacetas = false;
                _Cinematica._Estados.DespojeSombraOlvido = false;
                break;
            case 1:// Inicio de Borondo
                _Cinematica._Estados.InicoBorondo = true;
                if (_Cinematica._Animador.GetCurrentAnimatorStateInfo(0).IsName("InicioBorondo") && _Cinematica._Animador.GetCurrentAnimatorStateInfo(0).normalizedTime > .97
                        && !_Cinematica._Animador.IsInTransition(0))
                {
                    _Camara.mltpl_VlcdMvmntGnrl = 0;

                    _Cinematica.Restablecer = true;
                    if (_Cinematica.Rstblcd)
                    {
                        Estd_Cinematica = 0;
                        _Cinematica.Rstblcd = false;
                    }
                }
                break;
            case 2:// Obtencion de Macetas
                _Cinematica._Estados.ObtencionMacetas = true;
                break;
            case 3:// Despoje de la Sombra del Olvido
                _Cinematica._Estados.DespojeSombraOlvido = true;
                break;
        }
    }


    public void Reinicio()
    {
        Estd_Cinematica = 1;
        _Cinematica.Reinicio();

        _Personaje.Reinicio();
        _Instanciado.Reinicio();
    }
    public void Partida()
    {
        _TmpEntradas.tmpCrgPrtd = .01f;
        Reanuda = false;
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
