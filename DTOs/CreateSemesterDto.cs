﻿namespace Dynamic_RBAMS.DTOs
{
    public class CreateSemesterDto
    {
        public string SemesterName { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string Notes { get; set; }

    }
}
