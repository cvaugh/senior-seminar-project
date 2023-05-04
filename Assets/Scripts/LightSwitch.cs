using UnityEngine;

public class LightSwitch : Interactable {
    public Light lightComponent;
    private Transform switchPivot;

    void Start() {
        switchPivot = transform.GetChild(0);
        UpdateSwitchRotation();
    }

    private void UpdateSwitchRotation() {
        switchPivot.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, lightComponent.enabled ? 45.0f : -45.0f));
    }

    public override void Interact(PlayerController player) {
        lightComponent.enabled = !lightComponent.enabled;
        UpdateSwitchRotation();
        if(lightComponent.enabled) {
            AudioRegistry.Play("switch23");
        } else {
            AudioRegistry.Play("switch22");
        }
    }
}
