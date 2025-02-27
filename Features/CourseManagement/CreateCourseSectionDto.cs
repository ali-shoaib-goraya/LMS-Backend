﻿namespace Dynamic_RBAMS.Features.CourseManagement
{
    public class CreateCourseSectionDto
    {
        public string CourseSectionName { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }

        public int SectionId { get; set; }

        public string FacultyId { get; set; }

        public int SemesterId { get; set; }

        public int CourseId { get; set; }
    }
}
