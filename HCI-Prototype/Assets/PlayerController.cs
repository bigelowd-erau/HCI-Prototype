using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float moveSpeed = 17.5f;
    private Vector3 playerVelocity;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    float turnSpeed = 250.0f;
    void FixedUpdate()
    {
        int l = 0;
        int v = 0;
        if (Input.GetKey(KeyCode.A))
            l--;
        if (Input.GetKey(KeyCode.W))
            v++;
        if (Input.GetKey(KeyCode.D))
            l++;
        if (Input.GetKey(KeyCode.S))
            v--;
        Move(l, v);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * turnSpeed);
    }

    private void Move(int latDir, int lonDir)
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        //move straight
        //rb.velocity = new Vector3(lonDir * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y) * moveSpeed, 0, lonDir*Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y) * moveSpeed);
        //rb.velocity = new Vector3(latDir * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y) * moveSpeed, 0, latDir * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y) * moveSpeed);
        //rb.velocity = new Vector3((latDir * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y) + lonDir * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y)) * moveSpeed, 0, (latDir * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y) + lonDir * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y)) * moveSpeed);


    }
    /*private void FixedUpdate()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Get the angle between the points
        float angle = AngleBetweenPoints(positionOnScreen, mouseOnScreen);
        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle*10, 0f));
        /*Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        //Angle between mouse and this object
        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }*/
    float AngleBetweenPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
