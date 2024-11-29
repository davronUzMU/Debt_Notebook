using Debt_Notebook.Exceptions;
using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.DTOs;
using Debt_Notebook.Model.DTOs.DebtDTO;
using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Repositories.DebtRep;
using Debt_Notebook.Repositories.UserRep;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Services
{
    public class DebtService
    {
        private readonly IDebtRepository _debtRepository;

        private readonly IUserRepository _userRepository;
        public DebtService(IDebtRepository debtRepository, IUserRepository userRepository)
        {
            _debtRepository = debtRepository;
            _userRepository = userRepository;
        }
    
        public DebtResponseDTO AddDebt(DebtRequestDTO debtRequestDTO)
        {
            if(debtRequestDTO == null)
            {
                throw new BadRequestException("Debt is empty");
            }
            if(_userRepository.GetUserById(debtRequestDTO.UserId) == null)
            {
                throw new NotFoundException("information is wrong");
            }
            if (debtRequestDTO.Prise == 0)
            {
                throw new ValidationException("information is involid", "Your prise is wrong");
            }
            if (string.IsNullOrWhiteSpace(debtRequestDTO.Description)) {
                throw new BadRequestException("Debt's dicription is empty");
            }
            var user=_userRepository.GetUserById(debtRequestDTO.UserId);
            if (user.UserState.IsActive == false) {
                throw new BadRequestException("there isn't user");
            }
            var debt = new Debt
            {
                UserId = debtRequestDTO.UserId,
                User = user,
                Prise = debtRequestDTO.Prise,
                Description = debtRequestDTO.Description,
                CreateTime = DateTime.UtcNow
            };
            _debtRepository.AddDebt(debt);
            return new DebtResponseDTO(
                debt.Id,
                debt.UserId,
                debt.User,
                debt.Prise,
                debt.Description,
                debt.CreateTime
                );
        }

        public InformationDTO Delete(int id)
        {
            var debt=_debtRepository.GetDebtById(id);
            if (debt == null) {
                throw new BadRequestException("There isn't debt");
            }
            _debtRepository.Delete(id);
            return new InformationDTO("success");
        }
        public DebtResponseDTO GetDebtById(int id)
        {
            var debt=_debtRepository.GetDebtById(id);
            if (debt == null) {
                throw new BadRequestException("There isn't debt");
            }
            if(debt.User.UserState.IsActive == false)
            {
                throw new BadRequestException("There isn't debt");
            }
            return new DebtResponseDTO(debt.Id,
                debt.UserId,
                debt.User,
                debt.Prise,
                debt.Description,
                debt.CreateTime
                );
        }

        public DebtResponseDTO EditAddPrise(int id, DebtRequestDTO debtRequestDTO)
        {
            if(_debtRepository.GetDebtById(id) == null)
            {
                throw new NotFoundException("There isn't debt");
            }
            if (debtRequestDTO == null)
            {
                throw new BadRequestException("Debt is empty");
            }
            if (_userRepository.GetUserById(debtRequestDTO.UserId) == null)
            {
                throw new NotFoundException("information is wrong");
            }
            if (debtRequestDTO.Prise == 0)
            {
                throw new ValidationException("information is involid", "Your prise is wrong");
            }
            if (string.IsNullOrWhiteSpace(debtRequestDTO.Description))
            {
                throw new BadRequestException("Debt's dicription is empty");
            }
            var user = _userRepository.GetUserById(debtRequestDTO.UserId);
            if (user.UserState.IsActive == false)
            {
                throw new BadRequestException("there isn't user");
            }
            var debt=_debtRepository.GetDebtById(id);
            debt.Prise = debt.Prise + debtRequestDTO.Prise;
            debt.CreateTime = DateTime.UtcNow;
            _debtRepository.Edit(debt);
            return new DebtResponseDTO(debt.Id,
                debt.UserId,
                debt.User,
                debt.Prise,
                debt.Description,
                debt.CreateTime
                );

        }

        public DebtResponseDTO EditSubPrise(int id, DebtRequestDTO debtRequestDTO)
        {
            if (_debtRepository.GetDebtById(id) == null)
            {
                throw new NotFoundException("There isn't debt");
            }
            if (debtRequestDTO == null)
            {
                throw new BadRequestException("Debt is empty");
            }
            if (_userRepository.GetUserById(debtRequestDTO.UserId) == null)
            {
                throw new NotFoundException("information is wrong");
            }
            if (debtRequestDTO.Prise == 0)
            {
                throw new ValidationException("information is involid", "Your prise is wrong");
            }
            if (debtRequestDTO.Description == null)
            {
                throw new BadRequestException("Debt's dicription is empty");
            }
            var user = _userRepository.GetUserById(debtRequestDTO.UserId);
            if (user.UserState.IsActive == false)
            {
                throw new BadRequestException("there isn't user");
            }
            var debt = _debtRepository.GetDebtById(id);
            if (debt.Prise < debtRequestDTO.Prise)
            {
                throw new ValidationException("information is involid", "There is prise's wrong");
            }
            debt.Prise = debt.Prise - debtRequestDTO.Prise;
            debt.CreateTime = DateTime.UtcNow;
            _debtRepository.Edit(debt);
            return new DebtResponseDTO(debt.Id,
                debt.UserId,
                debt.User,
                debt.Prise,
                debt.Description,
                debt.CreateTime
                );
        }

        public List<DebtResponseDTO> GetDebtAll(DebtFilterDTO debtFilterDTO)
        {
            List<Debt> debts = _debtRepository.GetDebtAll();
            List<DebtResponseDTO> debts_ = new List<DebtResponseDTO>();

            if (debtFilterDTO == null) {
                debts.ForEach(debt => {
                    var user = _userRepository.GetUserById(debt.UserId);
                    if (user.UserState.IsActive)
                    {
                        debts_.Add(new DebtResponseDTO(
                            debt.Id,
                            debt.UserId, debt.User,
                            debt.Prise,
                            debt.Description,
                            debt.CreateTime
                            ));
                    }
                });
            }
            return debts_;
        }
    }
}
