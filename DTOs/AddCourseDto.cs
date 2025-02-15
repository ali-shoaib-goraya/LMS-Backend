﻿using Dynamic_RBAMS.Models;

namespace Dynamic_RBAMS.DTOs
{
    public class AddCourseDto
    {
        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        public int CreditHours { get; set; }

        public bool IsLab { get; set; }
        public bool IsCompulsory { get; set; }

        public bool IsTheory { get; set; }

        public int? ConnectedCourseId { get; set; }    // Self-referencing foreign key
        public Course ConnectedCourse { get; set; }    // Navigation property

        public string Objective { get; set; }
        public string Notes { get; set; }

        public int DepartmentId { get; set; }
    }
}
