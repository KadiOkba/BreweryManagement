using BreweryManagement.Application.Beers.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagement.Application.WholesalerStocks.Commands.Stock
{
    public class UpdateWholesalerStockCommandValidator : AbstractValidator<UpdateWholesalerStockCommand>
    {
        public UpdateWholesalerStockCommandValidator()
        {       
            RuleFor(x => x.BeerId).NotNull();
            RuleFor(x => x.WholesalerId).NotNull();
        }
    }
}
