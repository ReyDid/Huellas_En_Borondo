using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instncd_Objetos : MonoBehaviour
{
    [Header("General")]
    public GameObject Pscn_Frutas;
    [HideInInspector]
    public Pnt_Fruta[] PntFrts;
    [HideInInspector]
    public int PntsInstnc_Frts;
    [HideInInspector]
    int Pnt;

    [Header("Composicion")]
    public int CntdFrt;
    public List<GameObject> Frts;
    [HideInInspector]
    public GameObject Fruta;

    [Header("Referencias")]
    public Almcn_Objetos _Objetos;


    // Start is called before the first frame update
    void Start()
    {
        Pscn_Frutas.transform.GetChild(0).gameObject.SetActive(false);
        PntsInstnc_Frts = Pscn_Frutas.transform.GetChild(1).childCount;

        PntFrts = new Pnt_Fruta[PntsInstnc_Frts];
        for (int i = 0; i < PntFrts.Length; i++)
        {
            PntFrts[i] = Pscn_Frutas.transform.GetChild(1).GetChild(i).GetComponent<Pnt_Fruta>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        int Cl = 0;
        if (Cl == 0)
        {
            for (int i = 0; i < Frts.Count; i++)
            {
                if (!Frts[i].gameObject.activeInHierarchy)
                {
                    Frts.RemoveAt(i);
                    CntdFrt--;
                }
                if (i == (Frts.Count - 1))
                {
                    Cl = 1;
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (CntdFrt <= 0)
        {
            InstanciaFruta();
        }
    }

    
    void InstanciaFruta()
    {
        int UnSlDt = 0;

        for (int I = 0; I < _Objetos._Frutas.Length; I++)
        {
            if (UnSlDt == 0)
            {
                if (Fruta == null)
                {
                    if (!_Objetos._Frutas[I].gameObject.activeInHierarchy)
                    {
                        Fruta = _Objetos._Frutas[I].gameObject;

                        UnSlDt = 1;
                    }
                }
            }
        }

        if (Fruta != null)
        {
            Pnt = Random.Range(0, PntsInstnc_Frts - 1);
            if (!PntFrts[Pnt].Blq)
            {
                Fruta.transform.position = Pscn_Frutas.transform.GetChild(1).GetChild(Pnt).position;
                Fruta.gameObject.SetActive(true);
            }
        }
    }


    void OnTriggerEnter(Collider Otr)
    {
        if (Otr.tag == "Fruta")
        {
            Frts.Add(Otr.transform.parent.parent.gameObject);
            CntdFrt++;
        }
    }
    //
    void OnTriggerExit(Collider Otr)
    {

    }
}
