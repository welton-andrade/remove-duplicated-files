namespace DuplicatedFiles;

public class PathNChecksunMap {
  public string path { get; set; }
  public string checksun { get; set; }

  public PathNChecksunMap(string path, string checksun)
  {
    this.path = path;
    this.checksun = checksun;
  }

    public override string ToString()
    {
        return path + "\n\t" + checksun;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)  
          return false;
            
            // If the passed object is not Customer Type, return False
        if (!(obj is PathNChecksunMap))
          return false;
        
        return (this.checksun == ((PathNChecksunMap)obj).checksun);
    }

    public override int GetHashCode()
    {
        return path.GetHashCode() ^ checksun.GetHashCode();
    }
}
