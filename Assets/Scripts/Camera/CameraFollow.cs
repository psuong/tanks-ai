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

    public Transform secondaryTarget;

    /// <summary>
    /// How fast should the camera follow the target.  Lower numbers give a more "dragging" feeling
    /// </summary>
    public float followSpeed = 1f;

    public bool lockHeight = false;
    public Vector2 heightRange = new Vector2(10, 20);


    Vector3 followPosition;

    /// <summary>
    /// The square root of 3
    /// </summary>
    float rootThree;


    void Start() {
        rootThree = Mathf.Sqrt(3f);

        // If target is null, send a warning message
        if(target == null ) {
            Debug.LogWarning(
                "Warning:  No target defined.  Please drag and drop the target you want to follow onto this script", 
                this);
        }
    }

    void LateUpdate() {

        // If target is not assigned, then stop early
        if ( target == null )
            return;

        // Create new position
        followPosition = target.position;
        var distance = Vector3.Distance(target.position, secondaryTarget.position);

        if ( !lockHeight )
            followPosition.y = Mathf.Clamp(distance * rootThree, heightRange.x, heightRange.y);
        else
            followPosition.y = transform.position.y;

        // Lerp towards the target
        transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime * followSpeed);
    }

}
