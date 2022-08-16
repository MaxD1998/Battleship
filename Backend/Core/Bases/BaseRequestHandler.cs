using AutoMapper;
using Core.Interfaces.Repositories;
using Domain.Bases;
using System.Linq.Expressions;

namespace Core.Bases
{
    public abstract class BaseRequestHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected async Task<TResult> Create<TEntity, TResult>(object model) where TEntity : BaseEntity
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _unitOfWork.Base
                .Create(entity);

            return _mapper.Map<TResult>(result);
        }

        protected async Task<IEnumerable<TResult>> CreateRange<TEntity, TResult>(IEnumerable<object> model) where TEntity : BaseEntity
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(model);
            var results = await _unitOfWork.Base
                .CreateRange(entities);

            return _mapper.Map<IEnumerable<TResult>>(results);
        }

        protected async Task Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            await _unitOfWork.Base.Delete<TEntity>(id);
        }

        protected async Task<TResult> GetElement<TEntity, TResult>(Expression<Func<TEntity, bool>> expression, bool disableAutoInclude = false) where TEntity : BaseEntity
        {
            var result = await _unitOfWork.Base
                .GetElement(expression, disableAutoInclude);

            return _mapper.Map<TResult>(result);
        }

        protected async Task<TResult> Update<TEntity, TResult>(int id, object model) where TEntity : BaseEntity
        {
            var entity = _mapper.Map<TEntity>(model);
            var result = await _unitOfWork.Base
                .Update(id, entity);

            return _mapper.Map<TResult>(result);
        }
    }
}