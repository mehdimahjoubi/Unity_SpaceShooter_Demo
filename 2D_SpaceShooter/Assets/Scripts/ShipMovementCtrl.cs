using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovementCtrl : MonoBehaviour
{

    public float acceleration = 100;
    public float maxSpeed = 1000;
    public GameObject idleFire;
    public GameObject accelFire;
    public GameObject backwardFire;
    public GameObject rightSideFire;
    public GameObject leftSideFire;
    public float marginTop = 40;
    public float marginBottom = 40;
    public float marginRight = 40;
    public float marginLeft = 40;
    float posCorrection = 0.01f;
    float currentSpeed;
    float maxTopScreenPos;
    float maxRightScreenPos;
    float latestVerticalAxis;
    float latestHorizontalAxis;
    
    void Start()
    {
        maxTopScreenPos = Camera.main.pixelHeight - marginTop;
        maxRightScreenPos = Camera.main.pixelWidth - marginRight;
    }
    
    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x >= marginLeft && screenPos.x <= maxRightScreenPos
            && screenPos.y >= marginBottom && screenPos.y <= maxTopScreenPos
            && rigidbody2D.velocity.magnitude < maxSpeed)
        {
            rigidbody2D.AddForce(new Vector2(h * acceleration, v * acceleration));
        }
        if (accelFire != null)
        {
            var b = Input.GetButton("Vertical") && (v > latestVerticalAxis || v > 0);
            if (accelFire.activeSelf != b)
                accelFire.SetActive(b);
        }
        if (idleFire != null)
        {
            var b = !Input.GetButton("Vertical") || v < latestVerticalAxis || v <= 0;
            if (idleFire.activeSelf != b)
                idleFire.SetActive(b);
        }
        if (backwardFire != null)
        {
            var b = Input.GetButton("Vertical") && (v < latestVerticalAxis || v < 0);
            if (backwardFire.activeSelf != b)
                backwardFire.SetActive(b);
        }
        if (rightSideFire != null)
        {
            var b = Input.GetButton("Horizontal") && (h < latestHorizontalAxis || h < 0);
            if (rightSideFire.activeSelf != b)
                rightSideFire.SetActive(b);
        }
        if (leftSideFire != null)
        {
            var b = Input.GetButton("Horizontal") && (h > latestHorizontalAxis || h > 0);
            if (leftSideFire.activeSelf != b)
                leftSideFire.SetActive(b);
        }
        latestVerticalAxis = v;
        latestHorizontalAxis = h;
    }

    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < marginLeft)
        {
            var pos = transform.position;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector3(marginLeft + posCorrection, 0, 0)).x;
            transform.position = pos;
        }
        if (screenPos.x > maxRightScreenPos)
        {
            var pos = transform.position;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector3(maxRightScreenPos - posCorrection, 0, 0)).x;
            transform.position = pos;
        }
        if (screenPos.y < marginBottom)
        {
            var pos = transform.position;
            pos.y = Camera.main.ScreenToWorldPoint(new Vector3(0, marginBottom + posCorrection, 0)).y;
            transform.position = pos;
        }
        if (screenPos.y > maxTopScreenPos)
        {
            var pos = transform.position;
            pos.y = Camera.main.ScreenToWorldPoint(new Vector3(0, maxTopScreenPos - posCorrection, 0)).y;
            transform.position = pos;
        }
    }

}
