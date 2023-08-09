using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f, horizontalSpeed = 10f;

    private Rigidbody _rb;

    public Light mainLight;

    public Text scoreText;

    public GameObject accessCube;

    private int _score = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        

    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed * Time.fixedDeltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        _rb.velocity = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectiveCube")
        {
            _score++;
            Destroy(other.gameObject);
            if (_score < 6)
                scoreText.text = "Score: " + _score;
            else
            {
                scoreText.text = "You win!";
                accessCube.SetActive(false);
            }
                
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathZones")
        {
            Destroy(gameObject);
            scoreText.text = "You death! Press R to restart level";
            mainLight.enabled = false;            
        }
        if (collision.gameObject.tag == "TransitionToANewLevel")
            TransitionANewLevel();
        
    }
    public void TransitionANewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
