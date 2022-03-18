using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQuad : MonoBehaviour
{
    Vector3 displacement, diferencia;
    Vector3 velocity, acceleration;
    [SerializeField] float velocidad;
    float rad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Orbit();
    }
    public void Move() {
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        diferencia = targetPos - transform.position;

        velocity = diferencia.normalized;
        displacement = velocity * Time.deltaTime * velocidad;
        transform.position = transform.position + displacement;
    }
    public void Orbit() {
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        
        diferencia = targetPos - transform.position;
        acceleration = diferencia;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        rad = Mathf.Atan2(velocity.y , velocity.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, rad * Mathf.Rad2Deg);
    }
    

}
