using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour {
    Rigidbody2D rgb;
    float vel;
    float velRot;
    float acum;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }
    void Start ()
    {
        ImpulsoInicial();
        vel = 10f;
        velRot = 2f;
        acum = 0;
	}

    void FixedUpdate()
    {
        Acelerar();
        Rotar();
    }
    void Update () {
		
	}
    void ImpulsoInicial()
    {
        float velImpulsoIni = 20;
        rgb.AddRelativeForce(Vector2.right * Time.deltaTime * velImpulsoIni, ForceMode2D.Impulse);
    }
    void Acelerar()
    {
        if (Input.GetButton("Aceleration"))
        {
            rgb.AddRelativeForce(Vector2.up * Time.deltaTime * vel, ForceMode2D.Force);
        }
    }
    void Rotar()
    {
        if(Input.GetButton("RotarDer") && transform.rotation.z < 90)
        {
            rgb.AddTorque(-velRot);
            acum += velRot;
        }
    }
}
