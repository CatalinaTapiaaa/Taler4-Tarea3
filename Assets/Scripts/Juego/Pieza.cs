using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pieza : MonoBehaviour
{
    public bool desactivar;
    [Header("Velocidad")]
    public GameObject objectPiezasManager;
    public PiezasManager piezasManager;
    [Header("Controles")]
    public GameObject objectBotonDe;
    public GameObject objectBotonIz;
    public Button botonDe;
    public Button botonIz;

    Rigidbody rb;

    void Start()
    {
        objectBotonDe = GameObject.Find("De");
        objectBotonIz = GameObject.Find("Iz");
        objectPiezasManager = GameObject.Find("MANAGERS");

        botonDe = objectBotonDe.GetComponent<Button>();
        botonIz = objectBotonIz.GetComponent<Button>();
        piezasManager = objectPiezasManager.GetComponent<PiezasManager>();
        rb = gameObject.GetComponent<Rigidbody>();

        botonDe.onClick.AddListener(Derecha);
        botonIz.onClick.AddListener(Izquierda);
    }
    void Update()
    {
        if (!desactivar)
        {
            transform.position = new Vector3(0, transform.position.y - piezasManager.velocidad * Time.deltaTime, 0);
        }
        if (desactivar)
        {
            rb.useGravity = true;

            botonDe.onClick.RemoveListener(Derecha);
            botonIz.onClick.RemoveListener(Izquierda);
        }
    }

    public void Derecha()
    {
        transform.Rotate(0, -90, 0);
    }
    public void Izquierda()
    {
        transform.Rotate(0, 90, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        desactivar = true;

        if (collision.gameObject.CompareTag("Pieza"))
        {

        }
        if (collision.gameObject.CompareTag("Pancake"))
        {

        }
    }
}
