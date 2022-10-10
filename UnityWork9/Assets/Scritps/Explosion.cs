using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _TimeToExplosion;
    [SerializeField] private float _Power;
    [SerializeField] private float _Radius;

    private void Update()
    {
        _TimeToExplosion -= Time.deltaTime;

        if(_TimeToExplosion <= 0 )
        {
            Boom();
        }
    }

    private void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody A in blocks)
        {
            if(Vector3.Distance(transform.position, A.transform.position) < _Radius)
            {
                Vector3 direction = A.transform.position - transform.position;
                A.AddForce(direction.normalized * _Power * (_Radius - Vector3.Distance(transform.position, A.transform.position)),ForceMode.Impulse);
            }    
        }
    }
}
