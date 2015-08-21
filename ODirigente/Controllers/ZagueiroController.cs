﻿using System.Web.Mvc;
using Dominio.Repositorios;

namespace ODirigente.Controllers
{
    public class ZagueiroController : Controller
    {
        private IJogadorRepositorio _jogadorRepositorio;

        public ZagueiroController(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;

        }

        public ActionResult Index()
        {
            var todos = _jogadorRepositorio.ObterTodos();

            return View();
        }

    }
}