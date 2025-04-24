using System;
using UnityEngine;
using UnityEngine.UI;

namespace skv_toolkit
{
    public class BowlingManager : MonoBehaviour
{
    
    public GameObject bowlingBall;
    [SerializeField] private Rigidbody _ballRb;
    public float ballMoveSpeed;
    
    [Header("Ball moving bounds")]
    public float leftBound;
    public float rightBound;

    [Header("Charging")] 
    public Slider chargeSlider;
    public Image sliderFill;
    public float minForce;
    public float maxForce;
    public float chargeSpeed;
    
    private bool _isCharging;
    private float _chargeProgress;
    private float _chargeStartTime;

    private bool _canThrow;
    private bool _isAiming = true;

    private void Start()
    {
        _ballRb = GetRigidbody(bowlingBall);
        EnableBowling();
    }

    private void Update()
    {
        if (_isAiming && _canThrow)
        {
            BallAiming();
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isCharging = true;
                _chargeStartTime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _isCharging = false;
                float throwPower = Mathf.Lerp(minForce, maxForce,_chargeProgress);
                ThrowBall(throwPower);
            }

            if (_isCharging)
            {
                float timeSinceChargeStart = Time.time - _chargeStartTime;

                _chargeProgress = Mathf.PingPong(timeSinceChargeStart * chargeSpeed, 1);

                if (chargeSlider)
                    UpdateUISlider(_chargeProgress);
            }
            
        }
    }

    void ThrowBall(float throwPower)
    {
        DisableBowling();
        _ballRb.AddForce(Vector3.forward * throwPower, ForceMode.Impulse);
        
        _isAiming = false;
    }

    Rigidbody GetRigidbody(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            return rb;
        }
        else
        {
            Debug.LogError("Ball doesn't have a Rigidbody");
            return null;
        }
    }

    void EnableBowling()
    {
        _canThrow = true;
    }

    void DisableBowling()
    {
        _canThrow = false;
    }

    void BallAiming()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = bowlingBall.transform.position + Vector3.right * (moveInput * ballMoveSpeed * Time.deltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);
        bowlingBall.transform.position = newPosition;
    }

    void UpdateUISlider(float progress)
    {
        chargeSlider.value = progress;
        
        sliderFill.color = Color.Lerp(Color.white, Color.red, _chargeProgress);
    }
}

}
