using Core.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstraction
{
    public interface IProgramDetailsService
    {
        Task<IEnumerable<ProgramDetails>> GetAllAsync();
        Task<ProgramDetails> GetByIdAsync(string id);
        Task<bool> AddAsync(ProgramDto entity);
        Task<bool> UpdateAsync(string id, ProgramDto updateDto);
        Task<bool> DeleteAsync(string id);
    }
}
