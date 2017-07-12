using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovPlayer : MonoBehaviour {
    private Rigidbody2D rgb;
    private SpriteRenderer rend;
    [SerializeField]
    private Sprite spriteInmovil;
    [SerializeField]
    private Sprite spriteAcelerar;
    [SerializeField]
    private Slider sliderFuel;
    [SerializeField]
    private Text velocityHorizontalText;
    [SerializeField]
    private Text velocityVerticalText;
    private float vel;
    private float velRot;
    private int fuel;
    private float limiteRotacion;
    private bool acelerar;
    private bool rotarDer;
    private bool rotarIzq;

    void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }
    void Start ()
    {
        vel = 20f;
        velRot = 2f;
        fuel = 500;
        limiteRotacion = 0.70f;
        ImpulsoInicial();
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.9f));
        transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if(acelerar)
        {
            rgb.AddRelativeForce(Vector2.up * Time.deltaTime * vel, ForceMode2D.Force);
        }
        if(rotarDer)
        {
            rgb.AddTorque(-velRot);
        }
        else if (rotarIzq)
        {
            rgb.AddTorque(velRot);
        }

    }
    void Update ()
    {
        Acelerar();
        Rotar();
        sliderFuel.value = fuel;
        velocityHorizontalText.text = "Velocity Horizontal: " + rgb.velocity.x * 10;
        velocityVerticalText.text = "Velocity Vertical: " + rgb.velocity.y * 10;
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
            acelerar = true;
            rend.sprite = spriteAcelerar;
        }
        else
        {
            acelerar = false;
            rend.sprite = spriteInmovil;
        }
    }
    void Rotar()
    {
        if (Input.GetButton("RotarDer") && transform.rotation.z > -limiteRotacion)
        {
            rotarDer = true;
        }
        else if (Input.GetButton("RotarIzq") && transform.rotation.z < limiteRotacion)
        {
            rotarIzq = true;
        }
        else
        {
            rotarDer = false;
            rotarIzq = false;
            rgb.angularVelocity = 0;
        }
    }
}
