using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cntrl_Interfaz : MonoBehaviour
{
    [Header("General")]
    public string _PrsnjSlccn;
    public bool Palabra;

    [Header("Composicion")]
    public RectTransform BrrIntrfz;
    //
    public RectTransform Lsn;
    float trnsprncLsn;
    float vlcdTrnsprncLsn;
    //
    public RectTransform AvtrS_Drt;
    public RectTransform AvtrR_Drt;
    public RectTransform Sld_Drt;
    public RectTransform Hbld_Drt;
    //
    public RectTransform AvtrS_Bnks;
    public RectTransform AvtrR_Bnks;
    public RectTransform Sld_Bnks;
    public RectTransform Hbld_Bnks;
    //
    public TMP_Text Pntcn;
    public TMP_Text Mcts;
    public List<GameObject> Plbr;
    //
    public RectTransform Sld;
    [HideInInspector]
    public Color Clr_Sld;
    public Color ClrNrml_Sld;
    public Color ClrRglr_Sld;
    public Color ClrPlgr_Sld;
    public int CntdSld;
    float cntdRlSld;

    [Header("Referencias")]
    [HideInInspector]
    public Cntrl_Partida _Partida;

    // Start is called before the first frame update
    void Start()
    {
        _Partida = GetComponent<Cntrl_Partida>();

        BrrIntrfz.anchoredPosition = new Vector2(0, 66.11f);
        BrrIntrfz.sizeDelta = new Vector2(1920, 320);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        _PrsnjSlccn = _Partida._Personaje._Estado.Personaje;

        Puntuacion();
        ColeccionPalabra();
        Personajes();
        Salud();
    }


    void Puntuacion()
    {
        Pntcn.text = _Partida._Personaje._Estado.Cntd_Huellas.ToString();
        Mcts.text = _Partida._Personaje._Estado.Cntd_Macetas + "/" + _Partida._Personaje._Estado.CntdTtl_Macetas;
    }
    void ColeccionPalabra()
    {
        if (_Partida._Personaje._Estado.TmpPlbr > 0)
        {
            _Partida._Personaje._Estado.TmpPlbr -= 1 * Time.deltaTime;
        }
        else
        {
            _Partida._Personaje._Estado.EnPlbr = false;
            _Partida._Personaje._Estado.TmpPlbr = 0;
        }
        Palabra = _Partida._Personaje._Estado.EnPlbr;

        if (!Palabra)
        {
            BrrIntrfz.anchoredPosition = Vector2.Lerp(BrrIntrfz.anchoredPosition, new Vector2(0, 66.11f), 2 * Time.deltaTime);
            BrrIntrfz.sizeDelta = Vector2.Lerp(BrrIntrfz.sizeDelta, new Vector2(1920, 320), 2 * Time.deltaTime);
        }
        else
        {
            BrrIntrfz.anchoredPosition = Vector2.Lerp(BrrIntrfz.anchoredPosition, new Vector2(0, 0), 2 * Time.deltaTime);
            BrrIntrfz.sizeDelta = Vector2.Lerp(BrrIntrfz.sizeDelta, new Vector2(1920, 188), 2 * Time.deltaTime);
        }


        Plbr[0].SetActive(_Partida._Personaje._Estado.Ttl_Letras[0] != "");
        Plbr[1].SetActive(_Partida._Personaje._Estado.Ttl_Letras[1] != "");
        Plbr[2].SetActive(_Partida._Personaje._Estado.Ttl_Letras[2] != "");
        Plbr[3].SetActive(_Partida._Personaje._Estado.Ttl_Letras[3] != "");
        Plbr[4].SetActive(_Partida._Personaje._Estado.Ttl_Letras[4] != "");
        Plbr[5].SetActive(_Partida._Personaje._Estado.Ttl_Letras[5] != "");
        Plbr[6].SetActive(_Partida._Personaje._Estado.Ttl_Letras[6] != "");
    }
    void Personajes()
    {
        AvtrS_Drt.gameObject.SetActive(_PrsnjSlccn == "Dorotea");
        AvtrR_Drt.gameObject.SetActive(_PrsnjSlccn != "Dorotea");
        Sld_Drt.gameObject.SetActive(_PrsnjSlccn == "Dorotea");
        Hbld_Drt.gameObject.SetActive(_PrsnjSlccn == "Dorotea");
        //
        AvtrS_Bnks.gameObject.SetActive(_PrsnjSlccn == "Benkos");
        AvtrR_Bnks.gameObject.SetActive(_PrsnjSlccn != "Benkos");
        Sld_Bnks.gameObject.SetActive(_PrsnjSlccn == "Benkos");
        Hbld_Bnks.gameObject.SetActive(_PrsnjSlccn == "Benkos");

        switch (_PrsnjSlccn)
        {
            case "Dorotea":
                CntdSld = _Partida._Personaje._Estado.Sld_Dorotea;
                break;
            case "Benkos":
                CntdSld = _Partida._Personaje._Estado.Sld_Benkos;
                break;
        }
    }
    void Salud()
    {
        float vlcdSld = 4;

        switch (CntdSld)
        {
            case 0:
                cntdRlSld = -400;
                break;
            case 1:
                cntdRlSld = -260;
                Clr_Sld = ClrPlgr_Sld;
                break;
            case 2:
                cntdRlSld = -130;
                Clr_Sld = ClrRglr_Sld;
                break;
            case 3:
                cntdRlSld = 0;
                Clr_Sld = ClrNrml_Sld;
                break;
        }

        Sld.anchoredPosition = Vector2.MoveTowards(Sld.anchoredPosition, new Vector2(cntdRlSld, 0), (vlcdSld * 100) * Time.deltaTime);
        Sld.GetComponent<Image>().color = Color.Lerp(Sld.GetComponent<Image>().color, Clr_Sld, vlcdSld * Time.deltaTime);
        Lsn.gameObject.SetActive(_Partida._Personaje._Estado.EnLsn);
        Color clrLsn = Lsn.GetComponent<Image>().color;
        Lsn.GetComponent<Image>().color = Color.Lerp(Lsn.GetComponent<Image>().color, new Color(clrLsn.r, clrLsn.g, clrLsn.b, trnsprncLsn), 11f * Time.deltaTime);
        if (vlcdTrnsprncLsn <= 0)
        {
            if (trnsprncLsn == .44f)
            {
                vlcdTrnsprncLsn = .2f;
                trnsprncLsn = .66f;
            }
            else
            {
                vlcdTrnsprncLsn = .2f;
                trnsprncLsn = .44f;
            }
        }
        else
        {
            vlcdTrnsprncLsn -= 1 * Time.deltaTime;
        }
    }
}
