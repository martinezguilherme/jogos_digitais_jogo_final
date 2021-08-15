using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
 public InputManager inputManager;
 public controlarPersonagem controlarPersonagem;
    
 public Transform targetTransform;
 public Transform cameraPivot;
 private Vector3 cameraFollowVelocity = Vector3.zero;

 public float cameraFollowSpeed = 0.2f;
 public float cameraLookSpeed = 2;
 public float cameraPivotSpeed = 2;
 
 public float lookAngle;
 public float pivotAngle;
 private float minimumPivotAngle = 6;
 private float maximumPivotAngle = 16;


 public void HandleAllCameraMovement(){
     FollowTarget();
     rotateCamera();
 }

 private void FollowTarget(){
     Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
     transform.position = targetPosition;
 }

 private void rotateCamera(){
     if(inputManager!= null){
        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
     }if(controlarPersonagem != null){
          lookAngle = lookAngle + (controlarPersonagem.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (controlarPersonagem.cameraInputY * cameraPivotSpeed);
     }
     pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

     Vector3 rotation = Vector3.zero;
     rotation.y = lookAngle;
     Quaternion targetRotation = Quaternion.Euler(rotation);
     transform.rotation = targetRotation;


     rotation = Vector3.zero;
     rotation.x = pivotAngle;
     targetRotation = Quaternion.Euler(rotation);
     cameraPivot.localRotation = targetRotation;


 }


}
