using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almcn_Objetos : MonoBehaviour
{
    [Header("General")]
    public GameObject Cj_Frutas;
    //
    public Cntrl_Objetos _Fruta;

    [Header("Composicion")]
    public int Cntd_Frts;
    public Cntrl_Objetos[] _Frutas;


    // Start is called before the first frame update
    void Start()
    {
        _Frutas = new Cntrl_Objetos[Cntd_Frts];
        for (int i = 0; i < Cntd_Frts; i++)
        {
            GameObject Objt = Instantiate(_Fruta.gameObject);
            Objt.transform.parent = Cj_Frutas.transform;
            Objt.transform.position = Cj_Frutas.transform.position;
            Objt.name = "Fruta_" + (i + 1);

            _Frutas[i] = Objt.GetComponent<Cntrl_Objetos>();
            _Frutas[i].gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
