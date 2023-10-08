using Core.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstraction
{
    public interface IPreviewService
    {
        Task<IEnumerable<Preview>> GetAllAsync();
        Task<Preview> GetByIdAsync(string id);
        Task<bool> AddAsync(PreviewDto entity);
        Task UpdateAsync(string id, Preview entity);
        Task<bool> DeleteAsync(string id);
    }
}
