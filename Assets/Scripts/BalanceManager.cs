
public static class BalanceManager {
    private static int balance = 0;

    public static void Deposit(int coins) {
        balance += coins;
    }

    public static void Withdraw(int coins) {
        balance -= coins;
    }

    public static bool CanAfford(int cost) {
        return cost <= balance;
    }

    public static bool CanAfford(AbstractInventoryItem item) {
        return CanAfford(item.value);
    }

    public static int Get() {
        return balance;
    }

    public static void Set(int balance) {
        BalanceManager.balance = balance;
    }
}
