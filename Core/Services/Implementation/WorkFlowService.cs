using Core.DTOs;
using Core.Services.Abstraction;
using Domain.Models;
using Domain.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Implementation
{
    public class WorkFlowService : IWorkFlowService
    {
        private readonly IRepository<WorkFlow> _repository;
        public WorkFlowService(IRepository<WorkFlow> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(WorkFlowDto entity)
        {
            try
            {
                var workFlow = new WorkFlow
                {
                    Name = entity.Name,
                    Stages = new List<WorkFlowStage>()
                };

                foreach (var stageDto in entity.Stages)
                {
                    var stage = new WorkFlowStage
                    {
                        Questions = stageDto.Questions,
                        AdditionalInfo = stageDto.AdditionalInfo,
                        DeadLine = stageDto.DeadLine,
                        Duration = stageDto.Duration,

                    };

                    workFlow.Stages.Add(stage);
                }

                await _repository.AddAsync(workFlow);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<WorkFlow>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<WorkFlow> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(string id, WorkFlow entity)
        {
            try
            {
                await _repository.UpdateAsync(id, entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
