
using UnityEngine;

public class Movement : MonoBehaviour
{

    Vector3 movement;

    public float walkSpeed;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Walk()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
    }
}
