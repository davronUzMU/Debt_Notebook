using Debt_Notebook.Exceptions;
using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.DTOs;
using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Model.DTOs.OrganizationDTO;
using Debt_Notebook.Model.DTOs.UserDTO;
using Debt_Notebook.Model.Enums;
using Debt_Notebook.Repositories.DebtRep;
using Debt_Notebook.Repositories.OrganizationRep;
using Debt_Notebook.Repositories.StateRep;
using Debt_Notebook.Repositories.UserRep;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IDebtRepository _debtRepository;
        private readonly IStateRepository _stateRepository;
        public UserService(IUserRepository userRepository,IOrganizationRepository organizationRepository,IDebtRepository debtRepository,IStateRepository stateRepository)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _debtRepository = debtRepository;
            _stateRepository = stateRepository;
        }

        public UserResponseDTO AddUser(UserRequestDTO user)
        {
            if (user == null) {
                throw new BadRequestException("User is empty");
            }
            if (string.IsNullOrWhiteSpace(user.FullName)) {
                throw new BadRequestException("User's fullName is empty");
            }
            if (string.IsNullOrWhiteSpace(user.Phone_nummer)) {
                throw new BadRequestException("User's Phone_nummer is empty");
            }
            if(user.Phone_nummer.Length != 9)
            {
                throw new ValidationException("information is involid", "Your phone_nummer is wrong");
            }
            if (user.OrganizationId == 0)
            {
                throw new BadRequestException("organization's id is involid");
            }
            if (_organizationRepository.GetOrganizationById(user.OrganizationId) == null) {
                throw new BadRequestException("Error");
            }
            if (_organizationRepository.GetOrganizationById(user.OrganizationId).State.IsActive==false)
            {
                throw new BadRequestException("Error");
            }
            List<Debt> debts = new List<Debt>();
            List<Debt> debts1=_debtRepository.GetDebtAll();
            foreach (Debt debt in debts1)
            {
                for (int i = 0; i < user.Debts.Count; i++) {
                    if (debt.Id == user.Debts[i])
                    {
                        debts.Add(debt);
                    }
                }
            }
            var state=new State { 
                Name = user.FullName+" User",
                IsActive=true
            };
            _stateRepository.AddState(state);
            var newUser = new User {
                FullName = user.FullName,
                Phone_nummer = user.Phone_nummer,
                OrganizationId = user.OrganizationId,
                organization=_organizationRepository.GetOrganizationById(user.OrganizationId),
                StateId=state.Id,
                UserState=state,
                Debts=debts,
                Role=Role.CLIENT,
                DateTime=DateTime.UtcNow
            };
            _userRepository.AddUser(newUser);
            
            return new UserResponseDTO(
                newUser
                );
        }

        public InformationDTO DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new NotFoundException("we haven't this user");
            }
            var state = _stateRepository.GetStateById(user.StateId);
            if (state.IsActive == false)
            {
                throw new BadRequestException("There isn't organization with this id");
            }
            state.IsActive = false;
            _stateRepository.EditState(state);
            return new InformationDTO("success");
        }

        public UserResponseDTO Edit(int id, UserRequestDTO user)
        {
            if (user == null) {
                throw new BadRequestException("user is involid");
            }
            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                throw new BadRequestException("User's fullName is empty");
            }
            if (string.IsNullOrWhiteSpace(user.Phone_nummer))
            {
                throw new BadRequestException("User's Phone_nummer is empty");
            }
            if (user.Phone_nummer.Length != 9)
            {
                throw new ValidationException("information is involid", "Your phone_nummer is wrong");
            }
            if (user.OrganizationId == 0)
            {
                throw new BadRequestException("organization's id is involid");
            }
            if (user.Debts == null)
            {
                throw new BadRequestException("user's dect in empty");
            }
            var userE=_userRepository.GetUserById(id);
            if (userE == null) {
                throw new NotFoundException("There isn't user");
            }
            List<Organization> organizations=_organizationRepository.GetOrganizationAll();
            foreach (var organization in organizations)
            {
                if (organization.Id != user.OrganizationId)
                {
                    throw new BadRequestException("User's Organization is involid");
                }
            }
            List<Debt> debts = new List<Debt>();
            List<Debt> debts1 = _debtRepository.GetDebtAll();
            foreach (Debt debt in debts1)
            {
                for (int i = 0; i <= user.Debts.Count; i++)
                {
                    if (debt.Id == user.Debts[i])
                    {
                        debts.Add(debt);
                    }
                }
            }
            userE.FullName = user.FullName;
            userE.Phone_nummer = user.Phone_nummer;
            userE.OrganizationId=user.OrganizationId;
            userE.organization=_organizationRepository.GetOrganizationById(user.OrganizationId);
            userE.Debts= debts;
            userE.DateTime = DateTime.UtcNow;
            _userRepository.EditUser(userE);

            return new UserResponseDTO(
                userE
                );

        }

        //public List<UserResponseDTO> GetUserAll()
        //{
        
        //    foreach (User user in users) {
        //        if (user.UserState.IsActive != false) {
        //            userResponseDTOs.Add(new UserResponseDTO(
        //                user
        //                ));
        //        }
        //    }
        //    return userResponseDTOs;
        //}

        public UserResponseDTO GetUserById(int id)
        {
            var user=_userRepository.GetUserById(id);
            if (user == null) {
                throw new NotFoundException("There isn't user");
            }
            if(user.UserState.IsActive == false)
            {
                throw new BadRequestException("There isn't user");
            }
            return new UserResponseDTO(
                user
                );
        }

        public List<UserResponseDTO> GetUserAll(UserFilterDTO userFilterDTO)
        {
            List<User> users = _userRepository.GetUserAll();
            List<UserResponseDTO> userResponseDTOs = new List<UserResponseDTO>();
            if (userFilterDTO == null) {
                users.ForEach(user => {

                });
            }
            throw new NotImplementedException();
        }
    }
}
