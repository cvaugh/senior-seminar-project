public class GenericItem : AbstractInventoryItem {

    public GenericItem(string id, string name, string description, bool canUse, bool canDrop, int value)
        : base(id, name, description, canUse, canDrop, value) { }

    public override void Use(PlayerController player) { }
}
