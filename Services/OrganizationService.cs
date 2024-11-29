using Debt_Notebook.Exceptions;
using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.DTOs;
using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Model.DTOs.OrganizationDTO;
using Debt_Notebook.Model.DTOs.StateDTO;
using Debt_Notebook.Repositories.OrganizationRep;
using Debt_Notebook.Repositories.StateRep;
using Debt_Notebook.Repositories.UserRep;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Services
{
    public class OrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        private readonly IStateRepository _stateRepository;

        private readonly IUserRepository _userRepository;

        public OrganizationService(IOrganizationRepository organizationRepository,IStateRepository stateRepository,IUserRepository userRepository)
        {
            _organizationRepository = organizationRepository;
            _stateRepository = stateRepository;
            _userRepository = userRepository;
            
        }
        public InformationDTO DeleteOrganization(int id)
        {
            var organization=_organizationRepository.GetOrganizationById(id);
            if (organization == null) { 
                throw new NotFoundException("we haven't this organization");
            }
            var state=_stateRepository.GetStateById(organization.StateId);
            if (state.IsActive == false)
            {
                throw new BadRequestException("There isn't organization with this id");
            }
            state.IsActive = false;
            _stateRepository.EditState(state);
            return new InformationDTO("success");
        }

        //public OrganizationResponseDTO Edit(int id, OrganizationRequestDTO organizationRequestDTO)
        //{
        //   var organization= _organizationRepository.GetOrganizationById(id);
        //    if (organization == null) {
        //        throw new NotFoundException("Organization is involid");
        //    }
        //    if (string.IsNullOrWhiteSpace(organizationRequestDTO.Name))
        //    {
        //        throw new BadRequestException("Organization's name is empty");
        //    }
        //    if (string.IsNullOrWhiteSpace(organizationRequestDTO.Description))
        //    {
        //        throw new BadRequestException("Organization's discription is empty");
        //    }
        //    if (string.IsNullOrWhiteSpace(organizationRequestDTO.Phone_nummer))
        //    {
        //        throw new BadRequestException("Organization's phone_mummer is empty");
        //    }
        //    if (organizationRequestDTO.Phone_nummer.Length != 9)
        //    {
        //        throw new ValidationException("information is involid", "Your phone_nummer is wrong");
        //    }
        //    if (organization.State.IsActive == false) {
        //        throw new BadRequestException("There isn't organization with this id");
        //    }
        //    organization.Name = organizationRequestDTO.Name;
        //    organization.Description = organizationRequestDTO.Description;
        //    organization.Phone_nummer = organizationRequestDTO.Phone_nummer;
        //    organization.CreateTime= DateTime.UtcNow;

        //    _organizationRepository.EditOrganization(organization);

        //    return new OrganizationResponseDTO(organization.Id,
        //        organization.Name,
        //        organization.Description,
        //        organization.Phone_nummer,
        //        organization.StateId,
        //        organization.State,
        //        organization.Customers,
        //        organization.CreateTime
        //        );
        //}
        public OrganizationResponseDTO GetOrganizationById(int id)
        {
            var organization= _organizationRepository.GetOrganizationById(id);
            if (organization == null) {
                throw new NotFoundException("Organization is empty");
            }
            if (organization.State.IsActive == false) {
                throw new BadRequestException("There isn't organization");
            }
            return new OrganizationResponseDTO(
                organization.Id, 
                organization.Name,
                organization.Description,
                organization.Phone_nummer,
                organization.StateId,
                organization.State,
                organization.Customers,
                organization.CreateTime
                );
        }

        public OrganizationAddOrEditResponseDTO AddOrganization(OrganizationAddOrEditRequestDTO organizationAddOrEditRequestDTO)
        {
            if (organizationAddOrEditRequestDTO == null)
            {
                throw new BadRequestException("Organization is empty");
            }
            if (string.IsNullOrWhiteSpace(organizationAddOrEditRequestDTO.Name))
            {
                throw new BadRequestException("Organization's name is empty");
            }
            if (string.IsNullOrWhiteSpace(organizationAddOrEditRequestDTO.Description))
            {
                throw new BadRequestException("Organization's discription is empty");
            }
            if (string.IsNullOrWhiteSpace(organizationAddOrEditRequestDTO.Phone_nummer))
            {
                throw new BadRequestException("Organization's phone_mummer is empty");
            }
            if (organizationAddOrEditRequestDTO.Phone_nummer.Length != 9)
            {
                throw new ValidationException("information is involid", "Your phone_nummer is wrong");
            }

            var state = new State
            {
                Name = organizationAddOrEditRequestDTO.Name + " new Organization",
                IsActive = true
            };
            _stateRepository.AddState(state);
            List<User> users = new List<User>();
            var organization = new Organization
            {
                Name = organizationAddOrEditRequestDTO.Name,
                Description = organizationAddOrEditRequestDTO.Description,
                Phone_nummer = organizationAddOrEditRequestDTO.Phone_nummer,
                StateId = state.Id,
                State = state,
                Customers = users,
                CreateTime = DateTime.UtcNow,
            };
            _organizationRepository.AddOrganization(organization);

            return new OrganizationAddOrEditResponseDTO(organization.Id,
                organization.Name,
                organization.Description,
                organization.Phone_nummer,
                organization.StateId,
                organization.State,
                organization.CreateTime
                );
        }

        public OrganizationAddOrEditResponseDTO Edit(int id, OrganizationAddOrEditRequestDTO organizationAddOrEditRequestDTO)
        {
            throw new NotImplementedException();
        }

        public List<OrganizationResponseDTO> GetOrganizationAll(OrganizationFilterDTO organizationFilterDTO)
        {
            List<Organization> organizations = _organizationRepository.GetOrganizationAll();
            List<OrganizationResponseDTO> organizationResponseDTOs = new List<OrganizationResponseDTO>();
            List<Organization> organizations1=new List<Organization>();
            if (organizationFilterDTO == null) {
                foreach (Organization organization in organizations)
                {
                    if (organization.State.IsActive != false)
                    {
                        organizationResponseDTOs.Add(new OrganizationResponseDTO(organization.Id,
                            organization.Name,
                            organization.Description,
                            organization.Phone_nummer,
                            organization.StateId,
                            organization.State,
                            organization.Customers,
                            organization.CreateTime));
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(organizationFilterDTO.Name)) { 
                    organizations1=organizations.Where(p=>p.Name.Contains(organizationFilterDTO.Name)
                    && p.State.IsActive==true).ToList();
                }
                if (String.IsNullOrEmpty(organizationFilterDTO.Phone_nummer))
                {
                   organizations1=organizations.Where(p=>p.Phone_nummer.Contains(organizationFilterDTO.Phone_nummer)
                   && p.State.IsActive==true).ToList();
                }
                foreach (Organization organization in organizations1)
                {
                    organizationResponseDTOs.Add(new OrganizationResponseDTO(organization.Id,
                            organization.Name,
                            organization.Description,
                            organization.Phone_nummer,
                            organization.StateId,
                            organization.State,
                            organization.Customers,
                            organization.CreateTime));
                }
            }
            return organizationResponseDTOs;
        }
    }
}
