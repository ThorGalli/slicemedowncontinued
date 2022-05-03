using UnityEngine;

public class CameraManBehaviour : MonoBehaviour {
    [SerializeField] Transform targetTransform;
    private Vector3 moveVector;


    private void OnEnable() {
        moveVector = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);
    }
    void FixedUpdate() {
        UpdateMoveVector(targetTransform.position);
        transform.position = moveVector;
    }

    private void UpdateMoveVector(Vector3 target) {
        moveVector.x += (target.x - moveVector.x) / 16;
        moveVector.y += (target.y - moveVector.y) / 4;
    }

}
