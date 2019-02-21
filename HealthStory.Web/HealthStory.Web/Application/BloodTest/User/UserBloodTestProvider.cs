using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.BloodTest.User
{
    public interface IUserBloodTestProvider
    {
        Task<UserBloodTestDto> Get(int bloodTestInfoId);
    }
    public class UserBloodTestProvider : IUserBloodTestProvider
    {
        public Task<UserBloodTestDto> Get(int bloodTestInfoId)
        {
            throw new NotImplementedException(); // TODO BB Implement this method
        }
    }
}
