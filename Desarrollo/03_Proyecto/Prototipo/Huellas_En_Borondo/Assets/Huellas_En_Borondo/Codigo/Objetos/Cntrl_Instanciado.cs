using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Instanciado : MonoBehaviour
{
    float tmpActlzrDstncs;

    [Header("General")]
    public Transform _Personaje;

    [Header("Composicion")]
    public Transform[] _Instncds;
    public int Instncd_Crcn;
    public float[] _DstnscInstncds;



    // Start is called before the first frame update
    void Start()
    {
        _Instncds = new Transform[transform.childCount];
        _DstnscInstncds = new float[transform.childCount];

        for (int i = 0; i < _Instncds.Length; i++)
        {
            _Instncds[i] = transform.GetChild(i);
            _Instncds[i].gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (tmpActlzrDstncs <= 0)
        {
            ActualizarDistancias();
            tmpActlzrDstncs = .8f;
        }
        else
        {
            if (_DstnscInstncds[Instncd_Crcn] <= 62 && !_Instncds[Instncd_Crcn].gameObject.activeInHierarchy)
            {
                _Instncds[Instncd_Crcn].gameObject.SetActive(true);
            }
            tmpActlzrDstncs -= 1 * Time.deltaTime;
        }
    }


    void ActualizarDistancias()
    {
        float mnrDstnc = 1000;

        for (int i = 0; i < _DstnscInstncds.Length; i++)
        {
            _DstnscInstncds[i] = Vector3.Distance(new Vector3(_Personaje.position.x, 0, _Personaje.position.z), 
                new Vector3(_Instncds[i].position.x, 0, _Instncds[i].position.z));
            if (!_Instncds[i].gameObject.activeInHierarchy && mnrDstnc > _DstnscInstncds[i])
            {
                mnrDstnc = _DstnscInstncds[i];
                Instncd_Crcn = i;
            }
        }
    }
}
