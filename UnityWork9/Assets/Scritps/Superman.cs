using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _dst;
    [SerializeField] private float _power;
    [SerializeField] private Transform _stop;
    private bool _go;

    private void Start()
    {
        _go = true;
    }

    private void Update()
    {
        GoToStop();
    }

    private void OnCollisionEnter(Collision enemy)
    {
        if (enemy.gameObject.name == "Enemy")
        {
            Vector3 direction = enemy.transform.position - transform.position;
            GetComponent<Rigidbody>().AddForce(direction.normalized * _power, ForceMode.Impulse);
        }
    }

    private void GoToStop()
    {
        if (_go == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _stop.position, Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, _stop.position) < _dst)
            {
                _go = false;
            }
        }
    }

}
