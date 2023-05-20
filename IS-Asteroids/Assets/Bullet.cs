using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
    }
}
