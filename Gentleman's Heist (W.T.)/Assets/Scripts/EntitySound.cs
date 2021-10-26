using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Decided to make this a script you attach to some 2d circle, which is attached to an entity that is needed
 * Will modify the size of the circle
 */
public class EntitySound : MonoBehaviour
{
    // The ratio at which an objects velocity impacts it's sound. Could be dynamically changed
    public double speedToRadiusRatio;
    
    // The current sound radius that will be displayed
    private double _currentRadius;

    // The amount of time currentRadius will not be updated with velocity (ie after SetSoundEvent)
    private int _eventFrames;
    
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _eventFrames = 0;
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_eventFrames > 0)
        {
            _eventFrames -= 1;
        }
        else
        {
            _currentRadius = (rb.velocity.magnitude) * speedToRadiusRatio;
        }
        
        gameObject.transform.localScale = new Vector3((float) _currentRadius / 2.0f, (float) _currentRadius / 2.0f, 1f);
    }

    /*
     * Given some in game event (ex: tripping) allows outside setting of a custom radius for limited time (frames)
     * Hint: The game should run at 60fps
     * TODO: Untested
     */
    public void SetSoundEvent(double newRadius, int numFrames)
    {
        _currentRadius = newRadius;
        _eventFrames = numFrames;
    }

    public double GetCurrentRadius()
    {
        return _currentRadius;
    }
}
