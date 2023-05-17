using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnt_Fruta : MonoBehaviour
{
    public bool Blq;

    [Header("General")]
    [HideInInspector]
    public GameObject _Muestra;


    // Start is called before the first frame update
    void Start()
    {
        _Muestra = transform.GetChild(1).gameObject;
        _Muestra.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay(Collider Otr)
    {
        if (Otr.tag == "CrpPrsnj")
        {
            Blq = true;
        }
    }
    void OnTriggerExit(Collider Otr)
    {
        if (Otr.tag == "CrpPrsnj")
        {
            Blq = false;
        }
    }
}
