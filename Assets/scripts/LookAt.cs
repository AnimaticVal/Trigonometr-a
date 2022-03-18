using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 diference = mousePos - transform.position;
        float radians = Mathf.Atan2(diference.y, diference.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);
    }

   private Vector4 GetWorldMousePosition()
    {
        Camera camara = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x , Input.mousePosition.y, camara.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        Debug.DrawLine(Vector3.zero, transform.position);
        return worldPos;
    }
}
