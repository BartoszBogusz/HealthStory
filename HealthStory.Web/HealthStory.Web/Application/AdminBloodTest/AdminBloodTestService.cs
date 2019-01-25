﻿using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.BloodTest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.AdminBloodTest
{
    public interface IAdminBloodTestService
    {
        void Create(CreateBloodTestViewModel bloodTest);
        List<BloodTestInfoDto> Get();
        BloodTestInfoDto Get(int bloodTestId);
        void Update(BloodTestInfoDto bloodTest);
        void Delete(int bloodTestId);
    }

    public class AdminBloodTestService : IAdminBloodTestService
    {
        private readonly HealthStoryContext _context;

        public AdminBloodTestService(HealthStoryContext context)
        {
            _context = context;
        }

        public void Create(CreateBloodTestViewModel bloodTest)
        {
            var newBloodTest = new BloodTestInfo
            {
                Name = bloodTest.Name,
                Description = bloodTest.Description
            };
            _context.BloodTestsInfo.Add(newBloodTest);

            foreach (var substance in bloodTest.Substances)
            {
                _context.BloodTestsSubstancesInfo.Add(new BloodTestSubstanceInfo
                {
                    BloodTestInfoId = newBloodTest.BloodTestInfoId,
                    SubstanceInfoId = substance.SubstanceInfoId
                });
            }

            _context.SaveChanges();
        }

        public List<BloodTestInfoDto> Get()
        {
            var list = _context.BloodTestsInfo
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
            var list = _context.BloodTestsInfo
                 .Where(x => x.BloodTestInfoId == bloodTestId)
                 .Select(x => new BloodTestInfoDto
                 {
                     BloodTestId = x.BloodTestInfoId,
                     Name = x.Name,
                     Description = x.Description
                 }).First();
            return list;
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

            _context.SaveChanges();
        }

        public void Delete(int bloodTestId)
        {
            var bloodTest = _context.BloodTestsInfo
                .Where(x => x.BloodTestInfoId == bloodTestId).First();

            _context.Remove(bloodTest);
            _context.SaveChanges();
        }
    }
}
