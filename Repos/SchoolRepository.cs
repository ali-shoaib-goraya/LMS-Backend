﻿using Dynamic_RBAMS.Data;
using Dynamic_RBAMS.Interfaces;
using Dynamic_RBAMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamic_RBAMS.Repos
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationDbContext _context;

        public SchoolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Add a new school and return model
        public async Task<School> AddAsync(School school)
        {
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        // ✅ Get school by ID and return model
        public async Task<School?> GetByIdAsync(int id)
        {
            return await _context.Schools
                .Where(s => !s.IsDeleted)
                .FirstOrDefaultAsync(s => s.SchoolId == id);
        }

        // ✅ Get all schools by campus
        public async Task<IEnumerable<School>> GetAllByCampusIdAsync(int campusId)
        {
            return await _context.Schools
                .Where(s => !s.IsDeleted && s.CampusId == campusId)
                .ToListAsync();
        }

        // ✅ Get school by name & campus ID
        public async Task<School?> GetByNameAsync(string schoolName)
        {
            return await _context.Schools
                .Where(s => !s.IsDeleted && s.SchoolName == schoolName)
                .FirstOrDefaultAsync();
        }

        // ✅ Update school details and return updated model
        public async Task<School?> UpdateAsync(School school)
        {
            _context.Schools.Update(school);
            await _context.SaveChangesAsync();
            return school;
        }

        // ✅ Hard delete school by ID
        public async Task<bool> DeleteAsync(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null) return false;

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Soft delete school by ID (with validation)
        public async Task<bool> SoftDeleteAsync(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null || school.IsDeleted) return false;

            school.IsDeleted = true;
            _context.Schools.Update(school);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
