using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f, horizontalSpeed = 10f, thrust = 500f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed * Time.fixedDeltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
        _rb.velocity = transform.TransformDirection(new Vector3(vertical, _rb.velocity.y, -horizontal));

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Block")
        {
            _rb.AddForce(new Vector3(0, 1, 0) * thrust);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggerMain")
        {
            Debug.Log("Trigger Correct");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TriggerMain")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "TriggerMain")
        {
            Debug.Log("Trigger Correct");
        }
    }
}
