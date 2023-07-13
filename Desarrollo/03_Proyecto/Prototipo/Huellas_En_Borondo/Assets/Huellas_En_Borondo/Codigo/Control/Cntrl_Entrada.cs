using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cntrl_Entrada : MonoBehaviour
{
    Entrada _Entrada;

    [HideInInspector]
    public float Pausa;

    [HideInInspector]
    public float Dsplzmnt_H;
    [HideInInspector]
    public float Dspzmnt_V;
    [HideInInspector]
    public float Cambio;
    [HideInInspector]
    public float Salto;


    // Start is called before the first frame update
    void Start()
    {
        _Entrada = new Entrada();
        _Entrada.Movimiento.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        Asignacion_Entrada();
    }

    void Asignacion_Entrada()
    {
        Pausa = _Entrada.Movimiento.Pausa.ReadValue<float>();

        Dsplzmnt_H = _Entrada.Movimiento.Desplazamiento.ReadValue<Vector2>().x;
        Dspzmnt_V = _Entrada.Movimiento.Desplazamiento.ReadValue<Vector2>().y;

        Cambio = _Entrada.Movimiento.Cambio.ReadValue<float>();
        Salto = _Entrada.Movimiento.Salto.ReadValue<float>();
    }
}
