using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Huellas : MonoBehaviour
{
    [Header("General")]
    public bool Instanciador;
    [HideInInspector]
    public bool Instncr;

    [Header("Referencias")]
    public Instanciado _Instanciado;
    public Huellas _Huellas;

    [System.Serializable]
    public class Instanciado
    {
        [HideInInspector]
        public bool Incd;

        [HideInInspector]
        public Cntrl_Huellas _Huellas;
        public Cntrl_Huellas Huella;
        [HideInInspector]
        public Instncd_Objetos Actl_Pnt;
        //[HideInInspector]
        public Instncd_Objetos Sgnt_Pnt;
        public float Dstnc_ActlSgnt;

        public Transform[] _Instncds;
        public int Expancion_Huellas;
        [HideInInspector]
        public float Espcd;

        public Almcn_Objetos _Almacen;
    }
    [System.Serializable]
    public class Huellas
    {
        public Transform Rastreo;
        public GameObject Huella;
    }

    void Awake()
    {
        if (Instanciador)
        {
            _Instanciado._Huellas = Instantiate(_Instanciado.Huella);
            _Instanciado._Huellas.transform.parent = transform;
            _Instanciado._Huellas.transform.localPosition = Vector3.zero;
            _Instanciado._Huellas.transform.localRotation = Quaternion.identity;
            _Instanciado._Huellas.transform.localScale = new Vector3(1, 1, 1);

            _Instanciado._Huellas.name = _Instanciado.Huella.name;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instanciador)
        {
            _Instanciado._Instncds = new Transform[3];
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Instanciador && Instncr)
        {
            for (int i = 0; i < _Instanciado._Instncds.Length; i++)
            {
                _Instanciado._Instncds[i] = transform.GetChild(i);
            }

            if (transform != transform.parent.GetChild(transform.parent.childCount - 1))
            {
                Trazado_Rastro();
            }
            Instncr = false;
        }
        else
        {

        }
    }

    void Trazado_Rastro()
    {
        float RndmPnt = Random.Range(0, 2);
        int rndmCntdRgl = Random.Range(1, 3);
        // Rastreo de Hellas
        _Instanciado.Dstnc_ActlSgnt = Vector3.Distance(transform.position, _Instanciado.Sgnt_Pnt.transform.position);
        float dstnc = _Instanciado.Dstnc_ActlSgnt;
        if (dstnc > 0 && dstnc < 10)
        {
            _Instanciado.Expancion_Huellas = 2;
        }
        else if (dstnc > 0 && dstnc < 20)
        {
            _Instanciado.Expancion_Huellas = 3;
        }
        else if (dstnc > 0 && dstnc < 40)
        {
            _Instanciado.Expancion_Huellas = 5;
        }
        else if (dstnc > 0 && dstnc < 50)
        {
            _Instanciado.Expancion_Huellas = 7;
        }
        else
        {
            _Instanciado.Expancion_Huellas = 1;
        }
        _Instanciado.Espcd = 4.8f;
        float Espcd = _Instanciado.Espcd;


        for (int I = 0; I < _Instanciado.Expancion_Huellas; I++)
        {
            float espcd = 0;
            if (_Instanciado.Expancion_Huellas <= 1)
            {
                espcd = 0;
            }
            else
            {
                if (I == 0)
                {
                    espcd = 0;
                }
                else
                {
                    espcd = Espcd;
                    Espcd = Espcd + _Instanciado.Espcd;
                }
            }


            for (int i = 0; i < _Instanciado._Instncds.Length; i++)
            {
                for (int ii = 0; ii < _Instanciado._Almacen.Cj_Rastreo.transform.childCount; ii++)
                {
                    if (!_Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).gameObject.activeInHierarchy)
                    {
                        // Instanciar Huella
                        _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).position = _Instanciado._Instncds[i].position;
                        _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).LookAt(_Instanciado.Sgnt_Pnt.Puntos_Inctnc[i].position);
                        _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).localPosition = _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).localPosition +
                            (_Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).transform.forward * espcd);
                        _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).localScale = new Vector3(1, 1, 1);
                        if (!_Instanciado.Actl_Pnt.NoHuellas)
                        {
                            _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).gameObject.SetActive(true);
                        }
                        // Instanciar Aditamento
                        if (I > 1)
                        {
                            if (i == RndmPnt)
                            {
                                // Maceta
                                if (!_Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>().Instncd)
                                {
                                    if (Cntrl_Personaje.Maceta)
                                    {
                                        for (int iI = 0; iI < _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Macetas.childCount; iI++)
                                        {
                                            if (!_Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Macetas.GetChild(iI).gameObject.activeInHierarchy)
                                            {
                                                _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Macetas.GetChild(iI).position =
                                                    _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).position;
                                                _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Macetas.GetChild(iI).rotation =
                                                    _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).rotation;
                                                _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Macetas.GetChild(iI).localScale = new Vector3(1, 1, 1);
                                                _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Macetas.GetChild(iI).gameObject.SetActive(true);

                                                Cntrl_Personaje.Maceta = false;
                                                _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>().Instncd = true;
                                                iI = _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Macetas.childCount;
                                            }
                                        }
                                    }
                                }
                                // Letra
                                if (I > 2)
                                {
                                    if (!_Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>().Instncd)
                                    {
                                        if (Cntrl_Personaje.Letra && Cntrl_Personaje.Letras > 0)
                                        {
                                            for (int iI = 0; iI < _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.childCount; iI++)
                                            {
                                                if (!_Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).gameObject.activeInHierarchy)
                                                {
                                                    _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).position =
                                                        _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).position;
                                                    _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).rotation =
                                                        _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).rotation;
                                                    _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).localScale = new Vector3(1, 1, 1);
                                                    _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).gameObject.SetActive(true);

                                                    for (int Ltr = 0; Ltr < Cntrl_Personaje.Palabra.Length; Ltr++)
                                                    {
                                                        char ltr = Cntrl_Personaje.Palabra[Ltr];
                                                        _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).name = ltr.ToString();
                                                        int idO = 0;
                                                        switch (Cntrl_Personaje.Palabra.Length)
                                                        {
                                                            case 6:
                                                                idO = 1;
                                                                break;
                                                            case 4:
                                                                idO = 2;
                                                                break;
                                                            case 1:
                                                                idO = 3;
                                                                break;
                                                        }
                                                        if (_Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).name == "O")
                                                        {
                                                            _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.GetChild(iI).name += "_" + idO;
                                                        }

                                                        Cntrl_Personaje.Palabra = Cntrl_Personaje.Palabra.Substring(Ltr + 1);
                                                        Ltr = Cntrl_Personaje.Palabra.Length;
                                                    }

                                                    Cntrl_Personaje.Letras--;
                                                    Cntrl_Personaje.Letra = false;
                                                    _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>().Instncd = true;
                                                    iI = _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._Letras.childCount;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            // Regalo
                            int rndmR = Random.Range(1, 5);
                            if (!_Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>().Instncd)
                            {
                                if (rndmR == 3 || rndmR == 5)
                                {
                                    int objt = 0;
                                    if (Cntrl_Personaje.Alfeñique)
                                    {
                                        int rndmObjt = Random.Range(1, 5);

                                        switch (rndmObjt)
                                        {
                                            case 3:
                                                objt = 1;
                                                break;
                                        }
                                    }
                                    if (Cntrl_Personaje.MtMedicinal)
                                    {
                                        objt = 2;
                                        Cntrl_Personaje.MtMedicinal = false;
                                    }

                                    for (int iI = 0; iI < _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._ObjetosRegalo[objt].childCount; iI++)
                                    {
                                        if (!_Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._ObjetosRegalo[objt].GetChild(iI).gameObject.activeInHierarchy)
                                        {
                                            _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._ObjetosRegalo[objt].GetChild(iI).position =
                                                _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).position;
                                            _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._ObjetosRegalo[objt].GetChild(iI).rotation =
                                                _Instanciado._Almacen.Cj_Rastreo.transform.GetChild(ii).rotation;
                                            _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._ObjetosRegalo[objt].GetChild(iI).localScale = new Vector3(1, 1, 1);
                                            _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._ObjetosRegalo[objt].GetChild(iI).gameObject.SetActive(true);

                                            if (rndmCntdRgl <= 0)
                                            {
                                                _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>().Instncd = true;
                                            }
                                            rndmCntdRgl--;
                                            iI = _Instanciado._Huellas.GetComponent<Cntrl_Aditamientos>()._ObjetosRegalo[objt].childCount;
                                        }
                                    }
                                }
                            }
                        }

                        ii = _Instanciado._Almacen.Cj_Rastreo.transform.childCount;
                    }
                }
            }
        }
    }
}
