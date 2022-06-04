using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float velocidade = 70f;

    public void BuscarAlvo(Transform umTarget)
    {
        target = umTarget;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direcao = target.position - transform.position;
        float distanciaNesteFrame = velocidade * Time.deltaTime;

        if (direcao.magnitude <= distanciaNesteFrame)
        {
            AcertarAlvo();
            return;
        }

        transform.Translate(direcao.normalized * distanciaNesteFrame, Space.World);
    }

    private void AcertarAlvo()
    {
        Destroy(gameObject);
    }
}
