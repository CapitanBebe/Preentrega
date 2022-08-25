using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    // Propiedades
    [SerializeField] Animator hitAndDie;
    public GameObject destroy;
    int Hp = 3;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            hitAndDie.SetBool("GetsHit", true);
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            Hp--;
        }
        else
        {
            hitAndDie.SetBool("GetsHit", false);
        }
        if (Hp <= 0)
        {
            hitAndDie.SetBool("Dies", true);
            Destroy(destroy, 1);
        }
    }
}
