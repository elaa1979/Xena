using AutoMapper;
using Xena.Application.Commands.Users.Register;
using Xena.Application.Commands.Users.UpdateUser;
using Xena.Application.Commands.Amazon.Profiles.CreateProfile;
using Xena.Application.Commands.Amazon.Profiles.UpdateProfile;
using Xena.Application.Commands.Amazon.AdGroups.CreateAdGroup;
using Xena.Application.Commands.Amazon.AdGroups.UpdateAdGroup;
using Xena.Application.Commands.Amazon.Keywords.CreateKeyword;
using Xena.Application.Commands.Amazon.Keywords.UpdateKeyword;
using Xena.Application.Commands.Amazon.Campaigns.CreateCampaign;
using Xena.Application.Commands.Amazon.Campaigns.UpdateCampaign;
using Xena.Application.Common.Models;
using Xena.Application.Queries.Users;
using Xena.Application.Queries.Roles;
using Xena.Application.Queries.Logs;
using Xena.Application.Queries.Amazon.Profiles;
using Xena.Application.Queries.Amazon.AdGroups;
using Xena.Application.Queries.Amazon.Keywords;
using Xena.Application.Queries.Amazon.Campaigns;
using Xena.Domain.Amazon;
using Xena.Domain.Users;
using Xena.Domain.Roles;
using Xena.Domain.Logs;

using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;


namespace Xena.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDto>();


            CreateMap<Role, RoleDto>()
                .ForMember(x => x.Permissions, a => a.MapFrom(s => s.Persmissions));

            CreateMap<RolePermission, PermissionDto>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.Permission.Id))
                .ForMember(x => x.Title, a => a.MapFrom(s => s.Permission.Title));


            CreateMap<Log, LogDto>();

            CreateMap(typeof(BaseResult<>), typeof(BaseResult<>));

            

            CreateMap<CreateProfileCommand, AmazonProfile>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<UpdateProfileCommand, AmazonProfile>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<ProfileDto, AmazonProfile>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<CreateAdGroupCommand, AmazonAdGroup>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.adGroupId))
                .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<UpdateAdGroupCommand, AmazonAdGroup>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.adGroupId))
                .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<AdGroupDto, AmazonAdGroup>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.adGroupId))
                .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<CreateKeywordCommand, AmazonAdGroup>()
               .ForMember(x => x.Id, a => a.MapFrom(s => s.keywordId))
               .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
               .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
               .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
               .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<UpdateKeywordCommand, AmazonKeyword>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.keywordId))
                .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<KeywordDto, AmazonKeyword>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.keywordId))
                .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<CreateCampaignCommand, AmazonCampaign>()
               .ForMember(x => x.Id, a => a.MapFrom(s => s.campaignId))
               .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
               .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
               .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
               .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<UpdateCampaignCommand, AmazonCampaign>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.campaignId))
                .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));

            CreateMap<CampaignDto, AmazonCampaign>()
                .ForMember(x => x.Id, a => a.MapFrom(s => s.campaignId))
                .ForMember(x => x.profileId, a => a.MapFrom(s => s.profileId))
                .ForMember(x => x.IsDeleted, a => a.MapFrom(s => false))
                .ForMember(x => x.LastSyncDate, a => a.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Data, a => a.MapFrom(s => JsonSerializer.Serialize(s, null)));


        }
    }
}