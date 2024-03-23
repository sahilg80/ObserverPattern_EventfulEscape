public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public EventController OnLightSwitchToggled { get; private set; }
    public EventController<int> OnKeyPickedUp { get; private set; }
    public EventController OnLightsOffByGhostEvent { get; private set; }
    public EventController PlayerEscapedEvent { get; private set; }
    public EventController PlayerDeathEvent { get; private set; }
    public EventController OnRatRushEvent { get; private set; }
    public EventController OnSkullShowerEvent { get; private set; }
    public EventController<int> OnPotionDrink { get; private set; }
    public EventController OnKitchenItemFloatEvent { get; private set; }
    public EventController OnPaintingMove { get; private set; }
    public EventService()
    {
        OnLightSwitchToggled = new EventController();
        OnKeyPickedUp = new EventController<int>();
        OnLightsOffByGhostEvent = new EventController();

        PlayerEscapedEvent = new EventController();
        PlayerDeathEvent = new EventController();
        OnRatRushEvent = new EventController();
        OnSkullShowerEvent = new EventController();
        OnPotionDrink = new EventController<int>();

        OnKitchenItemFloatEvent = new EventController();
        OnPaintingMove = new EventController();
    }
}
