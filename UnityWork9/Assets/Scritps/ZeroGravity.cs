using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _dst;
    [SerializeField] private Transform _stop;
    private bool _go;
    private Vector3 _startPosition;

    private void Start()
    {
        _go = true;
        _startPosition = transform.position;
    }

    private void Update()
    {
        Go();
    }

    private void OnTriggerStay(Collider sphere)
    {
        if (sphere.gameObject.name == "DawnSphere")
        {
            sphere.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider sphere)
    {
        if (sphere.gameObject.name == "DawnSphere")
        {
            sphere.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void Go()
    {
        if (_go == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _stop.position, Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, _stop.position) < _dst)
            {
                _go = false;
            }
        }
        if (_go == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, _startPosition) < _dst)
            {
                _go = true;
            }
        }
    }

}
