using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flashlight : MonoBehaviour
{
    private Light2D Light;
    void Start()
    {
        Light = GetComponent<Light2D>();
        Light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Light.enabled = !Light.enabled;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
    }
}
