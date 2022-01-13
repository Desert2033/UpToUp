using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float dumping = 1.5f;
    private Vector3 offset;
    public GameObject stiv;
    public float oldStivPosY;

    // Start is called before the first frame update
    void Start()
    {
        oldStivPosY = stiv.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldStivPosY != stiv.transform.position.y)
        {
            offset = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, offset, dumping * Time.deltaTime);
            oldStivPosY = stiv.transform.position.y;
        }
    }
}
