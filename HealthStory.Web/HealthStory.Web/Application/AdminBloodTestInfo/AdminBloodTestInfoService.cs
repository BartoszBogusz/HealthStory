using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.BloodTestInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.AdminBloodTestInfo
{
    public interface IAdminBloodTestInfoService
    {
        Task CreateAsync(CreateBloodTestInfoViewModel bloodTest);
        Task<List<ReadBloodTestInfoViewModel>> GetAsync();
        Task<BloodTestInfoDto> GetAsync(int bloodTestId);
        Task UpdateAsync(BloodTestInfoDto bloodTest);
        Task DeleteAsync(int bloodTestId);
    }

    public class AdminBloodTestInfoService : IAdminBloodTestInfoService
    {
        private readonly HealthStoryContext _context;

        public AdminBloodTestInfoService(HealthStoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateBloodTestInfoViewModel bloodTest)
        {
            var newBloodTest = new BloodTestInfo
            {
                Name = bloodTest.Name,
                Description = bloodTest.Description,
                BloodTestsSubstancesInfo = bloodTest.Substances
                .Select(x => new BloodTestSubstanceInfo
                {
                    SubstanceInfoId = x.SubstanceInfoId
                }).ToList()
            };
            await _context.BloodTestsInfo.AddAsync(newBloodTest);
            await _context.SaveChangesAsync();
        }

        public Task<List<ReadBloodTestInfoViewModel>> GetAsync()
        {
            var list = _context.BloodTestsInfo
                .Where(x => !x.IsDeleted)
                .Select(x => new ReadBloodTestInfoViewModel
                {
                    BloodTestInfoId = x.BloodTestInfoId,
                    Name = x.Name,
                    Description = x.Description,
                    NumberOfSubstances = x.BloodTestsSubstancesInfo.Where(s => !s.IsDeleted).Count()
                }).ToListAsync();
            return list;
        }

        public Task<BloodTestInfoDto> GetAsync(int bloodTestId)
        {
            var item = _context.BloodTestsInfo
                 .Where(x => x.BloodTestInfoId == bloodTestId && !x.IsDeleted)
                 .Select(x => new BloodTestInfoDto
                 {
                     BloodTestId = x.BloodTestInfoId,
                     Name = x.Name,
                     Description = x.Description
                 }).FirstAsync();
            return item;
        }

        public async Task UpdateAsync(BloodTestInfoDto bloodTest)
        {
            var dbBloodTest = _context.BloodTestsInfo
                .First(x => x.BloodTestInfoId == bloodTest.BloodTestId);

            dbBloodTest.Name = bloodTest.Name;
            dbBloodTest.Description = bloodTest.Description;

            var substancesInDb = _context.BloodTestsSubstancesInfo   
                .Where(x => x.BloodTestInfoId == bloodTest.BloodTestId)
                .Select(x => x.SubstanceInfoId)
                .ToList();

            var newSubstances = bloodTest.Substances.Select(x => x.SubstanceInfoId).ToList();

            var toAdd = newSubstances.Except(substancesInDb)
                .Select(x => new BloodTestSubstanceInfo
            {
                BloodTestInfoId = bloodTest.BloodTestId,
                SubstanceInfoId = x
            }).ToList();

            await _context.BloodTestsSubstancesInfo.AddRangeAsync(toAdd);

            var toRemoveIds = substancesInDb.Except(newSubstances);

            var toRemove = _context.BloodTestsSubstancesInfo
                .Where(x => toRemoveIds.Contains(x.SubstanceInfoId) && x.BloodTestInfoId == bloodTest.BloodTestId)
                .ToList();

            _context.BloodTestsSubstancesInfo.RemoveRange(toRemove);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int bloodTestId)
        {
            var bloodTest = _context.BloodTestsInfo
                .Where(x => x.BloodTestInfoId == bloodTestId).First();

            bloodTest.IsDeleted = true;

            await _context.SaveChangesAsync();
        }
    }
}
