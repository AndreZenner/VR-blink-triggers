
namespace BT
{
    public class Dummy : BlinkTrigger
    {
        public override void StartTrigger()
        {
            TriggerManager.Instance.OnTriggerStart?.Invoke();
            TriggerManager.Instance.OnTriggerEnd?.Invoke();
        }

    }
}