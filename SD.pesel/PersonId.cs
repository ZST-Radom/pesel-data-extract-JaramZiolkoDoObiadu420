namespace SD.pesel;

public class PersonId
{
    private readonly string _id;
    public PersonId(string Id)
    {
        _id = Id;
    }
    /// <summary>
    /// Get full year from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYear()
    {
        string id = _id;
        string year = id.Substring(startIndex: 2, length: 2);
        int yearInt = int.Parse(year);
        string result = id.Substring(startIndex: 0, length: 2);
        if (yearInt <= 12)
        {
            int year19 = int.Parse("19" + result);
            return year19;
        } else
        {
            int year20 = int.Parse("20" + result);
            return year20;
        }
    }

    /// <summary>
    /// Get month from PESEL
    /// </summary>
    public int GetMonth()
    {
        string id = _id;
        string month = id.Substring(startIndex: 2, length: 1);

        int result = int.Parse(id.Substring(startIndex: 2, length: 2));
        int monthInt = int.Parse(month);
        if (monthInt == 0 || monthInt == 1 )
        {
            return result;
        }
        else
        {
            return result - 20;
        }
    }
    /// <summary>
    /// Get day from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetDay()
    {
        string id = _id;
        string result = id.Substring(startIndex: 4, length: 2);
        int resultInt = int.Parse(result);

        return resultInt;
    }

    /// <summary>
    /// Get year of birth from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetAge()
    {
        int rok = DateTime.Today.Year;
        return rok - GetYear();
    }

    /// <summary>
    /// Get gender from PESEL
    /// </summary>
    /// <returns>m</returns>
    /// <returns>f</returns>
    public string GetGender()
    {
        string id = _id;
        string gender = id.Substring(startIndex: 10, length: 1);
        int genderInt = int.Parse(gender);
        if (genderInt % 2 == 0)
        {
            return "k";
        }else
        {
            return "m";
        }
    }

    /// <summary>
    /// check if PESEL is valid
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        int idN;
        string id = _id;
        if (id.Length > 11)
        {
            return false;
        }
        else if (id.Length == 11)
        {
            return true;
        }
        else if (!int.TryParse(id, out idN))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}