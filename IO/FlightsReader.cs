using Holiday.Model;
using Newtonsoft.Json;

namespace Holiday.IO;

public class FlightsReader:BasicReader
{
    public new int Counts;

    public new List<FlightModel> Results = new List<FlightModel>();

    public override void BeforeRead() { }
    public override void Reader(string path)
    {
        
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            List<FlightModel> results = JsonConvert.DeserializeObject<List<FlightModel>>(json);
            Results = results;
            Counts = results.Count;
        }
    }

    public override void AfterRead() { }
    public override void Read(string path)
    {
        
        BeforeRead();
        Reader(path);
        AfterRead();
    }
}