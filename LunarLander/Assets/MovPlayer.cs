using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovPlayer : MonoBehaviour {
    private Rigidbody2D rgb;
    [SerializeField]
    private Slider sliderFuel;
    private float vel;
    private float velRot;
    private int fuel;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }
    void Start ()
    {
        vel = 20f;
        velRot = 2f;
        fuel = 1000;
        ImpulsoInicial();
    }

    void FixedUpdate()
    {
        Acelerar();
        Rotar();
    }
    void Update ()
    {
        print(fuel);
        sliderFuel.value = fuel;
	}
    void ImpulsoInicial()
    {
        float velImpulsoIni = 20;
        rgb.AddRelativeForce(Vector2.right * Time.deltaTime * velImpulsoIni, ForceMode2D.Impulse);
    }
    void Acelerar()
    {
        if (Input.GetButton("Aceleration") && fuel > 0)
        {
            fuel--;
            rgb.AddRelativeForce(Vector2.up * Time.deltaTime * vel, ForceMode2D.Force);
        }
    }
    void Rotar()
    {
        if (Input.GetButton("RotarDer") && transform.rotation.z > -0.70)
        {
            rgb.AddTorque(-velRot);
        }
        else if (Input.GetButton("RotarIzq") && transform.rotation.z < 0.70)
        {
            rgb.AddTorque(velRot);
        }
        else
        {
            rgb.angularVelocity = 0;
        }
    }
}
