﻿using AutoMapper;
using PM.Model.Common;
using PM.Web.Areas.Administration.Models;
using PM.Web.Identity;
using System;

namespace PM.Web
{
    /// <summary>
    /// Automapper profile for model classes.
    /// </summary>
    public class MapperProfile : Profile
    {
        [Obsolete]
        protected override void Configure()
        {
            #region Identity models

            CreateMap<Model.Common.IUser, IdentityUser>()
                .ForMember(v => v.Id, opt => opt.MapFrom(d => d.UserId))
                .ReverseMap()
                .ForMember(d => d.UserId, opt => opt.MapFrom(v => v.Id));

            CreateMap<Model.Common.IRole, IdentityRole>()
                .ForMember(v => v.Id, opt => opt.MapFrom(d => d.RoleId))
                .ReverseMap()
                .ForMember(d => d.RoleId, opt => opt.MapFrom(v => v.Id));

            #endregion Identity models

            #region Project models

            CreateMap<IProject, CreateProjectViewModel>().ReverseMap();
            CreateMap<IProject, ProjectViewModel>().ReverseMap();

            #endregion Project models
        }
    }
}