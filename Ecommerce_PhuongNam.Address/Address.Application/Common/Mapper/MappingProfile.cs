﻿using AutoMapper;
using BusBookTicket.AddressManagement.DTOs.Responses;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.District;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Province;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Region;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Unit;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Ward;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.District;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Province;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Region;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Unit;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Ward;
using Ecommerce_PhuongNam.Address.Address.Domain.Entities;

namespace Ecommerce_PhuongNam.Address.Address.Application.Common.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region -- Address Module --

        CreateMap<RegionCreate, AdministrativeRegion>();
        CreateMap<RegionUpdate, AdministrativeRegion>();
        CreateMap<AdministrativeRegion, RegionResponse>();

        CreateMap<UnitCreate, AdministrativeUnit>();
        CreateMap<UnitUpdate, AdministrativeUnit>();
        CreateMap<AdministrativeUnit, UnitResponse>();

        CreateMap<ProvinceCreate, Province>();
        CreateMap<ProvinceUpdate, Province>();
        CreateMap<Province, ProvinceResponse>();

        CreateMap<DistrictCreate, District>();
        CreateMap<DistrictUpdate, District>();
        CreateMap<District, DistrictResponse>();

        CreateMap<WardCreate, Ward>();
        CreateMap<WardUpdate, Ward>();
        CreateMap<Ward, WardResponse>()
            .ForPath(dest => dest.District,
                opts => opts.MapFrom(x => x.District.FullName))
            .ForPath(dest => dest.DistrictId,
                opts => opts.MapFrom(x => x.District.Id))
            .ForPath(dest => dest.Province,
                opts => opts.MapFrom(x => x.District.Province.FullName))
            .ForPath(dest => dest.ProvinceId,
                opts => opts.MapFrom(x => x.District.Province.Id));

        CreateMap<WardResponse, AddressResponse>()
            .ForPath(dest => dest.WardId,
                opts => opts.MapFrom(x => x.Id))
            .ForPath(dest => dest.FullNameWard,
                opts => opts.MapFrom(x => x.FullName))
            .ForPath(dest => dest.DistrictId,
                opts => opts.MapFrom(x => x.DistrictId))
            .ForPath(dest => dest.FullNameDistrict,
                opts => opts.MapFrom(x => x.District))
            .ForPath(dest => dest.ProvinceId,
                opts => opts.MapFrom(x => x.ProvinceId))
            .ForPath(dest => dest.FullNameProvince,
                opts => opts.MapFrom(x => x.Province))
            ;
        #endregion -- Address Module --
    }
}