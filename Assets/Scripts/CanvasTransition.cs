using UnityEngine;

public class CanvasTransition : MonoBehaviour
{
    [SerializeField] private GameObject Canvas1;
    [SerializeField] private GameObject Canvas2;
    [SerializeField] private GameObject Canvas3;
    [SerializeField] private GameObject Canvas4;
    [SerializeField] private GameObject Canvas5;

    public void StartTransition()
    {

        // Enable the second canvas
        Canvas1.SetActive(true);
        Canvas2.SetActive(true);
        Canvas3.SetActive(true);
        Canvas4.SetActive(true);
        Canvas5.SetActive(true);
    }
}