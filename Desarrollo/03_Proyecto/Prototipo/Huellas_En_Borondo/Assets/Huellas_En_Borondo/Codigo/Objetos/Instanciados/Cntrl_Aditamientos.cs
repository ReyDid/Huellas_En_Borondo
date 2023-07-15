using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Aditamientos : MonoBehaviour
{
    [Header("General")]
    public bool Instncd;

    [Header("Composicion")]
    public Transform _Macetas;
    public Transform _Letras;
    public Transform _ColeccionHlls;
    public Transform _Alfeñiques;
    public Transform _MtsMedicinales;
    //
    [HideInInspector]
    public List<Transform> _ObjetosRegalo;

    // Start is called before the first frame update
    void Start()
    {
        _ObjetosRegalo.Add(_ColeccionHlls);
        _ObjetosRegalo.Add(_Alfeñiques);
        _ObjetosRegalo.Add(_MtsMedicinales);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
    }
}
