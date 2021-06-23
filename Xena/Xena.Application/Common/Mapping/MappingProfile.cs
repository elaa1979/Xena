using AutoMapper;
using Xena.Application.Commands.Users.Register;
using Xena.Application.Commands.Users.UpdateUser;
using Xena.Domain.Users;
using Xena.Application.Queries.Users;
using Xena.Domain.Roles;
using Xena.Application.Queries.Roles;
using System;
using Xena.Application.Common.Models;
using Xena.Domain.Logs;
using Xena.Application.Queries.Logs;
using System.Linq;
using System.Text.Json;


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

          
        }
    }
}