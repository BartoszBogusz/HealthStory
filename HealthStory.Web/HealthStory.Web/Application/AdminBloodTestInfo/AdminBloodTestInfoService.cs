using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.BloodTestInfo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.AdminBloodTestInfo
{
    public interface IAdminBloodTestInfoService
    {
        void Create(CreateBloodTestInfoViewModel bloodTest);
        List<BloodTestInfoDto> Get();
        BloodTestInfoDto Get(int bloodTestId);
        void Update(BloodTestInfoDto bloodTest);
        void Delete(int bloodTestId);
    }

    public class AdminBloodTestInfoService : IAdminBloodTestInfoService
    {
        private readonly HealthStoryContext _context;

        public AdminBloodTestInfoService(HealthStoryContext context)
        {
            _context = context;
        }

        public void Create(CreateBloodTestInfoViewModel bloodTest)
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
            _context.BloodTestsInfo.Add(newBloodTest);

            _context.SaveChanges();
        }

        public List<BloodTestInfoDto> Get()
        {
            var list = _context.BloodTestsInfo
                .Where(x => !x.IsDeleted)
                .Select(x => new BloodTestInfoDto
                {
                    BloodTestId = x.BloodTestInfoId,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
            return list;
        }

        public BloodTestInfoDto Get(int bloodTestId)
        {
            var item = _context.BloodTestsInfo
                 .Where(x => x.BloodTestInfoId == bloodTestId)
                 .Select(x => new BloodTestInfoDto
                 {
                     BloodTestId = x.BloodTestInfoId,
                     Name = x.Name,
                     Description = x.Description
                 }).First();
            return item;
        }

        public void Update(BloodTestInfoDto bloodTest)
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

            _context.BloodTestsSubstancesInfo.AddRange(toAdd);

            var toRemoveIds = substancesInDb.Except(newSubstances);

            var toRemove = _context.BloodTestsSubstancesInfo
                .Where(x => toRemoveIds.Contains(x.SubstanceInfoId) && x.BloodTestInfoId == bloodTest.BloodTestId)
                .ToList();

            _context.BloodTestsSubstancesInfo.RemoveRange(toRemove);
            _context.SaveChanges();
        }

        public void Delete(int bloodTestId)
        {
            var bloodTest = _context.BloodTestsInfo
                .Where(x => x.BloodTestInfoId == bloodTestId).First();

            bloodTest.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
