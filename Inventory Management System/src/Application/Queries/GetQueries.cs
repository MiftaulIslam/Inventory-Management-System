using API.Models;
using Domain.Entities.Models;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Queries;

public class GetQueries
{
    public class GetAllFixedExpensesQuery<T> : IRequest<IReadOnlyList<T>>
    {
        public int PageIndex { get; }
        public int PageSize { get; }

        public GetAllFixedExpensesQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class GetAllFixedExpensesQueryHandler : IRequestHandler<GetAllFixedExpensesQuery<ExpenseFixedDto.WithId>, IReadOnlyList<ExpenseFixedDto.WithId>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFixedExpensesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ExpenseFixedDto.WithId>> Handle(GetAllFixedExpensesQuery<ExpenseFixedDto.WithId> request, CancellationToken cancellationToken)
        {
            var fixedExpenses = await _unitOfWork.Repository<ExpenseFixed>().GetAllAsync(request.PageIndex, request.PageSize);
            return fixedExpenses.Select(e => new ExpenseFixedDto.WithId
            {
                Id = e.Id,
                Name = e.Name,
                Amount = e.Amount,
                IntervalDays = e.IntervalDays,
                CostPerDay = e.CostPerDay,
                InsertDate = e.InsertDate
            }).ToList();
        }
    }
}
