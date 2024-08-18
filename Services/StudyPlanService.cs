using System;
using Microsoft.EntityFrameworkCore;
using StudyPlannerAPI.Data;
using StudyPlannerAPI.Models;

namespace StudyPlannerAPI.Services;

public class StudyPlanService : IStudyPlanService
{
    private readonly ApplicationDbContext _context;
    public StudyPlanService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<String> CreateStudyPlanAsync(StudyPlan studyPlan)
    {
        var result = "Success";
        try
        {
            _context.StudyPlans.Add(studyPlan);
            await _context.SaveChangesAsync();
            return result;
        }
        catch (Exception e)
        {
            result = e.Message;
            return result;
        }
    }

    public async Task<String> DeleteStudyPlanAsync(int id)
    {
        var result = "Success";
        try
        {
            var studyPlan = await _context.StudyPlans.FindAsync(id);
            if (studyPlan != null)
            {
                _context.StudyPlans.Remove(studyPlan);
                await _context.SaveChangesAsync();
                return result;
            }
            else
            {
                result = "No study plan found with that ID.";
                return result;
            }
        }
        catch (Exception e)
        {
            result = e.Message;
            return result;
        }
    }

    public async Task<IEnumerable<StudyPlan>> GetAllStudyPlansAsync()
    {
        return await _context.StudyPlans.ToListAsync();
    }

    public async Task<StudyPlan> GetStudyPlanByIdAsync(int id)
    {
        var studyPlan = await _context.StudyPlans.FindAsync(id);
        return studyPlan!;
    }

    public async Task<String> UpdateStudyPlanAsync(StudyPlan studyPlan)
    {
        var result = "Success";
        try
        {
            var dbStudyPlan = await _context.StudyPlans.FindAsync(studyPlan.Id);
            if (dbStudyPlan != null)
            {
                dbStudyPlan.Name = studyPlan.Name;
                dbStudyPlan.Description = studyPlan.Description;
                dbStudyPlan.IsComplete = studyPlan.IsComplete;
                await _context.SaveChangesAsync();
                return result;
            }
            else
            {
                result = "No study plan found with that ID.";
                return result;
            }
        }
        catch (Exception e)
        {
            result = e.Message;
            return result;
        }
    }
}
