using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject ObjeGameObject;
    void Start()
    {
        Transform transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var t = ObjeGameObject.GetComponent<Transform>();
        var x = t.position.x;
        var y = t.position.y;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
