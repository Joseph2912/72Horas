using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private int golpes = 0;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            golpes++;
            other.GetComponent<VidaEnemy>().RecibirGolpe();

        }
    }
    public void AumentarGolpes()
    {
        golpes++;
    }
}
