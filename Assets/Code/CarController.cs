
using UnityEngine;

public class CarController : MonoBehaviour
{
    GameObject[] wheels = new GameObject[2];

    const byte leftWheel = 0;
    const byte rightWheel = 1;

    [SerializeField]
    private float horsePower = 450;
    [SerializeField]
    private float mass = 1500;
    [SerializeField]
    private float maxSpeed = 205;

    float inputVertical;
    float inputHorizontal;

    public float move = 0;
    float rotation;

    float racingCoefficient;
    float wheelAngle = 0;

    float rotationSpeed = 1;

    private static class Coefficients
    {
        public const float Inertion = 0.5f;
        public const float Reverse = 0.75f;
        public const float Break = 2f;
    }

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass / 1000;

        racingCoefficient = mass / horsePower;

        wheels[leftWheel] = GameObject.Find("Left Forward Wheel");
        wheels[rightWheel] = GameObject.Find("Right Forward Wheel");
    }

    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
        

        if (inputVertical > 0 && move < maxSpeed)
        {
            move += inputVertical * racingCoefficient * Time.deltaTime;
        }

        

        rotation = inputHorizontal * -rotationSpeed;
    }

    void FixedUpdate()
    {
        RotateWheels();

        transform.Translate(0f,move,0f);

        if (move > 0 || move < 0)
        {
            transform.Rotate(0f, 0f, rotation);
        }
    }

    void RotateWheels()
    {
        if (wheelAngle < 45 && inputHorizontal != 0)
        {
            wheels[leftWheel].transform.Rotate(0, 0, wheelAngle * -inputHorizontal * Time.deltaTime);

            wheels[rightWheel].transform.Rotate(0, 0, wheelAngle * -inputHorizontal * Time.deltaTime);

            wheelAngle++;
        }
        else if (inputHorizontal == 0)
        {
            wheelAngle = 0;
            wheels[leftWheel].transform.rotation = new Quaternion(0, 0, wheelAngle, 0);
            wheels[rightWheel].transform.rotation = new Quaternion(0, 0, wheelAngle, 0);
        }
    }

    bool PositiveCheck(float srcNumber, float value, float coeff, bool isWithDelta) =>
        isWithDelta ? srcNumber - value * Time.deltaTime * coeff > 0 : srcNumber - value * coeff > 0;
}
