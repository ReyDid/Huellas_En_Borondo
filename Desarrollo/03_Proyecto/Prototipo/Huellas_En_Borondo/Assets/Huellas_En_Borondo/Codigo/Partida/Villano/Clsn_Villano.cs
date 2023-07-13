using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clsn_Villano : MonoBehaviour
{
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
        
    }

    void OnTriggerEnter(Collider Otr)
    {
        if (Otr.gameObject.layer == 23)
        {
            Otr.GetComponent<Clsn_Objetos>()._Objetos.Dstr = true;
        }
    }
}
