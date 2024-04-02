using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoEnemigo : MonoBehaviour
{
    public GameObject puntoA;
    public GameObject puntoB;
    private Rigidbody2D rigid2D;
    private Transform currentPoint;
    public float speed;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        currentPoint = puntoB.transform;
    }
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == puntoB.transform)
        {
            rigid2D.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigid2D.velocity = new Vector2(-speed,0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == puntoB.transform)
        {
            currentPoint = puntoA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == puntoA.transform)
        {
            currentPoint = puntoB.transform;
        }
    }
}
