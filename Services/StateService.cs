using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Model.DTOs.OrganizationDTO;
using Debt_Notebook.Model.DTOs.StateDTO;
using Debt_Notebook.Repositories.StateRep;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Services
{
    public class StateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository) { 
            _stateRepository = stateRepository;
        }
        public StateResponseDTO GetStateById(int id)
        {
            var state= _stateRepository.GetStateById(id);
            return new StateResponseDTO(state.Id,
                                        state.Name, 
                                        state.IsActive);
        }

        public List<StateResponseDTO> GetStateAll(StateFilterDTO stateFilterDTO)
        {
            List<State> states = _stateRepository.GetStateAll();
            List<State> states1 = new List<State>();
            List<StateResponseDTO> stateResponseDTOs = new List<StateResponseDTO>();
            if (stateFilterDTO == null)
            {
                foreach (var state in states)
                {
                    stateResponseDTOs.Add(new StateResponseDTO(
                        state.Id,
                        state.Name,
                        state.IsActive
                        ));
                }
            }
            else {
                if (stateFilterDTO.IsActive == true)
                {
                    states1=states.Where(p=>p.IsActive==true).ToList();
                }
                else
                {
                    states1=states.Where(p=>p.IsActive==false).ToList();
                }
                foreach (var state in states1)
                {
                    stateResponseDTOs.
                        Add(new StateResponseDTO(
                                            state.Id,
                                            state.Name,
                                            state.IsActive
                                            ));
                }
            }
            return stateResponseDTOs;
        }
    }
}
