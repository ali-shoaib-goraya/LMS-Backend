﻿namespace Dynamic_RBAMS.Features.BatchManagment
{
    public class CreateBatchDto
    {
        public string BatchName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public int ProgramId { get; set; }
    }
}
