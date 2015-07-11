using UnityEngine;
using System.Collections;

public class SoftPlatform : MonoBehaviour {

    private Collider2D parentCol;

    void Start()
    {
        parentCol = transform.parent.GetComponent<Collider2D>();//GetComponentInParent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), parentCol, true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), parentCol, false);
        }
    }
}
