using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    private BoxCollider2D knifeCollider;
    private Rigidbody2D rb;

    private WaitForSeconds secondDueToCollide = new WaitForSeconds(1);
    private bool isCollide = false;

    private void Awake()
    {
        knifeCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine("DeactivateColliderForOneSecond");
        Invoke("FallIfNotCollide",1.1f);
    }

    private IEnumerator DeactivateColliderForOneSecond()
    {
        knifeCollider.enabled = false;
        yield return secondDueToCollide;
        knifeCollider.enabled = true;
    }

    private void FallIfNotCollide()
    {
        if (!isCollide)
        {
            knifeCollider.enabled = false;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            rb.gravityScale=1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="target")
        {
            knifeCollider.enabled = false;
            isCollide = true;
            transform.parent.SetParent(collision.collider.transform);
        }
    }

}
