using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trzd_Recorrido : MonoBehaviour
{
    [Header("General")]
    public bool Nombres;

    [Header("Composicion")]
    public int Pnts_Rcrrd;
    public GameObject _Recorrido;
    public string Lugar;
    int Lgr;
    public Transform PntRcrrd_Cali;
    public Transform PntRcrrd_Medellin;
    public Transform PntRcrrd_SBasilio;
    public Transform[] _Puntos;
    int NmrdPntsObstcl;

    // Start is called before the first frame update
    void Start()
    {
        _Puntos = null;
        int Cntd_Brrd = _Recorrido.transform.childCount;
        for (int i = 0; i < Cntd_Brrd; i++)
        {
            if (_Recorrido.transform.childCount > 0)
            {
                DestroyImmediate(_Recorrido.transform.GetChild(0).gameObject);
            }
        }
        Lgr = 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Crear_Recorrido();
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            Crear_Recorrido();
        }
    }

    void Crear_Recorrido()
    {
        // Numeracion de Puntos
        if (_Puntos == null)
        {
            _Puntos = new Transform[transform.childCount];
            for (int i = 0; i < _Puntos.Length; i++)
            {
                _Puntos[i] = transform.GetChild(i);
            }
        }
        else
        {
            if (Nombres)
            {
                NmrdPntsObstcl = 1;

                if ((transform.childCount > _Puntos.Length || transform.childCount < _Puntos.Length)
                    || (_Recorrido.transform.childCount > transform.childCount || _Recorrido.transform.childCount < transform.childCount)
                    || (_Recorrido.transform.GetChild(_Recorrido.transform.childCount - 1).name == PntRcrrd_Cali.name))
                {
                    _Puntos = null;
                    int Cntd_Brrd = _Recorrido.transform.childCount;
                    for (int i = 0; i < Cntd_Brrd; i++)
                    {
                        if (_Recorrido.transform.childCount > 0)
                        {
                            DestroyImmediate(_Recorrido.transform.GetChild(0).gameObject);
                        }
                    }
                    Lgr = 1;
                }
                else
                {
                    for (int i = 0; i < _Puntos.Length; i++)
                    {
                        if (_Puntos[i].tag == "Obstcl")
                        {
                            if (NmrdPntsObstcl <= 0)
                            {
                                NmrdPntsObstcl = 1;
                            }

                            switch (_Puntos[i].transform.localPosition.y)
                            {
                                case 0:
                                    _Puntos[i].name = "-(" + (NmrdPntsObstcl) + ")";
                                    break;
                                case 1:
                                    _Puntos[i].name = "-(" + (NmrdPntsObstcl) + ")" + " <->";
                                    break;
                            }
                            NmrdPntsObstcl++;
                        }
                        else
                        {
                            if (_Puntos[i].tag == "PntGrdr")
                            {
                                _Puntos[i].name = "-->";
                            }
                            else
                            {
                                _Puntos[i].name = "--";
                            }
                        }
                    }
                }

                Nombres = false;
            }
        }

        // Trazar Recorrido
        if (_Recorrido.transform.childCount <= 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject pntRcrrd_ = PntRcrrd_Cali.gameObject;
                if (_Puntos[i].transform.localPosition.y == 1)
                {
                    Lgr++;
                }
                switch (Lgr)
                {
                    case 1:
                        Lugar = "Cali";
                        pntRcrrd_ = PntRcrrd_Cali.gameObject;
                        break;
                    case 2:
                        pntRcrrd_ = PntRcrrd_Medellin.gameObject;
                        Lugar = "Medellin";
                        break;
                    case 3:
                        pntRcrrd_ = PntRcrrd_SBasilio.gameObject;
                        Lugar = "San Basilio";
                        break;
                }

                GameObject pntRcrrd = Instantiate(pntRcrrd_.gameObject);
                pntRcrrd.transform.parent = _Recorrido.transform;

                pntRcrrd.name = pntRcrrd_.name;
            }
        }
        else
        {
            for (int i = 0; i < _Recorrido.transform.childCount; i++)
            {
                _Recorrido.transform.GetChild(i).transform.position = new Vector3(transform.GetChild(i).position.x, _Recorrido.transform.position.y,
                    transform.GetChild(i).position.z);
                _Recorrido.transform.GetChild(i).transform.localRotation = Quaternion.identity;
                _Recorrido.transform.GetChild(i).transform.localScale = new Vector3(1, 1, 1);
            }

            Pnts_Rcrrd = _Recorrido.transform.childCount;
        }
    }
}
