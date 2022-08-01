using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPlayer : MonoBehaviour
{

    public float Velocidad = 8f;
    public GameObject Municion;
    public GameObject GeneradorDisparo;
    public bool PuedoDisparar = true;
    public float TiempoDeEspera = 1.5f;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            MoverJugador(Vector3.forward);
            Debug.Log("Me muevo hacia adelante");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoverJugador(Vector3.back);
            Debug.Log("Me muevo hacia atrás");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoverJugador(Vector3.left);
            Debug.Log("Me muevo hacia la izquierda");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoverJugador(Vector3.right);
            Debug.Log("Me muevo hacia la derecha");
        }

        if (Input.GetKeyUp(KeyCode.X))
        {

            if (PuedoDisparar)
            {
                PuedoDisparar = false;
                Disparo();
                Invoke("ResetDisparo", TiempoDeEspera);
            }
        }
    }


    private void MoverJugador(Vector3 direction)
    {
        transform.Translate(direction * Velocidad * Time.deltaTime);
    }

    private void Disparo()
    {
        Instantiate(Municion, GeneradorDisparo.transform.position, Municion.transform.rotation);
        Debug.Log("Estoy disparando");
    }

    private void ResetDisparo()
    {
        PuedoDisparar = true;
    }
}
