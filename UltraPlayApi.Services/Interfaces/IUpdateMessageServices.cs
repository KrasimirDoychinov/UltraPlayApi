using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UltraPlayApi.Services.Interfaces
{
    public interface IUpdateMessageServices
    {
        public Task Create(int uniqueId, string description, int id, string oldValue, string newValue);

        public IEnumerable<T> GetAll<T>(IMapper mapper = null);
    }
}
