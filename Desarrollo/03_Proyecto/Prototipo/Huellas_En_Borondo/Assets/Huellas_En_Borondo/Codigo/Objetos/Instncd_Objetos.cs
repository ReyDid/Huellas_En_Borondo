using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instncd_Objetos : MonoBehaviour
{
    [Header("General")]
    bool Lst;
    int rndm;
    public int CntdPnts;
    int cntdPnts;

    [Header("Composicion")]
    public Transform[] Puntos_Inctnc;
    [HideInInspector]
    public List<int> PntsInstc;
    int PntInstnc;
    [HideInInspector]
    public List<GameObject> _Objetos;
    int Objt;

    [Header("Referencias")]
    public Almcn_Objetos _Almacen;


    // Start is called before the first frame update
    void Start()
    {
        Lst = false;
        rndm = Random.Range(1, 10);
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
        cntdPnts = CntdPnts;

        PntsInstc.Add(0);
        PntsInstc.Add(1);
        PntsInstc.Add(2);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (cntdPnts > 0)
        {
            InstanciaObjeto();
        }
    }

    
    void InstanciaObjeto()
    {
        if (!Lst)
        {
            _Objetos.Add(_Almacen.Cj_Cono);
            _Objetos.Add(_Almacen.Cj_Basura);
            _Objetos.Add(_Almacen.Cj_BoteBasura);
            _Objetos.Add(_Almacen.Cj_Bloques);
            _Objetos.Add(_Almacen.Cj_MuroBloques);
            _Objetos.Add(_Almacen.Cj_Silla);

            Lst = true;
        }
        else
        {
            for (int I = 0; I < CntdPnts; I++)
            {
                PntInstnc = Random.Range(0, PntsInstc.Count);
                Objt = Random.Range(0, _Objetos.Count);


                for (int i = 0; i < _Objetos[Objt].transform.childCount; i++)
                {
                    if (!_Objetos[Objt].transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        _Objetos[Objt].transform.GetChild(i).position = Puntos_Inctnc[PntsInstc[PntInstnc]].position;
                        _Objetos[Objt].transform.GetChild(i).rotation = Puntos_Inctnc[PntsInstc[PntInstnc]].rotation;
                        _Objetos[Objt].transform.GetChild(i).gameObject.SetActive(true);

                        PntsInstc.RemoveAt(PntInstnc);
                        cntdPnts--;

                        i = _Objetos[Objt].transform.childCount;
                    }
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
