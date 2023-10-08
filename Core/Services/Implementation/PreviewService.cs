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
    public class PreviewService : IPreviewService
    {
        private readonly IRepository<Preview> _repository;
        public PreviewService(IRepository<Preview> repository)
        {
            _repository = repository;
        }


        public async Task<bool> AddAsync(PreviewDto entity)
        {

            var preview = new Preview
            {
                Title = entity.Title,
                Summary = entity.Summary,
                Description = entity.Description,
                Skills = entity.Skills,
                Benefits = entity.Benefits,
                Criteria = entity.Criteria,
                Image = entity.Image,
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
            var result = await _repository.AddAsync(preview);

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

        public async Task<IEnumerable<Preview>> GetAllAsync()
        {
            var preview = await _repository.GetAllAsync();

            return preview;
        }

        public async Task<Preview> GetByIdAsync(string id)
        {
            var preview = await _repository.GetByIdAsync(id);

            return preview;
        }

        public async Task UpdateAsync(string id, Preview entity)
        {
            await _repository.UpdateAsync(id, entity);
        }

    }
}
