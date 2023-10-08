using Core.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstraction
{
    public interface IWorkFlowService
    {
        Task<IEnumerable<WorkFlow>> GetAllAsync();
        Task<WorkFlow> GetByIdAsync(string id);
        Task<bool> AddAsync(WorkFlowDto entity);
        Task<bool> UpdateAsync(string id, WorkFlow entity);
        Task<bool> DeleteAsync(string id);
    }
}
