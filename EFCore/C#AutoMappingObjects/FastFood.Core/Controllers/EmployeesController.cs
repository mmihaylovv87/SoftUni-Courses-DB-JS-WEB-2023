namespace FastFood.Web.Controllers;

using System;
using AutoMapper;
using Data;
using FastFood.Web.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

public class EmployeesController : Controller
{
    private readonly FastFoodContext _context;
    private readonly IMapper _mapper;

    public EmployeesController(FastFoodContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Register()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult Register(RegisterEmployeeInputModel model)
    {
        throw new NotImplementedException();
    }

    public IActionResult All()
    {
        throw new NotImplementedException();
    }
}
