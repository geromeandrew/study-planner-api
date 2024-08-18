using System;
using StudyPlannerAPI.Models;

namespace StudyPlannerAPI.Services;

public interface IStudyPlanService
{
    Task<IEnumerable<StudyPlan>> GetAllStudyPlansAsync();
    Task<StudyPlan> GetStudyPlanByIdAsync(int id);
    Task<String> CreateStudyPlanAsync(StudyPlan studyPlan);
    Task<String> UpdateStudyPlanAsync(StudyPlan studyPlan);
    Task<String> DeleteStudyPlanAsync(int id);

}
