using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polars : MonoBehaviour
{
    // Start is called before the first frame update
    float radius = 1;
    float theta = 0;
    [SerializeField] float Xborde, Yborde;
    [SerializeField] float angularSpeed, angularAcceleration;

    [SerializeField] float radialSpeed, radialAcceleration;

     Vector2 polarCoord;// x es el radio y y es el theta
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //polarCoord.y += 0.01f;
       // polarCoord.x += 0.001f;
        DrawPolar(polarCoord);
        transform.localPosition=(PolarToCartesian(polarCoord));

        radialSpeed += radialAcceleration * Time.deltaTime;
        polarCoord.x += radialSpeed * Time.deltaTime;

        angularSpeed += angularAcceleration * Time.deltaTime;
        polarCoord.y += angularSpeed * Time.deltaTime;

        CheckCollisions();
    }
    private void DrawPolar(Vector2 polarCoord) {

        Vector3 cartesian = PolarToCartesian(polarCoord);
        Debug.DrawLine(Vector3.zero, cartesian, Color.yellow);
    }

    private Vector3 PolarToCartesian(Vector2 polar) {
        float r = polarCoord.x;
        float theta = polarCoord.y;
        Vector3 cartesian = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta));
        cartesian *= r;
        return cartesian;
    }

    private void CheckCollisions()
    {
        if ( Mathf.Abs(polarCoord.x) >=5)
        {

            radialSpeed *= -1;
            
        }

     
    }
}
