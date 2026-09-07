using Microsoft.AspNetCore.Mvc;
using WebApplication9.Enums;
using WebApplication9.Models;
using WebApplication9.Requests;

namespace WebApplication9.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : Controller
{
    public static List<Course> Courses = new List<Course>();

    [HttpPost("create-course")]
    public Course CreateCourse(CreateCourse course)
    {
        var newCourse = new Course()
        {
            Id = Courses.Count() + 1,
            Title = course.Title,
            Price = course.Price
        };
        
        Courses.Add(newCourse);
        
        return newCourse;
    }

    [HttpGet("get-all-courses")]
    public List<Course> GetAllCourses()
    {
        return Courses;
    }

    [HttpGet("get-courses-sorted")]
    public List<Course> GetCoursesSorted(SortType type)
    {
        if (type == SortType.Ascending)
        {
            return Courses.OrderBy(c => c.Price).ToList();
        }
        else if(type == SortType.Descending)
        {
            return Courses.OrderByDescending(c => c.Price).ToList();
        }
        else
        {
            return Courses;
        }
    }

    [HttpDelete("delete-course")]
    public Course DeleteCourse(DeleteCourse request)
    {
        var courseToDelete = Courses.FirstOrDefault(c => c.Id == request.Id);

        if (courseToDelete == null)
        {
            return null;
        }
        else
        {
            Courses.Remove(courseToDelete);
            
            return  courseToDelete;
        }
    }

    [HttpPut("update-course")]
    public Course UpdateCourse(UpdateCourse request)
    {
        var courseToUpdate = Courses.FirstOrDefault(c => c.Id == request.Id);
        
        if (courseToUpdate == null)
        {
            return null;
        }
        else
        {
            if (request.newPrice != 0 && request.newPrice != courseToUpdate.Price)
            {
                courseToUpdate.Price = request.newPrice;
            }

            if (request.newTitle != courseToUpdate.Title)
            {
             courseToUpdate.Title = request.newTitle;   
            }
            
            return courseToUpdate;
        }
    }
}