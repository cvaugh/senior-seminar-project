using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {
    private MenuController mc;
    private Rigidbody2D rb;
    private Vector2 currentPivot;
    private Vector2 target;

    // Start is called before the first frame update
    void Start() {
        mc = Camera.main.GetComponent<MenuController>();
        rb = GetComponent<Rigidbody2D>();
        SetNewPivot();
        SetNewTarget();
        transform.position = new Vector3(target.x, target.y, transform.position.z);
        SetNewTarget();
    }

    // Update is called once per frame
    void Update() {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 d = target - pos;
        d.Normalize();
        float rot = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rot - 90.0f),
            mc.beeTurnSpeed * Time.deltaTime);
        if(Vector2.Distance(pos, target) < mc.beeForgetRange) {
            if(Random.Range(0.0f, 1.0f) > 0.75f) {
                SetNewPivot();
            }
            SetNewTarget();
        } else {
            rb.AddForce((target - pos).normalized * mc.beeSpeed);
        }
        if(rb.velocity.magnitude > mc.beeMaxSpeed) {
            rb.velocity = rb.velocity.normalized * mc.beeMaxSpeed;
        }
    }

    public void SetNewPivot() {
        currentPivot = new Vector2(Random.Range(mc.screenMin.x, mc.screenMax.x), Random.Range(mc.screenMin.y, mc.screenMax.y));
        Debug.Log(currentPivot);
    }

    public void SetNewTarget() {
        target = Random.insideUnitCircle * mc.beeRange + currentPivot;
    }
}
