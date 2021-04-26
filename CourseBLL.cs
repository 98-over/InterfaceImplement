using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace InterfaceImplement
{
    public class CourseBLL
    {
        public List<Course> GetCourses()
        {

            CourseDAL courseDAL = new DAL.CourseDAL();
          return  courseDAL.GetCourses();


        }

        public void DeleteCourseById(string id)
        {

            CourseDAL courseDAL = new DAL.CourseDAL();
             courseDAL.DeleteCourseById(id);


        }
        public Course GetCourseById(string id)
        {

            CourseDAL courseDAL = new DAL.CourseDAL();
          return  courseDAL.GetCourseById(id);


        }

        public void EditCourse(Course course)
        {

            CourseDAL courseDAL = new DAL.CourseDAL();
             courseDAL.EditCourse(course);


        }


    }
    }
