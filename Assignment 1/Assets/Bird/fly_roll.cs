using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly_roll : MonoBehaviour
{
    public float horizontalSpeed;
    public float VerticallSpeed;
    public float Altitude;
    public float time = 0.5f;
    public Vector3 pos;
    public Vector3 rota = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        horizontalSpeed = 0.005f;
        pos = transform.position; //initial position
    }

    // Update is called once per frame
    void Update()
    {
        pos.z += horizontalSpeed;   //right or left movement
        transform.position = pos;
        transform.Rotate(rota);
    }
}
