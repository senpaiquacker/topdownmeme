using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera playerCam;
    private Rigidbody selfRigid;
    [SerializeField]
    private float speed = 100;
    void Start()
    {
        playerCam = Camera.main;
        Camera.main.transform.parent = transform;
        selfRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical");
        movement = movement.normalized * speed;
        selfRigid.AddForce(movement, ForceMode.Impulse);
    }
}
