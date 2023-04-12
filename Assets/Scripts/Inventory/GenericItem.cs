using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItem : AbstractInventoryItem {

    public GenericItem(string id, string name, string description, bool canUse, bool canDrop)
        : base(id, name, description, canUse, canDrop) { }

    public override void Use(PlayerController player) { }
}
