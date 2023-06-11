using System;

public class Orm : IDisposable
{
    private Database _database;

    public Orm(Database database)
    {
        this._database = database;
    }
    
    public void Dispose()
    {
        this._database.Dispose();
    }

    public void Begin()
    { 
        _database.BeginTransaction();
    }

    public void Write(string data)
    {
        try
        {
            _database.Write(data);
        }
        catch (Exception)
        {
            Dispose();
        }
        
    }

    public void Commit()
    {
        try
        {
            _database.EndTransaction();
        }
        catch (Exception e)
        {
            Dispose();
        }
    }
}
