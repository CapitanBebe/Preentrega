using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
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
        Debug.Log(Hp);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            hitAndDie.SetBool("GetsHit", true);
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
