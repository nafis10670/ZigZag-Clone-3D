using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperController : MonoBehaviour
{
    private bool walkingRight = true;

    public CharController charController;

    /*private void FixedpUpdate()
    {
        this.transform.position = this.transform.position + transform.forward * charController.walkingSpeed * Time.deltaTime;
    }*/

    private void Update()
    {
        this.transform.position = this.transform.position + transform.forward * charController.walkingSpeed * Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
/*        if (collision.gameObject.CompareTag("Player"))
        {
            print("INSIDE");
        }*/
        print("INSIDE" + collision.transform.name);

    }
}
