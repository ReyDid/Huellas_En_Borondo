using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Instanciado : MonoBehaviour
{
    float tmpActlzrDstncs;

    [Header("General")]
    public Transform _Personaje;
    //public GameObject _Transportes;
    public GameObject _Obstaculos;
    //public GameObject _Premios;

    [Header("Composicion")]
    public Instncd_Transporte[] InstncdTrnsprt;
    public Transform[] _Instncds;
    public int Instncd_Crcn;
    public int Instncd_Vld;
    public float[] _DstnscInstncds;

    [Header("Referencias")]
    public Almcn_Objetos _AlmacenObjetos;



    // Start is called before the first frame update
    void Start()
    {
        _Instncds = new Transform[_Obstaculos.transform.childCount];
        _DstnscInstncds = new float[_Obstaculos.transform.childCount];

        for (int i = 0; i < _Instncds.Length; i++)
        {
            _Instncds[i] = _Obstaculos.transform.GetChild(i);
            if (_Instncds[i].tag == "Obstcl")
            {
                //_Instncds[i].gameObject.SetActive(false);
            }
            _Instncds[i].gameObject.SetActive(false);
        }

        tmpActlzrDstncs = 0;
        Instncd_Crcn = 0;
        Instncd_Vld = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (tmpActlzrDstncs <= 0)
        {
            ActualizarDistancias();
            tmpActlzrDstncs = .8f;
        }
        else
        {
            if (_DstnscInstncds[Instncd_Crcn] <= 40 && !_Instncds[Instncd_Crcn].gameObject.activeInHierarchy)
            {
                Instncd_Vld++;
                _Instncds[Instncd_Crcn].gameObject.SetActive(true);
            }
            tmpActlzrDstncs -= 1 * Time.deltaTime;
        }
    }

    public void Reinicio()
    {
        // Objetos
        for (int i = 0; i < _AlmacenObjetos.Huellas.Length; i++)
        {
            _AlmacenObjetos.Huellas[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Conos.Length; i++)
        {
            _AlmacenObjetos.Conos[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Basuras.Length; i++)
        {
            _AlmacenObjetos.Basuras[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.BotesBasura.Length; i++)
        {
            _AlmacenObjetos.BotesBasura[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Bloques.Length; i++)
        {
            _AlmacenObjetos.Bloques[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.MurosBloques.Length; i++)
        {
            _AlmacenObjetos.MurosBloques[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Sillas.Length; i++)
        {
            _AlmacenObjetos.Sillas[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Piedras.Length; i++)
        {
            _AlmacenObjetos.Piedras[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Cocodrilos.Length; i++)
        {
            _AlmacenObjetos.Cocodrilos[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Troncos.Length; i++)
        {
            _AlmacenObjetos.Troncos[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Macetas.Length; i++)
        {
            _AlmacenObjetos.Macetas[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Letras.Length; i++)
        {
            _AlmacenObjetos.Letras[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.ColeccionesHlls.Length; i++)
        {
            _AlmacenObjetos.ColeccionesHlls[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.Alfeñiques.Length; i++)
        {
            _AlmacenObjetos.Alfeñiques[i].Destruir();
        }
        for (int i = 0; i < _AlmacenObjetos.MtsMedicinales.Length; i++)
        {
            _AlmacenObjetos.MtsMedicinales[i].Destruir();
        }

        // Instanciadores
        for (int i = 0; i < _Instncds.Length; i++)
        {
            if (_Instncds[i].GetComponent<Instncd_Objetos>().enabled)
            {
                _Instncds[i].GetComponent<Instncd_Objetos>()._Huellas = _Instncds[i].transform.GetComponent<Cntrl_Huellas>();

                _Instncds[i].GetComponent<Instncd_Objetos>().rndm = Random.Range(1, 10);

                _Instncds[i].GetComponent<Instncd_Objetos>().PntsInstc.Add(0);
                _Instncds[i].GetComponent<Instncd_Objetos>().PntsInstc.Add(1);
                _Instncds[i].GetComponent<Instncd_Objetos>().PntsInstc.Add(2);
                
                _Instncds[i].GetComponent<Instncd_Objetos>()._Huellas.Instncr = true;
                _Instncds[i].GetComponent<Instncd_Objetos>()._Huellas._Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>().Instncd = false;
                _Instncds[i].GetComponent<Instncd_Objetos>().Inc = true;
            }
            else
            {

            }

            _Instncds[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < InstncdTrnsprt.Length; i++)
        {
            InstncdTrnsprt[i].Reinicio();
        }

        // Orden de Instanciado
        tmpActlzrDstncs = 0;
        Instncd_Crcn = 0;
        Instncd_Vld = 0;
    }

    void ActualizarDistancias()
    {
        float mnrDstnc = 1000;

        for (int i = 0; i < _DstnscInstncds.Length; i++)
        {
            _DstnscInstncds[i] = Vector3.Distance(new Vector3(_Personaje.position.x, 0, _Personaje.position.z), 
                new Vector3(_Instncds[i].position.x, 0, _Instncds[i].position.z));
            if (i <= Instncd_Vld && !_Instncds[i].gameObject.activeInHierarchy && mnrDstnc > _DstnscInstncds[i])
            {
                mnrDstnc = _DstnscInstncds[i];
                Instncd_Crcn = i;
            }
        }
    }
}
