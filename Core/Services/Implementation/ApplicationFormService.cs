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
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IRepository<ApplicationForm> _repository;

        public ApplicationFormService(IRepository<ApplicationForm> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(ApplicationFormDto entity)
        {
            var appForm = new ApplicationForm
            {
                Image = entity.Image,
                PersonalInformation = new PersonalInformation
                {
                    FirstName = entity.PersonalInformation.FirstName,
                    LastName = entity.PersonalInformation.LastName,
                    Email = entity.PersonalInformation.Email,
                    DateOfBirth = entity.PersonalInformation.DateOfBirth,
                    Gender = entity.PersonalInformation.Gender,
                    Phone = entity.PersonalInformation.Phone,
                    CurrentResidence = entity.PersonalInformation.CurrentResidence,
                    Nationality = entity.PersonalInformation.Nationality,
                },
                Profile = new Profile
                {
                    Education = entity.Profile.Education,
                    Experience = entity.Profile.Experience,
                    Resume = entity.Profile.Resume,
                },
                AdditionalQuestions = new AdditionalQuestions
                {
                    SelfDescription = entity.AdditionalQuestions.SelfDescription,
                    YearOfGraduation = entity.AdditionalQuestions.YearOfGraduation,
                    Question = entity.AdditionalQuestions.Question,
                    Choice = entity.AdditionalQuestions.Choice,
                    Rejected = entity.AdditionalQuestions.Rejected
                }
            };

            var result = await _repository.AddAsync(appForm);

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

        public async Task<IEnumerable<ApplicationForm>> GetAllAsync()
        {
            var appForm = await _repository.GetAllAsync();

            return appForm;
        }

        public async Task<ApplicationForm> GetByIdAsync(string id)
        {
            var appForm = await _repository.GetByIdAsync(id);

            return appForm;
        }

        public async Task UpdateAsync(string id, ApplicationForm entity)
        {
            await _repository.UpdateAsync(id, entity);
        }
    }
}
