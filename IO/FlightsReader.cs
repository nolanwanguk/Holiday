using Holiday.Model;
using Newtonsoft.Json;

namespace Holiday.IO;

public class FlightsReader:BasicReader
{
    public int Counts;

    public List<FlightModel> Results = new List<FlightModel>();

    public override void BeforeRead() { }
    public override void Reader(string path)
    {
        BeforeRead();
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            List<FlightModel> results = JsonConvert.DeserializeObject<List<FlightModel>>(json);
            Results = results;
            Counts = results.Count;
        }
        AfterRead();
    }

    public override void AfterRead() { }
    
}