using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instncd_Objetos : MonoBehaviour
{
    [HideInInspector]
    public bool Inc;

    [Header("General")]
    public bool Objetos;
    public bool NoHuellas;
    public bool Montaña;
    public bool Rio;
    bool Lst;
    [HideInInspector]
    public int rndm;
    public int CntdPnts;
    int cntdPnts;

    [Header("Composicion")]
    public Transform[] Puntos_Inctnc;
    [HideInInspector]
    public List<int> PntsInstc;
    int pntInstnc;
    [HideInInspector]
    public List<GameObject> _Objetos;
    int Objt;

    [Header("Referencias")]
    public Almcn_Objetos _Almacen;
    //
    public Cntrl_Huellas _Huellas;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _Huellas = transform.GetComponent<Cntrl_Huellas>();

        Lst = false;
        rndm = Random.Range(1, 10);

        PntsInstc.Add(0);
        PntsInstc.Add(1);
        PntsInstc.Add(2);

        _Huellas.Instncr = true;
        for (int i = 0; i < _Huellas.transform.parent.childCount; i++)
        {
            if (_Huellas.transform.parent.GetChild(i) == transform)
            {
                _Huellas._Instanciado.Actl_Pnt = transform.GetComponent<Instncd_Objetos>();
                if (transform != transform.parent.GetChild(transform.parent.childCount - 1))
                {
                    _Huellas._Instanciado.Sgnt_Pnt = _Huellas.transform.parent.GetChild(i + 1).GetComponent<Instncd_Objetos>();
                }
            }
        }
        Inc = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (Objetos)
        {
            switch (rndm)
            {
                case 1:
                case 3:
                case 6:
                case 8:
                    CntdPnts = 1;
                    break;
                case 2:
                case 4:
                case 5:
                case 7:
                case 9:
                case 10:
                    CntdPnts = 2;
                    break;
            }
        }
        if (Inc)
        {
            cntdPnts = CntdPnts;
            Inc = false;
        }

        if (cntdPnts > 0)
        {
            InstanciaObjeto();
        }
    }

    
    void InstanciaObjeto()
    {
        if (!Lst)
        {
            if (!NoHuellas)
            {
                _Objetos.Add(_Almacen.Cj_Cono);
                _Objetos.Add(_Almacen.Cj_Basura);
                _Objetos.Add(_Almacen.Cj_BoteBasura);
                _Objetos.Add(_Almacen.Cj_Bloques);
                _Objetos.Add(_Almacen.Cj_MuroBloques);
                _Objetos.Add(_Almacen.Cj_Silla);
            }
            else
            {
                if (Montaña)
                {
                    _Objetos.Add(_Almacen.Cj_Piedra);
                }
                else if (Rio)
                {
                    _Objetos.Add(_Almacen.Cj_Cocodrilo);
                    _Objetos.Add(_Almacen.Cj_Tronco);
                }
            }

            Lst = true;
        }
        else
        {
            bool blq_Trnc = false;
            for (int I = 0; I < CntdPnts; I++)
            {
                pntInstnc = Random.Range(0, PntsInstc.Count);
                if (!blq_Trnc)
                {
                    Objt = Random.Range(0, _Objetos.Count);
                }

                if (Objetos)
                {
                    if (_Objetos.Count > 0)
                    {
                        for (int i = 0; i < _Objetos[Objt].transform.childCount; i++)
                        {
                            if (!_Objetos[Objt].transform.GetChild(i).gameObject.activeInHierarchy)
                            {
                                _Objetos[Objt].transform.GetChild(i).position = Puntos_Inctnc[PntsInstc[pntInstnc]].position;
                                _Objetos[Objt].transform.GetChild(i).rotation = Puntos_Inctnc[PntsInstc[pntInstnc]].rotation;
                                _Objetos[Objt].transform.GetChild(i).gameObject.SetActive(true);

                                PntsInstc.RemoveAt(pntInstnc);
                                cntdPnts--;

                                i = _Objetos[Objt].transform.childCount;
                            }
                        }
                    }
                }

                if (_Objetos[Objt].name == "Tronco")
                {
                    I = cntdPnts;
                    cntdPnts = 0;
                }
                else
                {
                    blq_Trnc = true;
                }
            }
        }
    }


    void OnTriggerEnter(Collider Otr)
    {

    }
    //
    void OnTriggerExit(Collider Otr)
    {

    }
}
