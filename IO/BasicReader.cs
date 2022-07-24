namespace Holiday.IO;

public interface IBasicReader
{
    public List<object>? Results { get; set; }
    public int Counts { get; set; }
    public void Read(string? path);
}
public abstract class BasicReader:IBasicReader
{
    
    public List<object>? Results { get; set; }
    public int Counts { get; set; }
    public abstract void Read(string path);
    public abstract void BeforeRead();
    public abstract void Reader(string path);
    public abstract void AfterRead();
}