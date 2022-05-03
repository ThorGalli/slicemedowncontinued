using UnityEngine;

public class SliceableBehaviour : MonoBehaviour {

    [SerializeField] GameObject leftHalf;
    [SerializeField] GameObject rightHalf;
    [SerializeField] GameObject particles;
    Vector3 cutForce;

    private void Awake() {
        cutForce = new Vector3(0,0,1f);
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<MeshRenderer>().material.color = newColor;
        leftHalf.GetComponent<MeshRenderer>().material.color = newColor;
        rightHalf.GetComponent<MeshRenderer>().material.color = newColor;
    }

    private void OnTriggerEnter(Collider other) {
        bool bladeEdge = other.gameObject.layer == 8;
        if (bladeEdge)
            Cut();
    }

    public void Cut() {
        GameManager.Instance.addPoint();
        leftHalf.SetActive(true);
        leftHalf.GetComponent<Rigidbody>().AddForce(cutForce);
        rightHalf.SetActive(true);
        rightHalf.GetComponent<Rigidbody>().AddForce(-cutForce);
        particles.SetActive(true);
        gameObject.SetActive(false);
    }
}
