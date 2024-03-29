﻿using AutoMapper;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.District;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.District;
using Ecommerce_PhuongNam.Address.Address.Application.Specification;
using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Common.Paging;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;

namespace Ecommerce_PhuongNam.Address.Address.Application.Services.DistrictService;

public class DistrictService : IDistrictService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<District, int> _repository;
    private readonly IMapper _mapper;
    #endregion -- Properties --

    public DistrictService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _repository = unitOfWork.GenericRepository<District, int>();
    }

    #region -- Public Method --
    public async Task<DistrictResponse> GetById(int id)
    {
        DistrictSpecification districtSpecification = new DistrictSpecification(id);
        District district = await _repository.Get(districtSpecification, checkStatus: false);
        DistrictResponse response = new DistrictResponse();

        response = _mapper.Map<DistrictResponse>(district);
        return response;
    }

    public Task<List<DistrictResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(DistrictUpdate entity, int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(DistrictCreate entity, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsActive(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeIsLock(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToWaiting(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeToDisable(int id, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckToExistByParam(string param)
    {
        throw new NotImplementedException();
    }

    public Task<PagingResult<DistrictResponse>> GetAllByAdmin(PagingRequest pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<PagingResult<DistrictResponse>> GetAll(PagingRequest pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<PagingResult<DistrictResponse>> GetAll(PagingRequest pagingRequest, int idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<DistrictResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    #endregion -- Public Method --

    public Task<List<DistrictResponse>> GetDistrictByUnit(int provinceId)
    {
        throw new NotImplementedException();
    }
}