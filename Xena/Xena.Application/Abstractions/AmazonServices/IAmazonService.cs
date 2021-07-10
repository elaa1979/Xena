using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xena.Application.Abstractions.AmazonServices
{
    public interface IAmazonService
    {
        Task<string> GetProfilesAsync(int userId);
        Task<string> GetAdGroupsAsync(int userId, long profileId);
        Task<string> GetCampaignsAsync(int userId, long profileId);
        Task<string> GetKeywordsAsync(int userId, long profileId);
    }
}
