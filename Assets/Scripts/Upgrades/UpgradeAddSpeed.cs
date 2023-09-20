public class UpgradeAddSpeed : Upgrade
{
    protected override void Awake()
    {
        UpgradeId = 1;
        base.Awake();
        Level = GameInformation.Instance.Information.UpgradesLevel[UpgradeId];
    }

    private void Start()
    {
        UnitUpgrade.OnSpeedSet += LastValueUpdate;
        SetUpgradeLevel();
    }

    protected override void SetUpgradeLevel()
    {
        base.SetUpgradeLevel();
        UnitUpgrade.SetStaticSpeed(UnitUpgrade.UnitParameters.MinSpeed + float.Parse(Parameters.ToString()) * Level);
        OnActivate?.Invoke();
    }

    public override void Activate()
    {
        if (UpLevel())
        {
            UnitUpgrade.SetStaticSpeed(UnitUpgrade.Speed + float.Parse(Parameters.ToString()));
            OnActivate?.Invoke();
        }
    }

    public void LastValueUpdate(float amount)
    {
        LastValue = amount.ToString();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        UnitUpgrade.OnSpeedSet -= LastValueUpdate;
    }
}
