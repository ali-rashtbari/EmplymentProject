using Employment.Application.Contracts.ApplicationServicesContracts;
using Employment.Application.Contracts.PersistanceContracts;
using Employment.Common;
using Employment.Common.Contracts;
using Employment.Common.Dtos;
using Employment.Common.Exceptions;
using Employment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Application.Services.ApplicationServices
{
    public class CategoryService : ICategoryService, IService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResule<int>> AddAsync(string name, int? parentId = null)
        {
            if (parentId.HasValue)
            {
                var parentCategory = _unitOfWork.CategoryRepository.Get(parentId.Value);
                if (parentCategory is null)
                {
                    throw new NotFoundException(msg: ApplicationMessages.CategoryNotFound,
                                                                                         entity: nameof(Category),
                                                                                         id: parentId.Value.ToString());
                }
            }
            var categoy = new Category()
            {
                Name = name,
                ParentId = parentId ?? null
            };
            await _unitOfWork.CategoryRepository.AddAsync(categoy);
            return new CommandResule<int>()
            {
                IsSuccess = true,
                Message = ApplicationMessages.NewCategoryAdded,
                Data = categoy.Id
            };
        }
    }
}
