using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
       if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeCoin();
            Destroy(gameObject);
        }
    }
}
