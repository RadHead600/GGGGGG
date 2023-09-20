public class UpgradeAddPlayerHealthPoints : UpgradeAddHealthPoints
{
    protected override void Awake()
    {
        UpgradeId = 0;
        base.Awake();
        Level = GameInformation.Instance.Information.UpgradesLevel[UpgradeId];
    }
}
