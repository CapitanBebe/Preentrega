using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{// Propiedades
    enum EnemyMoves { StaringThenJump, TortugaCreadora }
    [SerializeField] EnemyMoves enemyMove;
    [SerializeField] Transform targetPosition;
    public GameObject Enemigos;
    public float speed = 1f;
    public Transform target;
    public Transform targetRotate;
    public float rotationTime;
    float spawn = 0;
    Quaternion targetRotation;
    bool rotating = false;
    public GameObject destroy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyMove)
        {
            case EnemyMoves.TortugaCreadora:
                Disparador();
                break;

            case EnemyMoves.StaringThenJump:
                Invoke("StaringThenAttack", 1f);
                break;
        }
    }
    void Disparador()
    {
        transform.RotateAround(targetRotate.position, Vector3.up, speed * Time.deltaTime);
        spawn += Time.deltaTime;
        transform.LookAt(targetPosition);
        if (spawn > 5)
        {
            Instantiate(Enemigos, transform.position, transform.localRotation);
            spawn = 0;
        }
    }
    void StaringThenAttack()
    {
        Vector3 relativePosition = target.position - transform.position;
        targetRotation = Quaternion.LookRotation(relativePosition);
        rotating = true;
        rotationTime = 0;
        if (rotating)
        {
            rotationTime += Time.deltaTime * speed;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationTime);
            if (rotationTime > 1)
            {
                rotating = false;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            Debug.Log("toco");
            Destroy(destroy,0);
        }
    }
}
