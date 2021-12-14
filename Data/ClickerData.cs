namespace StarClicker.Data;
using System.Timers;

public class ClickerData
{
    private Timer timer = new(100);
    private bool _didGameStart = false;
    private bool _didWin = false;
    private bool _doesOverflow = false;

    public Action OnUpdate;
    public ulong ProductionSpeed = 1;
    
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
        _hydrogenCount += ProductionSpeed;
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
        OnUpdate.Invoke();
    }

    public void Start()
    {
        if (_didGameStart) return;
        _didGameStart = true;
        timer.Start();
        timer.Elapsed += (sender, eventArgs) => Update();
    }
}