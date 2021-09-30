using UnityEngine;

public class AutomicDoorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private float _doorCloseAt;

    private float _doorOpenAt;

    private bool _isDoorOpen;

    private void Update()
    {
        // xử lý ở đây :v
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isDoorOpen && _doorOpenAt + 0.5f < Time.time)
        {
            // Debug.Log("Open the door !");
            _animator.SetBool("OnSensor", true);
            _isDoorOpen = true;
            _doorOpenAt = Time.time;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _isDoorOpen && _doorCloseAt + 0.5f < Time.time)
        {
            // Debug.Log("Close the door !");
            _animator.SetBool("OnSensor", false);
            _isDoorOpen = false;
            _doorCloseAt = Time.time;
        }
    }

    private void OnValidate()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }


    public void OnDoorClosed()
    {
    }
}
