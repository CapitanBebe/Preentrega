using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Propiedades
    [SerializeField] Animator playerMoves;
    public Vector2 turn;
    public float sensitivity = 2f;
    public Vector3 deltaMove;
    public float speed = 10;
    public Rigidbody rb;
    bool grounded = false;
    public Collider sword;
    float attack;
    public Collider shield;
    float defense;
    // Start is called before the first frame update
    void Start()
    {
        sword= GetComponent<Collider>();
        sword = GetComponent<Collider>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        movement();
        MouseRotation();
        attackDefense();
    }
    void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void movement() // ----------------------------- Move WASD & Jump -----------------------------------
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            speed = 10f;
            MovePlayer(Vector3.forward);
            playerMoves.SetBool("isRunning", true);
        }
        else
        {
            playerMoves.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerMoves.SetBool("Walking", true);
            speed = 5f;
            MovePlayer(Vector3.back);
        }
        else
        {
            playerMoves.SetBool("Walking", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
            playerMoves.SetBool("isRunning", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
            playerMoves.SetBool("isRunning", true);
        }
        if(Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
    void attackDefense() // -------------------------- attack & defense ----------------------------------
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerMoves.SetBool("Attack", true);
        }
        else
        {
            playerMoves.SetBool("Attack", false);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            playerMoves.SetBool("Defense", true);
        }
        else
        {
            playerMoves.SetBool("Defense", false);
        }
    }
    void MouseRotation()// ------------------------- Rotation Mouse ---------------------------------------
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
}
