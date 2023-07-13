using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Camara : MonoBehaviour
{
    public bool Cinematica;

    [Header("General")]
    public GameObject _Soporte;
    public Camera _Camara;
    public Transform _Rotacion;
    public Transform _Posicion;
    //
    public float VlcdRtcn;
    [HideInInspector]
    public float VlcdR;
    public float VlcdMvmnt;
    public float VlcdMvmntGnrl;
    //[HideInInspector]
    public float mltpl_VlcdMvmntGnrl;

    [Header("Composicion")]
    public GameObject _Objetivo;
    public Transform _CentroX;
    public Transform _CentroY;
    public float dstncrObjtvCntrX;
    public float dstncrObjtvCntrY;
    //
    [HideInInspector]
    public float PscnZ;
    [HideInInspector]
    public float pscnY;

    [Header("Referencias")]
    public Encuadre _Encuadre;


    [System.Serializable]
    public class Encuadre
    {
        [Header("Angulo")]
        public float Angl_X;
        public float Angl_Y;
        public float Angl_Z;

        [Header("Posicion")]
        public float Altr;
        public float Dstnc;
        public float Encdr_X;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        dstncrObjtvCntrX = _Objetivo.transform.position.x - _CentroX.position.x;
        dstncrObjtvCntrY = _Objetivo.transform.position.z - _CentroY.position.z;

        Rotacion();
        Mover();
    }


    void Rotacion()
    {
        Quaternion rtcn = _Rotacion.rotation;
        rtcn.eulerAngles = new Vector3(_Encuadre.Angl_X, _Encuadre.Angl_Y, _Encuadre.Angl_Z);
        _Rotacion.localRotation = Quaternion.Lerp(_Rotacion.localRotation, rtcn, VlcdR * Time.deltaTime);

        _Soporte.transform.rotation = Quaternion.Lerp(_Soporte.transform.rotation, _Objetivo.transform.GetChild(0).rotation, VlcdRtcn * Time.deltaTime);
    }
    void Mover()
    {
        _CentroX.parent.position = _Soporte.transform.position;
        _CentroX.position = new Vector3(_CentroX.position.x, _CentroX.position.y, _Objetivo.transform.position.z);
        _CentroY.position = new Vector3(_Objetivo.transform.position.x, _CentroY.position.y, _CentroY.position.z);
        //
        //_Posicion.localPosition = Vector3.Lerp(_Posicion.localPosition, new Vector3(_Encuadre.Encdr_X, _Encuadre.Altr, _Encuadre.Dstnc), VlcdMvmnt * Time.deltaTime);
        _Posicion.localPosition = new Vector3(_Posicion.localPosition.x, pscnY, PscnZ);


        Vector3 PscnObjtv = _Soporte.transform.position;
        PscnObjtv = new Vector3(_Objetivo.transform.position.x, _Objetivo.transform.position.y, _Objetivo.transform.position.z);
        //
        _Soporte.transform.position = Vector3.Lerp(_Soporte.transform.position, PscnObjtv, (VlcdMvmntGnrl * mltpl_VlcdMvmntGnrl) * Time.deltaTime);
    }
}
