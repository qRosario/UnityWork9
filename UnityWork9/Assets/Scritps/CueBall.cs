using UnityEngine;

public class CueBall : MonoBehaviour
{
    [SerializeField] private float _Power;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.back * _Power, ForceMode.Impulse);
    }
}
