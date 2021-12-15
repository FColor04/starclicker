namespace StarClicker.Data;
using System.Timers;

public class ClickerData
{
    private Timer timer = new(100);
    private bool _didGameStart = false;
    private bool _didWin = false;
    private bool _doesOverflow = false;

    public Action OnUpdate = delegate() {};
    public List<HydrogenProducer> producers = new List<HydrogenProducer>();

    //When this limit is reached, convert all the hydrogen into helium
    private readonly ulong syntheticHydrogenLimit = 10000000000000000000;
    private ulong _hydrogenCount = 0;
    public ulong HydrogenCount => _hydrogenCount;
    public string HydrogenCountText => _hydrogenCount+"H";
    
    //Helium
    private readonly ushort _syntheticHeliumLimit = 10000;
    private ushort _overflowCounter = 0;
    public ushort HeliumCount => _overflowCounter;
    public string HeliumCountText => _overflowCounter + (_doesOverflow ? "+" : "") + "He";

    public void Update()
    {
        foreach (var hydrogenProducer in producers)
        {
            _hydrogenCount += hydrogenProducer.producerCount * hydrogenProducer.productionRate;
        }
        if (_hydrogenCount >= syntheticHydrogenLimit)
        {
            _hydrogenCount = 0;
            _overflowCounter++;
            if (_overflowCounter >= _syntheticHeliumLimit)
            {
                _doesOverflow = true;
                _overflowCounter = _syntheticHeliumLimit;
                if (!_didWin)
                {
                    //TODO: Prompt win
                }
                _didWin = true;
            }
            else
            {
                _doesOverflow = false;
            }
        }
        if(OnUpdate != null)
            OnUpdate.Invoke();
    }

    public void Start()
    {
        if (_didGameStart) return;
        _didGameStart = true;
        timer.AutoReset = true;
        timer.Elapsed += (sender, eventArgs) => Update();
        timer.Enabled = true;
    }

    public void BuyProducer(HydrogenProducer producer)
    {
        if (producer.cost <= _hydrogenCount)
        {
            _hydrogenCount -= producer.cost;
            var producerInList = producers.FirstOrDefault(listProducer => listProducer.name == producer.name);
            if(producerInList != null)
            {
                producerInList.producerCount++;
            } else {
                producer.producerCount = 1;
                producers.Add(producer);
            }
        }
    }

    public void AddOneHydrogen()
    {
        _hydrogenCount++;
    }
}