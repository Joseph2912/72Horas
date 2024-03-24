using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{
    public GameObject canvasOne;
    public GameObject canvasDos;

    // Método para activar el canvas legal
    public void MostrarCanvasOpciones()
    {
        canvasOne.SetActive(true);
        canvasDos.SetActive(false);
    }

    // Método para desactivar el canvas legal
    public void OcultarCanvasOpciones()
    {
        canvasOne.SetActive(false);
        canvasDos.SetActive(true);
    }
}