using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script that follows a specific target
/// </summary>
public class CameraFollow : MonoBehaviour {

    /// <summary>
    /// The transform to follow
    /// </summary>
    public Transform target;

    /// <summary>
    /// How fast should the camera follow the target.  Lower numbers give a more "dragging" feeling
    /// </summary>
    public float followSpeed = 1f;


    void Start() {
        // If target is null, send a warning message
        if(target == null ) {
            Debug.LogWarning(
                "Warning:  No target defined.  Please drag and drop the target you want to follow onto this script", 
                this);
        }
    }

    void Update() {

        // If target is not assigned, then stop early
        if ( target == null )
            return;

        // Create new position
        var followPosition = target.position;
        followPosition.y = transform.position.y;

        // Lerp towards the target
        transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime * followSpeed);
    }

}
