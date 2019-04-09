using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conecasttestex : MonoBehaviour
{

    public float radius;
    public float depth;
    public float angle;

    private Physics physics;

    void FixedUpdate()
    {

        RaycastHit[] coneHits = physics.ConeCastAll(transform.position, 10, transform.forward, 20, 45);

        if (coneHits.Length > 0)
        {
            for (int i = 0; i < coneHits.Length; i++)
            {
                //do something with collider information
                coneHits[i].collider.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1f);
            }
        }
    }
}
