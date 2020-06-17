using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3DHandler : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float height;
    public float damping;
    public float rotationDamping;
    public int Speed;
    public int worldLayerMask;

    void Start()
    {
        
    }

    private void UpdatePlayerTransform(Vector3 movementDirection)
{                
    RaycastHit hitInfo;

    if (GetRaycastDownAtNewPosition(movementDirection, out hitInfo)){
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        Quaternion finalRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, float.PositiveInfinity);

        transform.rotation = finalRotation;
        transform.position = hitInfo.point + hitInfo.normal * .5f;
    }
}

    // Calculate and set camera position
    private void HandleMovement(){
      Vector3 desiredPosition = this.target.TransformPoint(0, this.height, -this.distance);
      this.transform.position = Vector3.Lerp(this.transform.position, desiredPosition, Time.deltaTime * this.damping);
    }

    // Calculate and set camera rotation
    private void HandleRotation(){
      Quaternion desiredRotation = Quaternion.LookRotation(this.target.position - this.transform.position, this.target.up);
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, desiredRotation, Time.deltaTime * this.rotationDamping);
    }

    private bool GetRaycastDownAtNewPosition(Vector3 movementDirection, out RaycastHit hitInfo){
        Vector3 newPosition = transform.position;
        Ray ray = new Ray(transform.position + movementDirection * Speed, -transform.up);        

        if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, worldLayerMask))
        {
            return true;
        }

        return false;
    }

    public void HandleMovementInput(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
