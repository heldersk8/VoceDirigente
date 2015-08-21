﻿using Dominio.Repositorios;
using ODirigente.ViewModels;
using System.Web.Mvc;

namespace ODirigente.Controllers
{
    public class FlamengoController : Controller
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public FlamengoController(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;

        }

        public ActionResult Index()
        {
            var todos = _jogadorRepositorio.ObterTodos();

            return View(todos);
        }

        public ActionResult Zagueiros()
        {
            var listaDeZagueiros = _jogadorRepositorio.ObterTodosZagueiros();
            var viewModel = new ZagueiroViewModel { Zagueiros = listaDeZagueiros };

            return View(viewModel);
        }
    }
}