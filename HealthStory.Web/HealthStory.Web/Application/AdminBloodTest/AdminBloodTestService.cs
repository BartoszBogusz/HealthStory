using HealthStory.Web.Entities;
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
        List<BloodTestDto> Get();
        BloodTestDto Get(int bloodTestId);
        void Update(BloodTestDto bloodTest);
        void Delete(int bloodTestId);
        BloodTestDto GetForEdition(int bloodTestId);
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
            var newBloodTest = new BloodTest
            {
                //nie mam pojecia co tutaj wpisac, bo zadne properites z tabeli w bazie danych nie maja pokrycia w modelu CreateBloodTestViewModel
            };
            _context.BloodTests.Add(newBloodTest);
            _context.SaveChanges();
        }

        public List<BloodTestDto> Get()
        {
            var list = _context.BloodTests
                .Select(x => new BloodTestDto
                {
                    BloodTestId = x.BloodTestId,
                    Date = x.Date,
                    AppUser = x.AppUser.Login,             
                }).ToList();
            return list;
        }

        public BloodTestDto Get(int bloodTestId)
        {
            var list = _context.BloodTests
                 .Where(x => x.BloodTestId == bloodTestId)
                 .Select(x => new BloodTestDto
                 {
                     BloodTestId = x.BloodTestId,
                     Date = x.Date,
                     AppUser = x.AppUser.Login,
                 }).First();
            return list;
        }

        public BloodTestDto GetForEdition(int bloodTestId)
        {
            var bloodTest = _context.BloodTests
                .Where(x => x.BloodTestId == bloodTestId)                                           
                .Select(x => new BloodTestDto

                {
                    Date = x.Date,
                    AppUser = x.AppUser.Login,
                }).First();
            return bloodTest;
        }

        public void Update(BloodTestDto bloodTest)
        {
            var bloodTestQuery = _context.BloodTests
                .First(x => x.BloodTestId == bloodTest.BloodTestId);

            bloodTestQuery.Date = bloodTest.Date;
            bloodTestQuery.AppUser.Login = bloodTest.AppUser;

            _context.SaveChanges();
        }

        public void Delete(int bloodTestId)
        {
            var bloodTest = _context.BloodTests
                .Where(x => x.BloodTestId == bloodTestId).First();

            _context.Remove(bloodTest);
            _context.SaveChanges();
        }
    }
}
