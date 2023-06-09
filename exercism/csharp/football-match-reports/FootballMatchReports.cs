using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        // simplified 
        // switch (shirtNum)
        // {
        //     case 1:
        //         return "goalie";
        //     case 2:
        //         return "left back";
        //     case <= 4:
        //         return "center back";
        //     case 5:
        //         return "right back";
        //     case <= 8:
        //         return "midfielder";
        //     case 9:
        //         return "left wing";
        //     case 10:
        //         return "striker";
        //     case 11:
        //         return "right wing";
        //     default:
        //         throw new ArgumentOutOfRangeException();
        // }
        
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            <= 4 => "center back",
            5 => "right back",
            <= 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int:
                return $"There are {report} supporters at the match.";
            case string strReport:
                return strReport;
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Incident incident:
                return incident.GetDescription();
            case Manager { Club: null } manager:
                return manager.Name;
            case Manager manager:
                return $"{manager.Name} ({manager.Club})";
            default:
                throw new ArgumentException();
        }
    }
}
