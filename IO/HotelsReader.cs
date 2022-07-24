using Holiday.Model;
using Newtonsoft.Json;

namespace Holiday.IO;

public class HotelsReader:BasicReader
{
    public new int Counts;

    public new List<HotelModel> Results = new List<HotelModel>();

    public override void BeforeRead() { }
    public override void Reader(string path)
    {
        BeforeRead();
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            List<HotelModel> results = JsonConvert.DeserializeObject<List<HotelModel>>(json);
            Results = results;
            Counts = results.Count;
        }
        AfterRead();
    }

    public override void AfterRead() { }
    
}