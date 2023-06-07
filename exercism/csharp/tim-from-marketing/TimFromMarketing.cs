using System;
using System.Collections.Generic;
using System.Linq;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string outputId = "[" + id + "]";
        string outputName = name;
        string outputDepartment = department?.ToUpper() ?? "OWNER";
        return id != null 
            ? string.Join(" - ", new List<string> { outputId, outputName, outputDepartment }) 
            : string.Join(" - ", new List<string> {outputName, outputDepartment });
    }
}
