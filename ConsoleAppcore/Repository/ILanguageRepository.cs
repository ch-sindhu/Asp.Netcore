using ConsoleAppcore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAppcore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}