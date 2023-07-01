using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almcn_Objetos : MonoBehaviour
{
    public GameObject InstncObjt;

    [Header("General")]
    public GameObject Cj_Cono;
    public GameObject Cj_Basura;
    public GameObject Cj_BoteBasura;
    public GameObject Cj_Bloques;
    public GameObject Cj_MuroBloques;
    public GameObject Cj_Silla;
    //
    public Cntrl_Objetos _Cono;
    public Cntrl_Objetos _Basura;
    public Cntrl_Objetos _BoteBasura;
    public Cntrl_Objetos _Bloques;
    public Cntrl_Objetos _MuroBloques;
    public Cntrl_Objetos _Silla;

    [Header("Composicion")]
    public int Cntd_Cns;
    public Cntrl_Objetos[] Conos;
    public int Cntd_Bsrs;
    public Cntrl_Objetos[] Basuras;
    public int Cntd_BtsBsr;
    public Cntrl_Objetos[] BotesBasura;
    public int Cntd_Blqs;
    public Cntrl_Objetos[] Bloques;
    public int Cntd_MrsBlqs;
    public Cntrl_Objetos[] MurosBloques;
    public int Cntd_Slls;
    public Cntrl_Objetos[] Sillas;


    // Start is called before the first frame update
    void Start()
    {
        InstncObjt.SetActive(false);


        Conos = new Cntrl_Objetos[Cntd_Cns];
        for (int i = 0; i < Cntd_Cns; i++)
        {
            GameObject Objt = Instantiate(_Cono.gameObject);
            Objt.transform.parent = Cj_Cono.transform;
            Objt.transform.position = Cj_Cono.transform.position;
            Objt.name = _Cono.name + "_" + (i + 1);

            Conos[i] = Objt.GetComponent<Cntrl_Objetos>();
            Conos[i].gameObject.SetActive(false);
        }

        Basuras = new Cntrl_Objetos[Cntd_Bsrs];
        for (int i = 0; i < Cntd_Bsrs; i++)
        {
            GameObject Objt = Instantiate(_Basura.gameObject);
            Objt.transform.parent = Cj_Basura.transform;
            Objt.transform.position = Cj_Basura.transform.position;
            Objt.name = _Basura.name + "_" + (i + 1);

            Basuras[i] = Objt.GetComponent<Cntrl_Objetos>();
            Basuras[i].gameObject.SetActive(false);
        }

        BotesBasura = new Cntrl_Objetos[Cntd_BtsBsr];
        for (int i = 0; i < Cntd_BtsBsr; i++)
        {
            GameObject Objt = Instantiate(_BoteBasura.gameObject);
            Objt.transform.parent = Cj_BoteBasura.transform;
            Objt.transform.position = Cj_BoteBasura.transform.position;
            Objt.name = _BoteBasura.name + "_" + (i + 1);

            BotesBasura[i] = Objt.GetComponent<Cntrl_Objetos>();
            BotesBasura[i].gameObject.SetActive(false);
        }

        Bloques = new Cntrl_Objetos[Cntd_Blqs];
        for (int i = 0; i < Cntd_Blqs; i++)
        {
            GameObject Objt = Instantiate(_Bloques.gameObject);
            Objt.transform.parent = Cj_Bloques.transform;
            Objt.transform.position = Cj_Bloques.transform.position;
            Objt.name = _Bloques.name + "_" + (i + 1);

            Bloques[i] = Objt.GetComponent<Cntrl_Objetos>();
            Bloques[i].gameObject.SetActive(false);
        }

        MurosBloques = new Cntrl_Objetos[Cntd_MrsBlqs];
        for (int i = 0; i < Cntd_MrsBlqs; i++)
        {
            GameObject Objt = Instantiate(_MuroBloques.gameObject);
            Objt.transform.parent = Cj_MuroBloques.transform;
            Objt.transform.position = Cj_MuroBloques.transform.position;
            Objt.name = _MuroBloques.name + "_" + (i + 1);

            MurosBloques[i] = Objt.GetComponent<Cntrl_Objetos>();
            MurosBloques[i].gameObject.SetActive(false);
        }

        Sillas = new Cntrl_Objetos[Cntd_Slls];
        for (int i = 0; i < Cntd_Slls; i++)
        {
            GameObject Objt = Instantiate(_Silla.gameObject);
            Objt.transform.parent = Cj_Silla.transform;
            Objt.transform.position = Cj_Silla.transform.position;
            Objt.name = _Silla.name + "_" + (i + 1);

            Sillas[i] = Objt.GetComponent<Cntrl_Objetos>();
            Sillas[i].gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
