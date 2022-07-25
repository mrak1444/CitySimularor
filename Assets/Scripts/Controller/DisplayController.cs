using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private GameObject _cam1;
    [SerializeField] private GameObject _cam2;
    [SerializeField] private GameObject _cam3;

    private void Start()
    {
        _cam1.SetActive(true);
        _cam2.SetActive(false);
        _cam3.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _cam1.SetActive(true);
            _cam2.SetActive(false);
            _cam3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _cam1.SetActive(false);
            _cam2.SetActive(true);
            _cam3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _cam1.SetActive(false);
            _cam2.SetActive(false);
            _cam3.SetActive(true);
        }
    }
}
