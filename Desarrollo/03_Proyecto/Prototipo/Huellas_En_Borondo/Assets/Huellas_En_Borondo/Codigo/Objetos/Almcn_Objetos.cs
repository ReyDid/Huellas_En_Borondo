using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almcn_Objetos : MonoBehaviour
{
    public GameObject InstncObjt;

    [Header("General")]
    public GameObject Cj_Transportes;
    public GameObject Cj_Rastreo;
    public GameObject Cj_Cono;
    public GameObject Cj_Basura;
    public GameObject Cj_BoteBasura;
    public GameObject Cj_Bloques;
    public GameObject Cj_MuroBloques;
    public GameObject Cj_Silla;
    public GameObject Cj_Piedra;
    public GameObject Cj_Cocodrilo;
    public GameObject Cj_Tronco;
    public GameObject Cj_Maceta;
    public GameObject Cj_Letra;
    public GameObject Cj_ColeccionHlls;
    public GameObject Cj_Alfe�ique;
    public GameObject Cj_MtMedicinal;
    //
    public Cntrl_Objetos _Chiva;
    public Cntrl_Objetos _Canastos;
    public Cntrl_Objetos _Canoa;
    public Cntrl_Objetos _Huella;
    public Cntrl_Objetos _Cono;
    public Cntrl_Objetos _Basura;
    public Cntrl_Objetos _BoteBasura;
    public Cntrl_Objetos _Bloques;
    public Cntrl_Objetos _MuroBloques;
    public Cntrl_Objetos _Silla;
    public Cntrl_Objetos _Piedra;
    public Cntrl_Objetos _Cocodrilo;
    public Cntrl_Objetos _Tronco;
    public Cntrl_Objetos _Maceta;
    public Cntrl_Objetos _Letra;
    public Cntrl_Objetos _ColeccionHlls;
    public Cntrl_Objetos _Alfe�ique;
    public Cntrl_Objetos _MtMedicinal;

    [Header("Composicion")]
    public Cntrl_Objetos Chiva;
    public Cntrl_Objetos Canastos;
    public Cntrl_Objetos Canoa;
    public int Cntd_Hlls;
    public Cntrl_Objetos[] Huellas;
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
    public int Cntd_Pdrs;
    public Cntrl_Objetos[] Piedras;
    public int Cntd_Cdrls;
    public Cntrl_Objetos[] Cocodrilos;
    public int Cntd_Trncs;
    public Cntrl_Objetos[] Troncos;
    public int Cntd_Mcts;
    public Cntrl_Objetos[] Macetas;
    public int Cntd_Ltrs;
    public Cntrl_Objetos[] Letras;
    public int Cntd_ClccnsH;
    public Cntrl_Objetos[] ColeccionesHlls;
    public int Cntd_Alf�qs;
    public Cntrl_Objetos[] Alfe�iques;
    public int Cntd_MMdcnls;
    public Cntrl_Objetos[] MtsMedicinales;


    void Awake()
    {
        if (Chiva == null)
        {
            GameObject Objt = Instantiate(_Chiva.gameObject);
            Objt.transform.parent = Cj_Transportes.transform;
            Objt.transform.position = Cj_Transportes.transform.position;
            Objt.name = _Chiva.name;
            //
            Chiva = Objt.GetComponent<Cntrl_Objetos>();
            Chiva.gameObject.SetActive(false);
        }
        if (Canastos == null)
        {
            GameObject Objt = Instantiate(_Canastos.gameObject);
            Objt.transform.parent = Cj_Transportes.transform;
            Objt.transform.position = Cj_Transportes.transform.position;
            Objt.name = _Canastos.name;
            //
            Canastos = Objt.GetComponent<Cntrl_Objetos>();
            Canastos.gameObject.SetActive(false);
        }
        if (Canoa == null)
        {
            GameObject Objt = Instantiate(_Canoa.gameObject);
            Objt.transform.parent = Cj_Transportes.transform;
            Objt.transform.position = Cj_Transportes.transform.position;
            Objt.name = _Canoa.name;
            //
            Canoa = Objt.GetComponent<Cntrl_Objetos>();
            Canoa.gameObject.SetActive(false);
        }

        Huellas = new Cntrl_Objetos[Cntd_Hlls];
        for (int i = 0; i < Cntd_Hlls; i++)
        {
            GameObject Objt = Instantiate(_Huella.gameObject);
            Objt.transform.parent = Cj_Rastreo.transform;
            Objt.transform.position = Cj_Rastreo.transform.position;
            Objt.name = _Huella.name;

            Huellas[i] = Objt.GetComponent<Cntrl_Objetos>();
            Huellas[i].gameObject.SetActive(false);
        }

        Conos = new Cntrl_Objetos[Cntd_Cns];
        for (int i = 0; i < Cntd_Cns; i++)
        {
            GameObject Objt = Instantiate(_Cono.gameObject);
            Objt.transform.parent = Cj_Cono.transform;
            Objt.transform.position = Cj_Cono.transform.position;
            Objt.name = _Cono.name;

            Conos[i] = Objt.GetComponent<Cntrl_Objetos>();
            Conos[i].gameObject.SetActive(false);
        }

        Basuras = new Cntrl_Objetos[Cntd_Bsrs];
        for (int i = 0; i < Cntd_Bsrs; i++)
        {
            GameObject Objt = Instantiate(_Basura.gameObject);
            Objt.transform.parent = Cj_Basura.transform;
            Objt.transform.position = Cj_Basura.transform.position;
            Objt.name = _Basura.name;

            Basuras[i] = Objt.GetComponent<Cntrl_Objetos>();
            Basuras[i].gameObject.SetActive(false);
        }

        BotesBasura = new Cntrl_Objetos[Cntd_BtsBsr];
        for (int i = 0; i < Cntd_BtsBsr; i++)
        {
            GameObject Objt = Instantiate(_BoteBasura.gameObject);
            Objt.transform.parent = Cj_BoteBasura.transform;
            Objt.transform.position = Cj_BoteBasura.transform.position;
            Objt.name = _BoteBasura.name;

            BotesBasura[i] = Objt.GetComponent<Cntrl_Objetos>();
            BotesBasura[i].gameObject.SetActive(false);
        }

        Bloques = new Cntrl_Objetos[Cntd_Blqs];
        for (int i = 0; i < Cntd_Blqs; i++)
        {
            GameObject Objt = Instantiate(_Bloques.gameObject);
            Objt.transform.parent = Cj_Bloques.transform;
            Objt.transform.position = Cj_Bloques.transform.position;
            Objt.name = _Bloques.name;

            Bloques[i] = Objt.GetComponent<Cntrl_Objetos>();
            Bloques[i].gameObject.SetActive(false);
        }

        MurosBloques = new Cntrl_Objetos[Cntd_MrsBlqs];
        for (int i = 0; i < Cntd_MrsBlqs; i++)
        {
            GameObject Objt = Instantiate(_MuroBloques.gameObject);
            Objt.transform.parent = Cj_MuroBloques.transform;
            Objt.transform.position = Cj_MuroBloques.transform.position;
            Objt.name = _MuroBloques.name;

            MurosBloques[i] = Objt.GetComponent<Cntrl_Objetos>();
            MurosBloques[i].gameObject.SetActive(false);
        }

        Sillas = new Cntrl_Objetos[Cntd_Slls];
        for (int i = 0; i < Cntd_Slls; i++)
        {
            GameObject Objt = Instantiate(_Silla.gameObject);
            Objt.transform.parent = Cj_Silla.transform;
            Objt.transform.position = Cj_Silla.transform.position;
            Objt.name = _Silla.name;

            Sillas[i] = Objt.GetComponent<Cntrl_Objetos>();
            Sillas[i].gameObject.SetActive(false);
        }

        Piedras = new Cntrl_Objetos[Cntd_Pdrs];
        for (int i = 0; i < Cntd_Pdrs; i++)
        {
            GameObject Objt = Instantiate(_Piedra.gameObject);
            Objt.transform.parent = Cj_Piedra.transform;
            Objt.transform.position = Cj_Piedra.transform.position;
            Objt.name = _Piedra.name;

            Piedras[i] = Objt.GetComponent<Cntrl_Objetos>();
            Piedras[i].gameObject.SetActive(false);
        }

        Cocodrilos = new Cntrl_Objetos[Cntd_Cdrls];
        for (int i = 0; i < Cntd_Cdrls; i++)
        {
            GameObject Objt = Instantiate(_Cocodrilo.gameObject);
            Objt.transform.parent = Cj_Cocodrilo.transform;
            Objt.transform.position = Cj_Cocodrilo.transform.position;
            Objt.name = _Cocodrilo.name;

            Cocodrilos[i] = Objt.GetComponent<Cntrl_Objetos>();
            Cocodrilos[i].gameObject.SetActive(false);
        }

        Troncos = new Cntrl_Objetos[Cntd_Trncs];
        for (int i = 0; i < Cntd_Trncs; i++)
        {
            GameObject Objt = Instantiate(_Tronco.gameObject);
            Objt.transform.parent = Cj_Tronco.transform;
            Objt.transform.position = Cj_Tronco.transform.position;
            Objt.name = _Tronco.name;

            Troncos[i] = Objt.GetComponent<Cntrl_Objetos>();
            Troncos[i].gameObject.SetActive(false);
        }

        Macetas = new Cntrl_Objetos[Cntd_Mcts];
        for (int i = 0; i < Cntd_Mcts; i++)
        {
            GameObject Objt = Instantiate(_Maceta.gameObject);
            Objt.transform.parent = Cj_Maceta.transform;
            Objt.transform.position = Cj_Maceta.transform.position;
            Objt.name = _Maceta.name;

            Macetas[i] = Objt.GetComponent<Cntrl_Objetos>();
            Macetas[i].gameObject.SetActive(false);
        }

        Letras = new Cntrl_Objetos[Cntd_Ltrs];
        for (int i = 0; i < Cntd_Ltrs; i++)
        {
            GameObject Objt = Instantiate(_Letra.gameObject);
            Objt.transform.parent = Cj_Letra.transform;
            Objt.transform.position = Cj_Letra.transform.position;
            Objt.name = _Letra.name;

            Letras[i] = Objt.GetComponent<Cntrl_Objetos>();
            Letras[i].gameObject.SetActive(false);
        }

        ColeccionesHlls = new Cntrl_Objetos[Cntd_ClccnsH];
        for (int i = 0; i < Cntd_ClccnsH; i++)
        {
            GameObject Objt = Instantiate(_ColeccionHlls.gameObject);
            Objt.transform.parent = Cj_ColeccionHlls.transform;
            Objt.transform.position = Cj_ColeccionHlls.transform.position;
            Objt.name = _ColeccionHlls.name;

            ColeccionesHlls[i] = Objt.GetComponent<Cntrl_Objetos>();
            ColeccionesHlls[i].gameObject.SetActive(false);
        }

        Alfe�iques = new Cntrl_Objetos[Cntd_Alf�qs];
        for (int i = 0; i < Cntd_Alf�qs; i++)
        {
            GameObject Objt = Instantiate(_Alfe�ique.gameObject);
            Objt.transform.parent = Cj_Alfe�ique.transform;
            Objt.transform.position = Cj_Alfe�ique.transform.position;
            Objt.name = _Alfe�ique.name;

            Alfe�iques[i] = Objt.GetComponent<Cntrl_Objetos>();
            Alfe�iques[i].gameObject.SetActive(false);
        }

        MtsMedicinales = new Cntrl_Objetos[Cntd_MMdcnls];
        for (int i = 0; i < Cntd_MMdcnls; i++)
        {
            GameObject Objt = Instantiate(_MtMedicinal.gameObject);
            Objt.transform.parent = Cj_MtMedicinal.transform;
            Objt.transform.position = Cj_MtMedicinal.transform.position;
            Objt.name = _MtMedicinal.name;

            MtsMedicinales[i] = Objt.GetComponent<Cntrl_Objetos>();
            MtsMedicinales[i].gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InstncObjt.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
