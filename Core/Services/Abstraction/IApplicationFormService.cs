using Core.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstraction
{
    public interface IApplicationFormService
    {
        Task<IEnumerable<ApplicationForm>> GetAllAsync();
        Task<ApplicationForm> GetByIdAsync(string id);
        Task<bool> AddAsync(ApplicationFormDto entity);
        Task<bool> UpdateAsync(string id, ApplicationFormDto updateDto);
        Task<bool> DeleteAsync(string id);
    }
}
