using UnityEngine;
using UnityEngine.SceneManagement;

public class BoyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    private Rigidbody _rgbody;
    private Vector3 direction;

    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public CinemachineSwitcher cnSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        _rgbody = gameObject.GetComponent<Rigidbody>() as Rigidbody;        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
     
    }
    private void FixedUpdate()
    {
        Movement(direction);
    }

    void Movement(Vector3 direction)
    {
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //Get the "softened" rotation angle 
            transform.rotation = Quaternion.Euler(0f, angle, 0f); // Apply the rotation
            
            //Move the character
            _rgbody.MovePosition(transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        cnSwitcher.SwitchPriority();        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
