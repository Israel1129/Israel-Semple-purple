using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trex : MonoBehaviour
{
    // Start is called before the first frame update
    public Color color;
    public trex daddy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeColor(color);
    }

    void changeColor(Color that_ughhh)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = that_ughhh;
    }
}
