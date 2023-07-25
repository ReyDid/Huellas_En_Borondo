using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instncd_Transporte : MonoBehaviour
{
    bool Rncr;

    [Header("General")]
    public bool Conduccion;
    public bool EnManejo;

    [Header("Composicion")]
    [HideInInspector]
    public GameObject _Transporte;
    public Transform Pscn;
    [HideInInspector]
    public GameObject Conductor;
    [HideInInspector]
    public GameObject Pasajero1;
    [HideInInspector]
    public GameObject Pasajero2;
    public Transform Puesto1;
    public Transform Puesto2;

    [Header("Referencias")]
    public Almcn_Objetos _Almacen;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Trnsprt = null;
        switch (name)
        {
            case "Chiva":
                Trnsprt = _Almacen.Chiva.gameObject;
                break;
            case "Canasto":
                Trnsprt = _Almacen.Canastos.gameObject;
                break;
            case "Canoa":
                Trnsprt = _Almacen.Canoa.gameObject;
                break;
        }

        _Transporte = Trnsprt;
        _Transporte.SetActive(true);
        Pscn.parent.localRotation = Quaternion.identity;
        Pscn.parent.localPosition = Vector3.zero;
        Puesto1 = _Transporte.GetComponent<Cntrl_Objetos>()._Tipo.Pst_1;
        Puesto2 = _Transporte.GetComponent<Cntrl_Objetos>()._Tipo.Pst_2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Quaternion rtr = _Transporte.transform.rotation;
        rtr.eulerAngles = new Vector3(_Transporte.GetComponent<Cntrl_Objetos>()._Tipo.OrntcnPltfrm.eulerAngles.x, Pscn.eulerAngles.y,
            _Transporte.GetComponent<Cntrl_Objetos>()._Tipo.OrntcnPltfrm.eulerAngles.z);
        _Transporte.transform.rotation = Quaternion.Lerp(_Transporte.transform.rotation, rtr, 2 * Time.deltaTime);
        _Transporte.transform.position = Pscn.position;

        if (Conductor != null && Conduccion)
        {
            Manejo();
        }
        if (Rncr)
        {
            Pscn.parent.localRotation = Quaternion.identity;
            Pscn.parent.localPosition = Vector3.zero;

            Rncr = false;
        }
    }

    public void Reinicio()
    {
        EnManejo = false;
        Rncr = true;
    }

    void Manejo()
    {
        Pscn.parent.rotation = Conductor.transform.rotation;
        Pscn.parent.position = Conductor.transform.position;

        if (Puesto2.childCount <= 0)
        {
            //EnManejo = true;

            Pasajero1.transform.GetChild(0).parent = Puesto1;
            Puesto1.transform.GetChild(0).localRotation = Quaternion.identity;
            Pasajero2.transform.GetChild(0).parent = Puesto2;
            Puesto2.transform.GetChild(0).localRotation = Quaternion.identity;
        }

        Puesto1.GetChild(0).localPosition = Vector3.Lerp(Puesto1.GetChild(0).localPosition, Vector3.zero, 4 * Time.deltaTime);
        Puesto2.GetChild(0).localPosition = Vector3.Lerp(Puesto2.GetChild(0).localPosition, Vector3.zero, 4 * Time.deltaTime);

        if (!EnManejo)
        {
            GameObject prsnj1 = Pasajero1.transform.GetChild(0).gameObject;
            GameObject prsnj2 = Pasajero2.transform.GetChild(0).gameObject;
            prsnj1.transform.parent = Puesto1;
            prsnj2.transform.parent = Puesto2;

            Puesto1.transform.GetChild(0).parent = Pasajero1.transform;
            Puesto2.transform.GetChild(0).parent = Pasajero2.transform;
            Puesto1.transform.GetChild(0).parent = Pasajero1.transform;
            Puesto2.transform.GetChild(0).parent = Pasajero2.transform;

            Pasajero1.transform.GetChild(0).localRotation = Quaternion.identity;
            Pasajero2.transform.GetChild(0).localRotation = Quaternion.identity;
            //Pasajero1.transform.GetChild(0).localPosition = Vector3.zero;
            //Pasajero2.transform.GetChild(0).localPosition = Vector3.zero;

            Pasajero1 = null;
            Pasajero2 = null;

            Conduccion = false;
            Conductor = null;
        }
    }
}
