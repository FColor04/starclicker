using System.Drawing;

namespace StarClicker.Data;

public class HydrogenProducer
{
    public string name = "Asteroid";
    public Color color = Color.Gray;
    public ulong productionRate = 1;
    public ulong producerCount = 0;
    public ulong cost;

    public HydrogenProducer(ulong producerCost, ulong rate, string testProducer)
    {
        cost = producerCost;
        productionRate = rate;
        name = testProducer;
    }
}