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
    public class ProgramDetailsService : IProgramDetailsService
    {
        private readonly IRepository<ProgramDetails> _repository;

        public ProgramDetailsService(IRepository<ProgramDetails> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(ProgramDto entity)
        {

            var programDetails = new ProgramDetails
            {
                Title = entity.Title,
                Summary = entity.Summary,
                Description = entity.Description,
                Skills = entity.Skills,
                Benefits = entity.Benefits,
                Criteria = entity.Criteria,
                ProgramInformation = new ProgramInformation
                {
                    Type = entity.ProgramInformation.Type,
                    Duration = entity.ProgramInformation.Duration,
                    StartDate = entity.ProgramInformation.StartDate,
                    ApplicationOpen = entity.ProgramInformation.ApplicationOpen,
                    ApplicationClose = entity.ProgramInformation.ApplicationClose,
                    Location = entity.ProgramInformation.Location,
                    NumberOfApplication = entity.ProgramInformation.NumberOfApplication,
                    Qualification = entity.ProgramInformation.Qualification
                }
            };
            var result = await _repository.AddAsync(programDetails);

            if (result != null)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<ProgramDetails>> GetAllAsync()
        {
            var programDetails = await _repository.GetAllAsync();

            return programDetails;
        }


        public async Task<ProgramDetails> GetByIdAsync(string id)
        {
            var programDetail = await _repository.GetByIdAsync(id);

            return programDetail;
        }

        public async Task UpdateAsync(string id, ProgramDetails entity)
        {
            await _repository.UpdateAsync(id, entity);
        }
    }
}
