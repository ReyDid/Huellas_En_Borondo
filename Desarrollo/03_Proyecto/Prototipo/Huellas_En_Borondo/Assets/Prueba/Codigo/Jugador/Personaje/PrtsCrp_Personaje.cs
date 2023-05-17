using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtsCrp_Personaje : MonoBehaviour
{
    [Header("General")]
    public int Id;
    [HideInInspector]
    public GameObject _Ancla;
    //
    [HideInInspector]
    public float VlcdSgmnt_Crp;
    [HideInInspector]
    public float Dstncmnt_Prt;

    [Header("Composicion")]
    public Vector3 PscnActlzd_Ancl;

    [Header("Referencias")]
    public Cntrl_Personaje _Personaje;


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
        Desplazamiento_Cuerpo();
    }


    void Desplazamiento_Cuerpo()
    {
        if (_Ancla != null)
        {
            PscnActlzd_Ancl = _Ancla.transform.position + (_Ancla.transform.forward * -Dstncmnt_Prt);

            Vector3 PntObjtv = PscnActlzd_Ancl;
            Vector3 Drccn = PntObjtv - transform.position;
            //
            transform.LookAt(PntObjtv);
            Quaternion Rtcn = transform.rotation;
            Rtcn.eulerAngles = new Vector3(0, Rtcn.eulerAngles.y, 0);

            transform.position += Drccn * ((VlcdSgmnt_Crp * _Personaje.CrpRgd.velocity.magnitude) * Time.deltaTime);
            transform.rotation = Rtcn;
        }
    }
}
