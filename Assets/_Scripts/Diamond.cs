using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gemDrop = 1;

 
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerWarning");

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.diamonds += gemDrop;
                Destroy(this.gameObject);
            }
        }
    }
}
