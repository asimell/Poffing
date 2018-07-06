using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaController : PlayerController {

    private bool nextToTree = false;

    public override void PlayerAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) && nextToTree)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (Collider c in colliders)
            {
                if (c.gameObject.CompareTag("Tree"))
                {
                    c.gameObject.SetActive(false);
                    return; // Only eat 1 tree
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            nextToTree = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            nextToTree = false;
        }
    }
}
