using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool isGrounded;

    public bool IsGrounded => isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Tile>(out Tile ground))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Tile>(out Tile ground))
        {
            isGrounded = false;
        }
    }
}
