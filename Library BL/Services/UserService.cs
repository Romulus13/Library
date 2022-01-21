using AutoMapper;
using Library_BL.Exceptions;
using Library_BL.Interfaces;
using Library_BL.Model;
using Library_DAL.Interfaces;
using Library_DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace Library_BL.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContactService _userContactService;
        private readonly IMapper _autoMapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IUserContactService userContactService,
            IMapper autoMapper)

        {
            _unitOfWork = unitOfWork;
            _userContactService = userContactService;
            _autoMapper = autoMapper;
        }

        public async Task<UserModel> Create(UserModel model)
        {
            try
            {

                if (model == null || string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName))
                {
                    throw new MissingEntityInfoException($" {nameof(model)} is missing required information when creating a user");
                }
                User? user = await _unitOfWork.Users.Get().Where(usr => usr.FirstName == model.FirstName && usr.LastName == model.LastName && usr.BirthDate == model.BirthDate).FirstOrDefaultAsync();

                if (user == null)
                {

                    user = _autoMapper.Map(model, user);
                }
                else
                {
                    throw new EntityAlreadyExistsException();
                }
                if (user != null)
                {

                    await _unitOfWork.Users.Add(user);
                    await _unitOfWork.SaveAsync();
                    model.Id = user.Id;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return model;
        }

        public async Task Delete(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get().Where(usr => usr.Id == id).FirstOrDefaultAsync();
                if (user is null)
                {
                    throw new EntityNotFoundException();
                }
                _unitOfWork.Users.Delete(user);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserModel> Get(int id)
        {
            var user = await _unitOfWork.Users.Get().Where(usr => usr.Id == id).FirstOrDefaultAsync();
            return _autoMapper.Map<UserModel>(user);

        }

        public async Task<List<UserModel>> GetAll()
        {
            var users = await _unitOfWork.Users.Get().ToListAsync();
            List<UserModel> userModels = users.Select(user => _autoMapper.Map<UserModel>(user)).ToList();
            return userModels;
        }

        public async Task<UserModel> Update(UserModel model)
        {
            try
            {
                if (model == null || model.Id <= 0)
                {
                    throw new MissingEntityInfoException($" {nameof(model).ToString()} is missing required information when updating a user");
                }
                var user = await _unitOfWork.Users.Get().Where(usr => usr.Id == model.Id).FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new EntityNotFoundException();

                }
                else
                {
                    user = _autoMapper.Map(model, user);
                }

                if (user != null)
                {
                   
                        _unitOfWork.Users.Update(user);

                        await _unitOfWork.SaveAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return model;
        }
    }
}
