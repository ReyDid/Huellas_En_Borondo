using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Villano : MonoBehaviour
{
    [Header("General")]
    public GameObject _PersonajeV;
    [HideInInspector]
    public GameObject _Avatar;
    public bool Accion;

    [Header("Composicion")]
    public Transform Objtv_Persecucion;
    //
    public float Vlcd_Rtcn;
    public float Vlcd_Mvmnt;
    //
    float Dstncd;

    // Start is called before the first frame update
    void Start()
    {
        _Avatar = _PersonajeV.transform.GetChild(0).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Rotacion();
        Movimiento();
    }

    void Rotacion()
    {
        _PersonajeV.transform.GetChild(1).LookAt(Objtv_Persecucion.position);
        Quaternion Rtcn = _PersonajeV.transform.GetChild(1).rotation;
        Rtcn.eulerAngles = new Vector3(Objtv_Persecucion.eulerAngles.x, Rtcn.eulerAngles.y, Objtv_Persecucion.eulerAngles.z);

        _Avatar.transform.rotation = Quaternion.Lerp(_Avatar.transform.rotation, Rtcn, Vlcd_Rtcn * Time.deltaTime);
    }
    void Movimiento()
    {
        if (Accion)
        {
            Dstncd = 0;
        }
        else
        {
            Dstncd = 33;
        }

        _PersonajeV.transform.position = Vector3.Lerp(_PersonajeV.transform.position, Objtv_Persecucion.position + (-Objtv_Persecucion.forward * Dstncd), 
            Vlcd_Mvmnt * Time.deltaTime);
    }
}
