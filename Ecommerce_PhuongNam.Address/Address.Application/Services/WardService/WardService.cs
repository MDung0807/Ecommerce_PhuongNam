using AutoMapper;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Ward;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Ward;
using Ecommerce_PhuongNam.Address.Address.Application.Specification;
using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;
using Ecommerce_PhuongNam.Common.Utils.Enums;

namespace Ecommerce_PhuongNam.Address.Address.Application.Services.WardService;

public class WardService : IWardService
{
    #region -- Properties --

    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Ward, int> _repository;
    private readonly IMapper _mapper;
    #endregion -- Properties --

    #region -- Public method --

    public WardService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GenericRepository<Ward, int>();
        _mapper = mapper;
    }
    public async Task<WardResponse> GetById(int id)
    {
        Ward ward = await WardGet(id);
        return _mapper.Map<WardResponse>(ward);
    }

    public Task<List<WardResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(WardUpdate entity, int id, int userId)
    {
        Ward ward = _mapper.Map<Ward>(entity);
        await _repository.Update(ward);
        return true;
    }

    public async Task<bool> Delete(int id, int userId)
    {
        WardSpecification wardSpecification = new WardSpecification(id);
        Ward ward = await _repository.Get(wardSpecification, checkStatus: false);
        ward = ChangeStatus(ward, (int)EnumsApp.Delete);
        await _repository.Update(ward);
        return true;
    }

    public async Task<bool> Create(WardCreate entity, int userId)
    {
        Ward ward = _mapper.Map<Ward>(entity);
        await _repository.Create(ward);
        return true;
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

    public Task<object> GetAllByAdmin(object pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAll(object pagingRequest)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetAll(object pagingRequest, int idMaster)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteHard(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<WardResponse>> GetAllByAdmin()
    {
        throw new NotImplementedException();
    }

    public async Task<Ward> WardGet(int id)
    {
        WardSpecification wardSpecification = new WardSpecification(id);
        Ward ward = await _repository.Get(wardSpecification);
        return ward;
    }

    #endregion -- Public method --

    #region -- Private Method --

    private Ward ChangeStatus(Ward entity, int status)
    {
        entity.Status = status;
        return entity;
    }
    #endregion -- Private Method --
}