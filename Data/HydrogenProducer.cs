using System.Drawing;

namespace StarClicker.Data;

public class HydrogenProducer
{
    public string name = "Asteroid";
    public Color color = Color.Gray;
    public ulong productionRate = 1;
    public ulong producerCount = 0;
    public ulong cost;

    public HydrogenProducer(ulong producerCost, ulong rate, string producerName)
    {
        cost = producerCost;
        productionRate = rate;
        name = producerName;
    }
}

public static class PredefinedProducers
{
    private static List<HydrogenProducer> _templates = new List<HydrogenProducer>();

    public static List<HydrogenProducer> Templates
    {
        get
        {
            if (_templates.Count == 0)
            {
                _templates.Add(new HydrogenProducer(40, 1, "Asteroid"));
                _templates.Add(new HydrogenProducer(1000, 10, "Planetoid"));
                _templates.Add(new HydrogenProducer(100000, 100, "Exoplanet"));
                _templates.Add(new HydrogenProducer(10000000, 1000, "Gas giant"));
                _templates.Add(new HydrogenProducer(1000000000, 1000000, "Super-jupiter"));
                _templates.Add(new HydrogenProducer(10000000000, 1000000000, "M class star"));
                _templates.Add(new HydrogenProducer(100000000000, 100000000000, "K class star"));
                _templates.Add(new HydrogenProducer(1000000000000, 1000000000000, "G class star"));
                _templates.Add(new HydrogenProducer(10000000000000, 10000000000000, "F class star"));
                _templates.Add(new HydrogenProducer(100000000000000, 1000000000000000, "A class star"));
                _templates.Add(new HydrogenProducer(1000000000000000, 10000000000000, "B class star"));
                
                _templates.Add(new HydrogenProducer(10000000000000000, 100000000000000, "O class star"));
                _templates.Add(new HydrogenProducer(1000000000000000000, 100000000000000000, "Black hole"));
                _templates.Add(new HydrogenProducer(10000000000000000000, 1000000000000000000, "White hole"));
                _templates.Add(new HydrogenProducer(10000000000000000000, 10000000000000000000, "Worm hole"));
            }
            return _templates;
        }
        private set {}
    }
}