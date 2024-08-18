using System;

namespace StudyPlannerAPI.Models;

public class StudyPlan
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; }

}
